using System;
using System.Collections.Generic;

namespace MessagingToolkit.Service.Common.Models
{
    public partial class AppConfig
    {
        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string module { get; set; }
        public string description { get; set; }
        public Nullable<bool> configurable { get; set; }
        public string date_created { get; set; }
        public string date_modified { get; set; }
    }
}
