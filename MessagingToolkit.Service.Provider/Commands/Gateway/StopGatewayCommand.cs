using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class StopGatewayCommand : ICommand<bool>
    {
        public string Id { get; set; }
    }
}