using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace MessagingToolkit.Service.Provider.CompositionRoot
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        private readonly IUnityContainer container;
        private readonly Type contractType;

        public UnityInstanceProvider(IUnityContainer container, Type contractType)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (contractType == null)
            {
                throw new ArgumentNullException("contractType");
            }

            this.container = container;
            this.contractType = contractType;
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            var childContainer =
                instanceContext.Extensions.Find<UnityInstanceContextExtension>().GetChildContainer(container);

            return childContainer.Resolve(contractType);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            instanceContext.Extensions.Find<UnityInstanceContextExtension>().DisposeOfChildContainer();
        }
    }
}
