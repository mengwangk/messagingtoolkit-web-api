using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace MessagingToolkit.Service.Provider.CompositionRoot
{
    public abstract class UnityServiceHostFactory : ServiceHostFactory
    {
        protected abstract void ConfigureContainer(IUnityContainer container);

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var container = new UnityContainer();

            ConfigureContainer(container);

            return new UnityServiceHost(container, serviceType, baseAddresses);
        }
    }    
}
