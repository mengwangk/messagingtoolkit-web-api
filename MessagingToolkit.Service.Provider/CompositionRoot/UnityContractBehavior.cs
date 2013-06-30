using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace MessagingToolkit.Service.Provider.CompositionRoot
{
    public class UnityContractBehavior : IContractBehavior
    {
        private readonly IInstanceProvider instanceProvider;

        public UnityContractBehavior(IInstanceProvider instanceProvider)
        {
            if (instanceProvider == null)
            {
                throw new ArgumentNullException("instanceProvider");
            }

            this.instanceProvider = instanceProvider;
        }

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = instanceProvider;
            dispatchRuntime.InstanceContextInitializers.Add(new UnityInstanceContextInitializer());
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
    }
}
