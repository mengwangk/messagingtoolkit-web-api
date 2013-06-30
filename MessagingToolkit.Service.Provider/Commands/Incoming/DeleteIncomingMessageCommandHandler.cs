using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Models;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class DeleteIncomingMessageCommandHandler : CommandHandlerBase, ICommandHandler<DeleteIncomingMessageCommand, Incoming>
    {
        public Incoming Process(DeleteIncomingMessageCommand command)
        {
            using (var context = new mainContext())
            {
                Incoming msg = context.Incomings.Find(command.Id);
                if (msg != null)
                {
                    context.Incomings.Remove(msg);
                    context.SaveChanges();
                }
                return msg;
            }
        }
    }
}
