using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Models;

namespace MessagingToolkit.Service.Provider.Commands
{
    /// <summary>
    /// Retrieve application configuration using name and module (optional).
    /// </summary>
    public sealed class GetAppConfigCommand : ICommand<AppConfig>
    {
        public string Name { get; set; }

        public string Module { get; set; }
    }
}
