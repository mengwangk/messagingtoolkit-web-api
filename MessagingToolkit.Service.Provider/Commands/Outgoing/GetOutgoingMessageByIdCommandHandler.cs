using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Models;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class GetOutgoingMessageByIdCommandHandler : CommandHandlerBase, ICommandHandler<GetOutgoingMessageByIdCommand, Outgoing>
    {
        public Outgoing Process(GetOutgoingMessageByIdCommand command)
        {
            using (var context = new mainContext())
            {
                return context.Outgoings.Find(command.Id);
            }
        }
    }
}
