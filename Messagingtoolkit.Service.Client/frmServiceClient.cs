using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Messagingtoolkit.Service.Client.Models;
using MessagingToolkit.Service.Client.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;


namespace Messagingtoolkit.Service.Client
{
    public partial class frmServiceClient : Form
    {

        /// <summary>
        /// Port parity lookup
        /// </summary>
        private Dictionary<string, int> Parity =
            new Dictionary<string, int> { { "None", 0 }, { "Odd", 1 }, { "Even", 2 }, { "Mark", 3 }, { "Space", 4 } };

        /// <summary>
        /// Port stop bits lookup
        /// </summary>
        private Dictionary<string, int> StopBits =
          new Dictionary<string, int> { { "1", 1 }, { "1.5", 3 }, { "2", 2 }, { "None", 0 } };

        /// <summary>
        /// Port handshake lookup
        /// </summary>
        private Dictionary<string, int> Handshake =
          new Dictionary<string, int> { { "None", 0 }, { "RequestToSendXOnXOff", 3 }, { "XOnXOff", 1 }, { "RequestToSend", 2 } };


        private HttpClient client = new HttpClient();

        private Gateway[] gateways;

        public frmServiceClient()
        {
            InitializeComponent();
        }

        private async void btnPostGateway_Click(object sender, EventArgs e)
        {
            if (!FormHelper.ValidateNotEmpty(txtGatewayName, "Gateway name cannot be empty")) return;

            if (!FormHelper.ValidateNotEmpty(cboPort, "You need to specify a valid COM port")) return;

            try
            {
                DeviceInfo deviceInfo = new DeviceInfo()
                {
                    BaudRate = Convert.ToInt32(cboBaudRate.Text),
                    DataBits = Convert.ToInt32(cboDataBits.Text),
                    DisablePinCheck = true,
                    Handshake = Handshake[cboHandshake.Text],
                    LicenseKey = "1234567890",      // Enter a valid license key 
                    Parity = Parity[cboParity.Text],
                    Pin = "123456", // Enter a valid PIN number if PIN check is enabled
                    PortName = cboPort.Text,
                    StopBits = StopBits[cboStopBits.Text]
                };

                Gateway gateway = new Gateway()
                {
                    gw_name = txtGatewayName.Text,
                    gw_config = JsonConvert.SerializeObject(deviceInfo, Formatting.Indented),
                    gw_type = 1,            // 1 for Modem
                    initialize = true,      // Set to true to retrieve all existing messages during initialization
                    smsc_no = txtSmsc.Text,
                    auto_start = chkConnectAtStartup.Checked
                };

                // Call the Web API to store the gateway 
                var response = await client.PostAsJsonAsync<Gateway>("api/gateways/add", gateway);
                response.EnsureSuccessStatusCode();         // Throw on error code.

                MessageBox.Show("Gateway is saved successfully");
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(string.Format("Error saving gateway configuration:  " + ex.Message));
            }

        }

        private void frmServiceClient_Load(object sender, EventArgs e)
        {
            client.BaseAddress = new Uri("http://localhost:1689/messagingtoolkit/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // All possible COM ports
            for (int i = 1; i <= 100; i++)
            {
                cboPort.Items.Add("COM" + i);
            }

            // Baud rate
            cboBaudRate.Items.AddRange(new object[] { 14400, 19200, 38400, 57600, 115200, 230400 });
            cboBaudRate.Text = "" + 115200;

            // Data bits
            cboDataBits.Items.AddRange(new object[] { 4, 5, 6, 7, 8 });
            cboDataBits.Text = "8";

            // Add parity            
            cboParity.Items.AddRange(Parity.Keys.ToArray());
            cboParity.SelectedIndex = 0;

            // Add stop bits         
            cboStopBits.Items.AddRange(StopBits.Keys.ToArray());
            cboStopBits.SelectedIndex = 0;

            // Add handshake          
            cboHandshake.Items.AddRange(Handshake.Keys.ToArray());
            cboHandshake.SelectedIndex = 0;

        }

        private async void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                lstGateways.Items.Clear();
                var response = await client.GetAsync("api/gateways/all");
                response.EnsureSuccessStatusCode();
                gateways = response.Content.ReadAsAsync<Gateway[]>().Result;
                foreach (Gateway gateway in gateways)
                {
                    // Check the gateway status
                    response = await client.GetAsync("api/gateways/status/" + gateway.id);
                    response.EnsureSuccessStatusCode();
                    GatewayStatusInfo status = response.Content.ReadAsAsync<GatewayStatusInfo>().Result;
                    lstGateways.Items.Add(gateway.gw_name + " - " + status.Status);
                }
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(string.Format("Error retrieving gateway:  " + ex.Message));
            }
        }

        private async void btnDeleteGateway_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = lstGateways.SelectedIndex;
                if (selectedIndex >= 0)
                {

                    Gateway gw = gateways[selectedIndex];
                    if (FormHelper.Confirm("Delete gateway " + gw.gw_name) == System.Windows.Forms.DialogResult.Yes)
                    {
                        var response = await client.DeleteAsync("api/gateways/remove/" + gw.id);
                        response.EnsureSuccessStatusCode();
                        lstGateways.Items.RemoveAt(selectedIndex);
                        FormHelper.ShowInfo("Gateway is deleted");
                    }
                }
                else
                {
                    FormHelper.ShowInfo("Nothing to delete");
                }
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(string.Format("Error deleting gateway:  " + ex.Message));
            }
        }

        private async void btnStartGateway_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = lstGateways.SelectedIndex;
                if (selectedIndex >= 0)
                {

                    Gateway gw = gateways[selectedIndex];
                    if (FormHelper.Confirm("Start gateway " + gw.gw_name) == System.Windows.Forms.DialogResult.Yes)
                    {
                        var response = await client.GetAsync("api/gateways/start/" + gw.id);
                        response.EnsureSuccessStatusCode();
                        FormHelper.ShowInfo("Gateway is starting. Refresh to view latest status.");
                    }
                }
                else
                {
                    FormHelper.ShowInfo("Select a gateway to start");
                }
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(string.Format("Error starting gateway:  " + ex.Message));
            }
        }

        private void btnStopGateway_Click(object sender, EventArgs e)
        {

        }
    }
}
