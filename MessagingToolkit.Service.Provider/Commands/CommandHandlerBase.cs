using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Log;
using MessagingToolkit.Service.Provider.Events;

namespace MessagingToolkit.Service.Provider.Commands
{
    public abstract class CommandHandlerBase
    {
        protected static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        public IServiceProviderContract Provider { get; set; }
        
    }
}
