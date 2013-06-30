using System;
using System.Collections;
using System.Configuration.Install;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Web.Http.SelfHost;
using MessagingToolkit.Service.Common.Log;
using MessagingToolkit.Service.Web.CompositionRoot;
using MessagingToolkit.Service.Web.Helpers.Container;

namespace MessagingToolkit.Service.Web.Host
{
    public partial class WebApiHost : ServiceBase
    {
        protected static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        
        private HttpSelfHostServer server;

        public WebApiHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                var config = new HttpSelfHostConfiguration(Properties.Settings.Default.HostingURL);
                Bootstrapper.ConfigureHttp(config);
                config.DependencyResolver = new IoCContainer(Bootstrapper.Container);

                //AreaRegistration.RegisterAllAreas();

                //WebApiConfig.Register(GlobalConfiguration.Configuration);
                //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                //RouteConfig.RegisterRoutes(RouteTable.Routes);
                //BundleConfig.RegisterBundles(BundleTable.Bundles);

                // Apply global model validation
                //GlobalConfiguration.Configuration.Filters.Add(new ModelValidationFilterAttribute());

                server = new HttpSelfHostServer(config);
                server.OpenAsync().Wait();

                logger.InfoFormat("Server is started at {0} ", Properties.Settings.Default.HostingURL);
            }
            catch (Exception ex)
            {
                logger.Error("Error starting host server", ex);
            }
            
        }

        protected override void OnStop()
        {
            if (server != null)
            {
                server.CloseAsync().Wait();
                server = null;
            }
        }

        /// <summary>
        /// Start the program in foreground
        /// </summary>
        /// <param name="args">The args.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public void StartForeground(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "/install":
                    case "-install":
                    case "--install":
                        {
                            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                            if (args.Length > 1)
                            {
                                directory = Path.GetFullPath(args[1]);
                            }
                            if (!Directory.Exists(directory))
                                throw new ArgumentException(String.Format("The directory {0} doesn't exists.", directory));

                            var transactedInstaller = new TransactedInstaller();
                            var serviceInstaller = new ServiceInstaller();
                            transactedInstaller.Installers.Add(serviceInstaller);
                            var ctx = new InstallContext();
                            ctx.Parameters["assemblypath"] = String.Format("{0} \"{1}\"", Assembly.GetExecutingAssembly().Location, directory);
                            transactedInstaller.Context = ctx;
                            transactedInstaller.Install(new Hashtable());

                            Console.WriteLine("The service is installed.");
                        }
                        return;
                    case "/uninstall":
                    case "-uninstall":
                    case "--uninstall":
                        {
                            var transactedInstaller = new TransactedInstaller();
                            var serviceInstaller = new ServiceInstaller();
                            transactedInstaller.Installers.Add(serviceInstaller);
                            var ctx = new InstallContext();
                            ctx.Parameters["assemblypath"] = String.Format("{0}", Assembly.GetExecutingAssembly().Location);
                            transactedInstaller.Context = ctx;
                            transactedInstaller.Uninstall(null);

                            Console.WriteLine("The service is uninstalled.");
                        }
                        return;
                    default:
                        if (args[0][0] != '/' &&
                            args[0][0] != '-')
                            throw new ArgumentException(string.Format("The argument {0} isn't supported.", args[0]));
                        break;
                }
            }

            OnStart(args);

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }

    }
}
