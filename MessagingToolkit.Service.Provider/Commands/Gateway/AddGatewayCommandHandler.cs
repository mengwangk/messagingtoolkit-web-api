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

    public sealed class AddGatewayCommandHandler : CommandHandlerBase, ICommandHandler<AddGatewayCommand, Gateway>
    {
        public Gateway Process(AddGatewayCommand command)
        {
            if (command.Gateway == null)
            {
                throw new ArgumentException("gateway");
            }
            using (var context = new mainContext())
            {


                if (!string.IsNullOrEmpty(command.Gateway.id))
                {
                    var existingGateway = context.Gateways.Find(command.Gateway.id);
                    if (existingGateway != null)
                    {
                        command.Gateway.date_modified = EntityHelper.CurrentLocalDateString();
                        command.Gateway.date_created = existingGateway.date_created;    // To ensure creation date is not modified by caller
                        //context.Gateways.Attach(command.Gateway);
                        //context.Entry(command.Gateway).State = EntityState.Modified;
                        context.Entry(existingGateway).CurrentValues.SetValues(command.Gateway);
                        context.SaveChanges();
                        return command.Gateway;
                    }
                }

                if (!string.IsNullOrEmpty(command.Gateway.gw_name))
                {
                    var gateways = from g in context.Gateways
                                   where g.gw_name == command.Gateway.gw_name
                                   orderby g.id
                                   select g;
                    if (gateways != null && gateways.Count() > 0)
                    {
                        var existingGateway = gateways.ToArray<Gateway>()[0];
                        if (existingGateway != null)
                        {
                            command.Gateway.id = existingGateway.id;
                            command.Gateway.date_modified = EntityHelper.CurrentLocalDateString();
                            command.Gateway.date_created = existingGateway.date_created;    // To ensure creation date is not modified by caller
                            context.Entry(existingGateway).CurrentValues.SetValues(command.Gateway);
                            context.SaveChanges();
                            return command.Gateway;
                        }
                    }
                }

                // User supply a non valid id. Generat a system id, and create a new gateway
                command.Gateway.id = EntityHelper.GenerateGuid();
                command.Gateway.date_created = EntityHelper.CurrentLocalDateString();
                command.Gateway.date_modified = command.Gateway.date_created;
                context.Gateways.Add(command.Gateway);
                context.SaveChanges();
                return command.Gateway;

            }
        }
    }
}
