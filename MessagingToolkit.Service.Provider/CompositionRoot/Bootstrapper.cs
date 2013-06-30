using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
using Microsoft.Practices.Unity;

using MessagingToolkit.Service.Provider.Commands;
using MessagingToolkit.Service.Common.Helpers;
using MessagingToolkit.Service.Common.Log;


namespace MessagingToolkit.Service.Provider.CompositionRoot
{
    /// <summary>
    /// Bootstrapper class.
    /// </summary>
    public static class Bootstrapper
    {
        // Logger
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        
        // Unity instance
        private static IUnityContainer container;

        /// <summary>
        /// Initializes the <see cref="Bootstrapper" /> class.
        /// </summary>
        static Bootstrapper()
        {
            container = new UnityContainer();
        }

        public static object GetInstance(Type type)
        {
            return container.Resolve(type);
        }

        public static T GetInstance<T>() where T : class
        {
            return container.Resolve<T>();
        }

        public static void Bootstrap()
        {
            // Register types with Unity
            RegisterTypes();


            /*
            Uri baseAddress = new Uri("net.tcp://localhost:8001/messagingtoolkit");
            //ServiceHost selfHost = new UnityServiceHost(container, typeof(CommandService), baseAddress);
            ServiceHost selfHost = new ServiceHost(typeof(CommandService), baseAddress);

            try
            {
                NetTcpBinding tcpBinding = TcpBindingHelper.CreateNetTcpBinding();
                selfHost.AddServiceEndpoint(typeof(IService), tcpBinding, "");
                 
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = false;
                selfHost.Description.Behaviors.Add(smb);

                Binding mexBinding = MetadataExchangeBindings.CreateMexTcpBinding();
                selfHost.AddServiceEndpoint(typeof(IMetadataExchange), mexBinding, "mex");

                return selfHost;
            }
            catch
            {
                selfHost.Abort();
                throw;
            }
            */

        }

        private static void RegisterTypes()
        {
            //container.RegisterTypes(AllClasses.FromLoadedAssemblies(), WithMappings.FromMatchingInterface, WithName.Default);

            container.AddNewExtension<UnityGenericExtension>()
                    .Configure<IOpenGenericExtension>()
                    .RegisterOpenGenericMany(typeof(ICommandHandler<,>));


            //container.RegisterType<ICommandHandler<NullCommand, NullObject>, NullCommandHandler>();

            // container.RegisterType<ILog, ConsoleLog>();

#if DEBUG

            logger.InfoFormat("Container has {0} registrations:", container.Registrations.Count());
            foreach (ContainerRegistration item in container.Registrations)
            {
                logger.DebugFormat("Registered type ------- {0} ",  item.RegisteredType);
            }
        
#endif
        }

    }
}
