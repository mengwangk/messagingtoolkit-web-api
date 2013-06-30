using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Models;
using MessagingToolkit.Service.Provider.Commands;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class GetGatewayStatusCommand : ICommand<GatewayStatusInfo>
    {
        public string Id { get; set; }
    }
}
