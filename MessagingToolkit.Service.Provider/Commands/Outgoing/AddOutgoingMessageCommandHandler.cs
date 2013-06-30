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
    public sealed class AddOutgoingMessageCommandHandler : CommandHandlerBase, ICommandHandler<AddOutgoingMessageCommand, Outgoing>
    {
        public Outgoing Process(AddOutgoingMessageCommand command)
        {
            if (command.Message == null)
            {
                throw new ArgumentException("message");
            }
            using (var context = new mainContext())
            {
                if (!string.IsNullOrEmpty(command.Message.id))
                {
                    var existingMsg = context.Gateways.Find(command.Message.id);
                    if (existingMsg != null)
                    {
                        command.Message.date_modified = EntityHelper.CurrentLocalDateString();
                        command.Message.date_created = existingMsg.date_created;    // To ensure creation date is not modified by caller
                        //context.Outgoings.Attach(command.Message);
                        //context.Entry(command.Message).State = EntityState.Modified;
                        context.Entry(existingMsg).CurrentValues.SetValues(command.Message);
                        context.SaveChanges();
                        return command.Message;
                    }
                }

                // User supplies a non valid id. Generat a system id, and create a new message
                command.Message.id = EntityHelper.GenerateGuid();
                command.Message.date_created = EntityHelper.CurrentLocalDateString();
                command.Message.date_modified = command.Message.date_created;
                context.Outgoings.Add(command.Message);
                context.SaveChanges();
                return command.Message;

            }
        }
    }
}