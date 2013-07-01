using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messagingtoolkit.Service.Client.Models
{
    public class SMS
    {
        public string DestinationAddress { get; set; }

        public string Content { get; set; }
    }
}
