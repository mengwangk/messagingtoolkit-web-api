using System;
using System.Collections.Generic;

namespace MessagingToolkit.Service.Common.Models
{
    public partial class Role
    {
        public Role()
        {
            this.Users = new List<User>();
        }

        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool can_be_deleted { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
