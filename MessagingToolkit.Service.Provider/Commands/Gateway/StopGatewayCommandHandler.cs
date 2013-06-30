using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Core;
using MessagingToolkit.Core.Service;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class StopGatewayCommandHandler : CommandHandlerBase, ICommandHandler<StopGatewayCommand, bool>
    {
        public bool Process(StopGatewayCommand command)
        {
            try
            {
                this.Provider.ExecuteRequestAsync(command);
            }
            catch (Exception ex)
            {
                logger.Error("Error stopping gateway status", ex);
                return false;
            }
            return true;
        }
    }
}
