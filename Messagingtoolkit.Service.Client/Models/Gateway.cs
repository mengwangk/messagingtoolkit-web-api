using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messagingtoolkit.Service.Client.Models
{
    public sealed class Gateway
    {
        public string id { get; set; }
        public string gw_name { get; set; }
        public int gw_type { get; set; }
        public string gw_config { get; set; }
        public string smsc_no { get; set; }
        public bool auto_start { get; set; }
        public bool initialize { get; set; }
        public string date_created { get; set; }
        public string date_modified { get; set; }
    }
}
