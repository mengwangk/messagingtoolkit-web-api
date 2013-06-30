using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace MessagingToolkit.Service.Provider.CompositionRoot
{
    public class UnityInstanceContextInitializer : IInstanceContextInitializer
    {
        public void Initialize(InstanceContext instanceContext, Message message)
        {
            instanceContext.Extensions.Add(new UnityInstanceContextExtension());
        }
    }
}
