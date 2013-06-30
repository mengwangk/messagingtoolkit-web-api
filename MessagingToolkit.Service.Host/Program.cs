using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using MessagingToolkit.Service.Common.Log;
using MessagingToolkit.Service.Provider.CompositionRoot;

namespace MessagingToolkit.Service.Host
{
    static class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            
            if (!Environment.UserInteractive)
            {
                ConfigureApp();
                ServiceBase[] servicesToRun;
                servicesToRun = new ServiceBase[] 
                { 
                    new MessagingService() 
                };
                ServiceBase.Run(servicesToRun);
            }
            else
            {
                try
                {
                    EnableConsole();
                    ConfigureApp();
                    var service = new MessagingService();
                    service.StartForeground(args);
                }
                catch (Exception ex)
                {
                    logger.Info(ex);
                    var innerExc = ex.InnerException;
                    while (innerExc != null)
                    {
                        logger.Info(innerExc);
                        innerExc = innerExc.InnerException;
                    }
                }
            }
        }

        private const int ATTACH_PARENT_PROCESS = -1;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass")]
        private static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass")]
        private static extern bool AllocConsole();

        /// <summary>
        /// Enables console mode if it is not started as Windows Service.
        /// </summary>
        public static void EnableConsole()
        {
            if (!AttachConsole(ATTACH_PARENT_PROCESS))
            {
                AllocConsole();
            }
        }


        /// <summary>
        /// Configures the application.
        /// </summary>
        private static void ConfigureApp()
        {
            if (Environment.UserInteractive)
            {
                // Set to log to console if in interactive mode
                LogManager.SetLogFactory(new ConsoleLogFactory());
            }

            // Bootstrap the application
            Bootstrapper.Bootstrap();
          
        }
    }
}
