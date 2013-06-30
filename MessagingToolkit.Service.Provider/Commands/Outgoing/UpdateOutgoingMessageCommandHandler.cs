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
    public sealed class UpdateOutgoingMessageCommandHandler : CommandHandlerBase, ICommandHandler<UpdateOutgoingMessageCommand, Outgoing>
    {
        public Outgoing Process(UpdateOutgoingMessageCommand command)
        {
            using (var context = new mainContext())
            {
                command.Message.date_modified = EntityHelper.CurrentLocalDateString();
                context.Outgoings.Attach(command.Message);
                context.Entry(command.Message).State = EntityState.Modified;
                context.SaveChanges();
                return command.Message;
            }
        }
    }
}
