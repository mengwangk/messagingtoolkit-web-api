using System;
using System.Collections.Generic;

namespace MessagingToolkit.Service.Common.Models
{
    public partial class User
    {
        public User()
        {
            this.Roles = new List<Role>();
        }

        public string id { get; set; }
        public string common_name { get; set; }
        public string mobtel { get; set; }
        public string email { get; set; }
        public string login_name { get; set; }
        public string password { get; set; }
        public bool can_be_deleted { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
