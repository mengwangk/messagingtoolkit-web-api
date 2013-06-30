using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MessagingToolkit.Service.Common.Helper;
using MessagingToolkit.Service.Common.Models;

namespace MessagingToolkit.Service.Web.Models
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<mainContext>
    {
        protected override void Seed(mainContext context)
        {
            var gateways = new List<Gateway>()            
            {
                new Gateway() { id = EntityHelper.GenerateGuid() },
               
            };

            gateways.ForEach(g => context.Gateways.Add(g));
            context.SaveChanges();
        }
    }
}