using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.Service.Common.Log;
using MessagingToolkit.Service.ControlPanel.Helpers;
using MessagingToolkit.Service.ControlPanel.Properties;

namespace MessagingToolkit.Service.ControlPanel
{
    static class Program
    {
        /// <summary>
        /// Mutex to control program instances
        /// </summary>
        public static Mutex mutex;

        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
      
        /// <summary>
        /// Mutex name
        /// </summary>
        private static string MutexName = Application.ProductName;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            try
            {
                bool firstInstance;
                mutex = new Mutex(false, MutexName, out firstInstance);

                if (!firstInstance)
                {
                    FormHelper.ShowInfo(Resources.MsgInstanceRunning);
                    Application.Exit();
                }
                else
                {
                    // Configure the settings
                    ConfigureAppConfig();

                    Application.Run(new frmControlPanel());
                }
            }
            catch (Exception ex)
            {
                FormHelper.ShowError(ex.Message);
                while (ex.InnerException != null)
                {
                    FormHelper.ShowError(ex.InnerException.Message);
                    ex = ex.InnerException;

                }
            }
        }


        /// <summary>
        /// Handles the UnhandledException event of the CurrentDomain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            logger.Error(string.Format("An error has occurred. Production version is [{0}]", Application.ProductVersion));
            logger.Error(ex.Message + Environment.NewLine + ex.Source + Environment.NewLine +
                      ex.StackTrace + Environment.NewLine + ex.InnerException + Environment.NewLine +
                      ex.Data + Environment.NewLine + ex.HelpLink, ex);
        }

        /// <summary>
        /// Handles the ThreadException event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Threading.ThreadExceptionEventArgs"/> instance containing the event data.</param>
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            logger.Error(string.Format("An error has occurred. Production version is [{0}]", Application.ProductVersion));
            logger.Error(e.Exception.Message + Environment.NewLine + e.Exception.Source + Environment.NewLine +
                    e.Exception.StackTrace + Environment.NewLine + e.Exception.InnerException + Environment.NewLine +
                    e.Exception.Data + Environment.NewLine + e.Exception.HelpLink, e.Exception);
        }

        /// <summary>
        /// Configures the application configuration
        /// </summary>
        static void ConfigureAppConfig()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            AppDomain.CurrentDomain.SetData("DataDirectory", currentDirectory);
        }

    }
}
