using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Helpers;
using MessagingToolkit.Service.Common.Models;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class UpdateGatewayCommandHandler : CommandHandlerBase, ICommandHandler<UpdateGatewayCommand, Gateway>
    {
        public Gateway Process(UpdateGatewayCommand command)
        {
            using (var context = new mainContext())
            {
                command.Gateway.date_modified = EntityHelper.CurrentLocalDateString();
                context.Gateways.Attach(command.Gateway);
                context.Entry(command.Gateway).State = EntityState.Modified;
                context.SaveChanges();
                return command.Gateway;
            }
        }
    }
}
