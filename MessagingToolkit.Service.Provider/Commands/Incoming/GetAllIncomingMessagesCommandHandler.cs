using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Models;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class GetAllIncomingMessagseCommandHandler : CommandHandlerBase, ICommandHandler<GetAllIncomingMessagesCommand, Incoming[]>
    {
        public Incoming[] Process(GetAllIncomingMessagesCommand command)
        {
            using (var context = new mainContext())
            {
                var all = from g in context.Incomings
                          orderby g.id
                          select g;
                if (all != null && all.Count() > 0)
                    return all.ToArray<Incoming>();
                return new Incoming[] { };
            }
        }
    }
}
