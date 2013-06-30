using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Models;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class GetOutgoingMessagesByStatusCommandHandler : CommandHandlerBase, ICommandHandler<GetOutgoingMessagesByStatusCommand, Outgoing[]>
    {
        public Outgoing[] Process(GetOutgoingMessagesByStatusCommand command)
        {
            using (var context = new mainContext())
            {
                var all = from g in context.Outgoings
                          where g.status == command.Status
                          orderby g.id
                          select g;
                if (all != null && all.Count() > 0)
                    return all.ToArray<Outgoing>();
                return new Outgoing[] { };
            }
        }
    }
}
