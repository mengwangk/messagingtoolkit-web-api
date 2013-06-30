using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Models;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class GetIncomingMessageByIdCommandHandler : CommandHandlerBase, ICommandHandler<GetIncomingMessageByIdCommand, Incoming>
    {
        public Incoming Process(GetIncomingMessageByIdCommand command)
        {
            using (var context = new mainContext())
            {
                return context.Incomings.Find(command.Id);
            }
        }
    }
}
