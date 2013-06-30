using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Models;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class GetAppConfigCommandHandler : CommandHandlerBase, ICommandHandler<GetAppConfigCommand, AppConfig>
    {
        public AppConfig Process(GetAppConfigCommand command)
        {
            try
            {
                using (var context = new mainContext())
                {
                    logger.DebugFormat("Searching configuration: name - {0}, module - {1}", command.Name, command.Module);
                    var config = from c in context.AppConfigs
                                 where c.name.ToLower() == command.Name.ToLower()
                                 select c;
                    if (!string.IsNullOrEmpty(command.Module))
                    {
                        return config.First(c => command.Module.ToLower().Equals(c.module.ToLower()));
                    }
                    else
                    {
                        return config.First();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Info("Error retrieving configuration", ex);
            }
            return new AppConfig();
        }
    }
}
