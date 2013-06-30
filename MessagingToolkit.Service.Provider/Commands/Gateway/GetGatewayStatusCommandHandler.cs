using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Core;
using MessagingToolkit.Core.Service;
using MessagingToolkit.Service.Common.Models;
using MessagingToolkit.Service.Provider.Commands;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class GetGatewayStatusCommandHandler : CommandHandlerBase, ICommandHandler<GetGatewayStatusCommand, GatewayStatusInfo>
    {

        /// <summary>
        /// Get the gateway status from the service host, so this command
        /// must be passed to the service host container.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public GatewayStatusInfo Process(GetGatewayStatusCommand command)
        {
            try
            {
                return this.Provider.ExecuteRequest<GatewayStatusInfo>(command);
            }
            catch (Exception ex)
            {
                logger.Error("Error retrieving gateway status", ex);
            }

            return new GatewayStatusInfo() { Status = StringEnum.GetStringValue(GatewayStatus.Failed) };
        }


    }
}
