using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using MessagingToolkit.Service.Common;
using MessagingToolkit.Service.Common.Log;
using MessagingToolkit.Service.ControlPanel.Helpers;

namespace MessagingToolkit.Service.ControlPanel
{
    public partial class frmControlPanel : Form
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        private ServiceController serviceHostController;
        private ServiceController webApiHostController;

        private System.Timers.Timer statusTimer;

        private List<Process> runningProcesses = new List<Process>(2);


        /// <summary>
        /// Initializes a new instance of the <see cref="frmControlPanel" /> class.
        /// </summary>
        public frmControlPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnStart_Click(object sender, EventArgs e)
        {

            try
            {
                if (!IsServiceExists(GlobalValues.ServiceHostServiceName))
                {
                    FormHelper.ShowInfo("Starting service host provider in console mode. Consider install it as Windows Service by executing \"MessagingToolkit.Service.Host /install\"");
                    ExecuteCommand(GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "MessagingToolkit.Service.Host.exe");
                }
                else
                {
                    serviceHostController = new ServiceController(GlobalValues.ServiceHostServiceName, Environment.MachineName);
                    this.serviceHostController.Refresh();
                    if (this.serviceHostController.Status == ServiceControllerStatus.Running)
                    {
                        FormHelper.ShowInfo("Service host is already running");
                        return;
                    }
                    lblServiceProviderStatus.Text = "Starting";
                    lblServiceProviderStatus.Refresh();
                    this.serviceHostController.Start();
                }

                if (!IsServiceExists(GlobalValues.WebAPIHostServiceName))
                {
                    FormHelper.ShowInfo("Starting Web API host in console mode. Consider install it as Windows Service by executing \"MessagingToolkit.Service.Web.Host.exe /install\"");
                    ExecuteCommand(GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "MessagingToolkit.Service.Web.Host.exe");
                }
                else
                {
                    webApiHostController = new ServiceController(GlobalValues.WebAPIHostServiceName, Environment.MachineName);
                    this.webApiHostController.Refresh();
                    if (this.webApiHostController.Status == ServiceControllerStatus.Running)
                    {
                        FormHelper.ShowInfo("Web API host is already running");
                        return;
                    }
                    lblWebApiHostStatus.Text = "Starting";
                    lblWebApiHostStatus.Refresh();
                    this.webApiHostController.Start();
                }

                StartTimer();
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }


        /// <summary>
        /// Starts the timer.
        /// </summary>
        private void StartTimer()
        {
            try
            {
                if (statusTimer != null)
                {
                    statusTimer.Stop();
                    statusTimer = null;
                }

                this.statusTimer = new System.Timers.Timer();
                this.statusTimer.Elapsed += new ElapsedEventHandler(CheckServiceStatus);
                this.statusTimer.Enabled = true;
                this.statusTimer.Interval = 3000;
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Checks the service status.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private void CheckServiceStatus(object sender, ElapsedEventArgs e)
        {
            if (this.serviceHostController != null)
            {
                this.serviceHostController.Refresh();
                lblServiceProviderStatus.Text = this.serviceHostController.Status.ToString();
            }

            if (this.webApiHostController != null)
            {
                this.webApiHostController.Refresh();
                lblWebApiHostStatus.Text = this.webApiHostController.Status.ToString();
            }
        }

        private bool IsServiceExists(string serviceName)
        {
            ServiceController service = ServiceController.GetServices().Where(s => s.ServiceName == serviceName).FirstOrDefault();
            if (service == null) return false;
            return true;
        }

        private string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }


        private void StopAllProcesses()
        {

            if (runningProcesses.Count > 0)
            {
                try
                {
                    foreach (Process p in runningProcesses)
                    {
                        if (!p.HasExited)
                        {
                            p.Kill();
                        }
                    }
                }
                catch { }
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {

            StopAllProcesses();

            if (IsServiceExists(GlobalValues.ServiceHostServiceName))
            {
                try
                {
                    serviceHostController = new ServiceController(GlobalValues.ServiceHostServiceName, Environment.MachineName);
                    if (serviceHostController.Status == ServiceControllerStatus.Stopped)
                    {
                        return;
                    }

                    lblServiceProviderStatus.Text = "Stopping";
                    lblServiceProviderStatus.Refresh();
                    this.serviceHostController.Stop();
                }
                catch (Exception ex)
                {
                    FormHelper.ShowError(ex.Message);
                }
            }

            if (IsServiceExists(GlobalValues.WebAPIHostServiceName))
            {
                try
                {
                    webApiHostController = new ServiceController(GlobalValues.WebAPIHostServiceName, Environment.MachineName);
                    if (webApiHostController.Status == ServiceControllerStatus.Stopped)
                    {
                        return;
                    }

                    lblWebApiHostStatus.Text = "Stopping";
                    lblWebApiHostStatus.Refresh();
                    this.webApiHostController.Stop();
                }
                catch (Exception ex)
                {
                    FormHelper.ShowError(ex.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmControlPanel_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            txtServiceProvider.Text = GlobalValues.ServiceHostServiceName;
            txtWebAPIHost.Text = GlobalValues.WebAPIHostServiceName;

            try
            {
                if (IsServiceExists(GlobalValues.ServiceHostServiceName))
                {
                    serviceHostController = new ServiceController(GlobalValues.ServiceHostServiceName, Environment.MachineName);
                }

                if (IsServiceExists(GlobalValues.WebAPIHostServiceName))
                {
                    webApiHostController = new ServiceController(GlobalValues.WebAPIHostServiceName, Environment.MachineName);
                }
                StartTimer();
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
            }
        }

        private void btnInstallService_Click(object sender, EventArgs e)
        {
            if (!IsServiceExists(GlobalValues.ServiceHostServiceName))
            {
                FormHelper.ShowInfo("Install Windows Service for Service Host");
                ExecuteCommand(GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "MessagingToolkit.Service.Host.exe /install");
            }
            else
            {
                FormHelper.ShowError("Service host Windows Service is already installed");
            }

            if (!IsServiceExists(GlobalValues.WebAPIHostServiceName))
            {
                FormHelper.ShowInfo("Install Windows Service for Web API Host");
                ExecuteCommand(GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "MessagingToolkit.Service.Web.Host.exe /install");

                // For self hosting, need to reserve the HTTP address as administrator
                // netsh http add urlacl url=http://+:8080/ user=machine\username.
                // Assume current user is administrator
                ExecuteCommand(@"netsh http add urlacl url=http://+:1689/ user=""NT AUTHORITY\network service""");
            }
            else
            {
                FormHelper.ShowError("Web API host Windows Service is already installed");
            }
        }


        public void ExecuteCommand(string command)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo =
                new System.Diagnostics.ProcessStartInfo("cmd", "/k " + command);
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = false;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                runningProcesses.Add(proc);
            }
            catch (Exception e)
            {
                FormHelper.ShowError(e.Message);
            }
        }

        private void frmControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopAllProcesses();

            // Free any managed resources in this section
            if (statusTimer != null)
            {
                statusTimer.Stop();
                statusTimer = null;
            }
        }

        private void btnUninstallWindowsServices_Click(object sender, EventArgs e)
        {
            if (IsServiceExists(GlobalValues.ServiceHostServiceName))
            {
                FormHelper.ShowInfo("Uninstall Windows Service for Service Host");
                ExecuteCommand(GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "MessagingToolkit.Service.Host.exe /uninstall");
            }
            else
            {
                FormHelper.ShowError("Service host Windows Service is not installed");
            }

            if (IsServiceExists(GlobalValues.WebAPIHostServiceName))
            {
                FormHelper.ShowInfo("Uninstall Windows Service for Web API Host");
                ExecuteCommand(GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "MessagingToolkit.Service.Web.Host.exe /uninstall");
                ExecuteCommand(@"netsh http delete urlacl url=http://+:1689/");
                
            }
            else
            {
                FormHelper.ShowError("Web API host Windows Service is not installed");
            }
        }

        private void lnkWebSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lnkWebSite.Text); 
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lnkWebApiURL.Text);
        }

        private void btnSampleClient_Click(object sender, EventArgs e)
        {
            Process.Start(GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "MessagingToolkit.Service.Client.exe");
        }
    }
}
