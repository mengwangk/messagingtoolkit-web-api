using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Models;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class DeleteGatewayCommandHandler : CommandHandlerBase, ICommandHandler<DeleteGatewayCommand, Gateway>
    {
        public Gateway Process(DeleteGatewayCommand command)
        {
            using (var context = new mainContext())
            {
                Gateway gateway = context.Gateways.Find(command.Id);
                if (gateway != null)
                {
                    context.Gateways.Remove(gateway);
                    context.SaveChanges();
                }
                return gateway;
            }
        }
    }
}
