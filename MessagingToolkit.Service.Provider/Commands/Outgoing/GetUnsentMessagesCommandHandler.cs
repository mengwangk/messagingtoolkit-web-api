using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Core;
using MessagingToolkit.Core.Mobile.Message;
using MessagingToolkit.Service.Common.Helpers;
using MessagingToolkit.Service.Common.Models;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class GetUnsentMessagesCommandHandler : CommandHandlerBase, ICommandHandler<GetUnsentMessagesCommand, Outgoing[]>
    {
        public Outgoing[] Process(GetUnsentMessagesCommand command)
        {
            try
            {
                string archived = StringEnum.GetStringValue(MessageStatus.Archived);
                string failed = StringEnum.GetStringValue(MessageStatus.Failed);
                string sending = StringEnum.GetStringValue(MessageStatus.Sending);
                string sent = StringEnum.GetStringValue(MessageStatus.Sent);
                using (var context = new mainContext())
                {
                    IOrderedQueryable<Outgoing> outgoings = context.Outgoings.Where(msg => msg.status != archived &&
                                                                        msg.status != failed &&
                                                                        msg.status != sending &&
                                                                        msg.status != sent).OrderBy(msg => msg.date_modified);

                    List<Outgoing> outgoingList = new List<Outgoing>();
                    
                    foreach (Outgoing outgoing in outgoings)
                    {
                        // Let's check for the schedule delivery date
                        Sms msg = EntityHelper.FromCommonRepresentation<Sms>(outgoing.msg_content);
                        if (msg.ScheduledDeliveryDate == null || msg.ScheduledDeliveryDate <= DateTime.Now)
                        {
                            outgoingList.Add(outgoing);
                        }
                    }
                    return outgoingList.ToArray<Outgoing>();
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error retrieving unsent messages", ex);
                return new Outgoing[] { }; // Return a empty array
            }
        }
    }
}
