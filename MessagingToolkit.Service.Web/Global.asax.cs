using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using MessagingToolkit.Service.Common.Models;
using MessagingToolkit.Service.Web.CompositionRoot;
using MessagingToolkit.Service.Web.Controllers;
using MessagingToolkit.Service.Web.Helpers.Container;
using MessagingToolkit.Service.Web.Helpers.Filters;


namespace MessagingToolkit.Service.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {

        private void ConfigureApi(HttpConfiguration config)
        {
            Bootstrapper.Bootstrap();
            config.DependencyResolver = new IoCContainer(Bootstrapper.Container);
        }


        /// <summary>
        /// Invoked when the application is started.
        /// </summary>
        protected void Application_Start()
        {
            ConfigureApi(GlobalConfiguration.Configuration);

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Apply global model validation
            GlobalConfiguration.Configuration.Filters.Add(new ModelValidationFilterAttribute());
        }
    }
}