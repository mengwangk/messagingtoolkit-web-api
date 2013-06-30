using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Models;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class DeleteOutgoingMessageCommandHandler : CommandHandlerBase, ICommandHandler<DeleteOutgoingMessageCommand, Outgoing>
    {
        public Outgoing Process(DeleteOutgoingMessageCommand command)
        {
            using (var context = new mainContext())
            {
                Outgoing msg = context.Outgoings.Find(command.Id);
                if (msg != null)
                {
                    context.Outgoings.Remove(msg);
                    context.SaveChanges();
                }
                return msg;
            }
        }
    }
}
