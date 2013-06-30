using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class GatewayStatusInfo
    {
        public GatewayStatusInfo()
        {
            this.Status = string.Empty;
            this.OperatorInfo = string.Empty;
            this.SignalStrengthPercent = 0;
        }

        public string Status { get; set; }

        public string OperatorInfo { get; set; }

        public int SignalStrengthPercent { get; set; }
    }
}
