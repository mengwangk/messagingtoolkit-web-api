using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

using MessagingToolkit.Service.Provider.Commands;
using MessagingToolkit.Service.Provider.CompositionRoot;
using MessagingToolkit.Service.Web.Proxy;
using MessagingToolkit.Service.Common.Log;
using MessagingToolkit.Service.Web.Controllers;
using System.Web.Http;

namespace MessagingToolkit.Service.Web.CompositionRoot
{
    public static class Bootstrapper
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        
        private static IUnityContainer container;

        public static void Bootstrap()
        {
            container = new UnityContainer();

            container.RegisterType<GatewaysController>();
            container.RegisterType<MessagesController>();

            container.RegisterType<ICommandProcessor, CommandProcessor>();

            container.RegisterType(typeof(ICommandHandler<,>), typeof(CommandServiceProxy<,>));

            // container.RegisterType<IGatewayRepository, GatewayRepository>(new HierarchicalLifetimeManager());
            
            //container.AddNewExtension<UnityGenericExtension>()
            //      .Configure<IOpenGenericExtension>()
            //      .RegisterOpenGeneric(typeof(ICommandHandler<,>), typeof(CommandServiceProxy<,>));

#if DEBUG

            logger.DebugFormat("Container has {0} registrations:", container.Registrations.Count());
            foreach (ContainerRegistration item in container.Registrations)
            {
                logger.DebugFormat("Registered type ------- {0} ", item.RegisteredType);
            }
#endif
        }

        public static IUnityContainer Container
        {
            get
            {
                return container;
            }
        }


        public static TService GetInstance<TService>() where TService : class
        {
            return container.Resolve<TService>();
        }


        public static void ConfigureHttp(HttpConfiguration config)
        {
           /*
           config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
           */
            
            /*
            config.Routes.MapHttpRoute(
               name: "DefaultApiWithId",
               routeTemplate: "api/{controller}/{id}", 
               defaults: new { id = RouteParameter.Optional }, 
               constraints: new { id = @"\d+" }
               );
           */
            
            // Gateway controller mappings 
            config.Routes.MapHttpRoute(
                name: RouteName.Gateways,
                routeTemplate: "api/gateways/{action}/{id}",
                defaults: new { controller = "gateways", id = RouteParameter.Optional }
                );

            // Message controller mapping
            config.Routes.MapHttpRoute(
                name: RouteName.Messages,
                routeTemplate: "api/messages/{action}/{id}",
                defaults: new { controller = "messages", id = RouteParameter.Optional }
                );

            // Help mapping
            config.Routes.MapHttpRoute(
                name: RouteName.Help,
                routeTemplate: "api/help",
                defaults: new { controller = "help"}
                );

            // About mapping
            config.Routes.MapHttpRoute(
                name: RouteName.About,
                routeTemplate: "api/about",
                defaults: new { controller = "help" }
                );

            // Default mapping
            config.Routes.MapHttpRoute(
                name: RouteName.Default,
                routeTemplate: "api",
                defaults: new { controller = "help" }
                );


            /*
            config.Routes.MapHttpRoute(
                name: "DefaultApiGet",
                routeTemplate: "api/{controller}", 
                defaults: new { action = "Get" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApiPost",
                routeTemplate: "api/{controller}", 
                defaults: new { action = "Post" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
                );
            */

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            // config.Formatters.Remove(config.Formatters.XmlFormatter);


        }
    }
}