using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Models;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class GetGatewayByIdCommandHandler : CommandHandlerBase, ICommandHandler<GetGatewayByIdCommand, Gateway>
    {
        public Gateway Process(GetGatewayByIdCommand command)
        {
            using (var context = new mainContext())
            {
                return context.Gateways.Find(command.Id);
            }
        }
    }
}
