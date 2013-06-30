using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace MessagingToolkit.Service.Provider.CompositionRoot
{
    public class UnityInstanceContextExtension : IExtension<InstanceContext>
    {
        private IUnityContainer childContainer;

        public IUnityContainer GetChildContainer(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            return childContainer ?? (childContainer = container.CreateChildContainer());
        }

        public void DisposeOfChildContainer()
        {
            if (childContainer != null)
            {
                childContainer.Dispose();
            }
        }

        public void Attach(InstanceContext owner)
        {
        }

        public void Detach(InstanceContext owner)
        {
        }
    }
}
