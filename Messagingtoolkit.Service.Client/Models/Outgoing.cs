using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingToolkit.Service.Client.Models
{
    public sealed class Outgoing
    {
        public string id { get; set; }
        public string msg_content { get; set; }
        public string msg_type { get; set; }
        public string status { get; set; }
        public string date_created { get; set; }
        public string date_modified { get; set; }
    }
}
