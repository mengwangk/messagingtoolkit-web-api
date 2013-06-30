using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messagingtoolkit.Service.Client.Models
{
    public sealed class GatewayStatusInfo
    {
        public string Status { get; set; }

        public string OperatorInfo { get; set; }

        public int SignalStrengthPercent { get; set; }
    }
}
