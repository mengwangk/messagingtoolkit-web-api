using System;
using System.Collections.Generic;

namespace MessagingToolkit.Service.Common.Models
{
    public partial class Outgoing
    {
        public string id { get; set; }
        public string msg_content { get; set; }
        public string msg_type { get; set; }
        public string status { get; set; }
        public string date_created { get; set; }
        public string date_modified { get; set; }
    }
}
