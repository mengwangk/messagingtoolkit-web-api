using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingToolkit.Service.Client.Models
{
    public class Incoming
    {
        public string id { get; set; }
        public string msg_content { get; set; }
        public string date_created { get; set; }
        public string date_modified { get; set; }
    }
}
