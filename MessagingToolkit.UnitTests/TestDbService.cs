using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Helpers;
using MessagingToolkit.Service.Common.Models;
using MessagingToolkit.UnitTests.Models;
using Newtonsoft.Json;
using Xunit;

namespace MessagingToolkit.UnitTests
{
    public class TestDbService
    {
        [Fact]
        public void TestInsert()
        {
            using (var context = new mainContext())
            {
                DeviceInfo device = new DeviceInfo() { PortName = "COM9" };
                /*
                Gateway gateway = new Gateway() { GatewayType = Gateway.Protocol.Modem, JsonConfig = JsonConvert.SerializeObject(device, Formatting.Indented)};

                gateway gw = new gateway() { id = EntityHelper.GenerateGuid() };
                context.gateways.Add(gw);
                context.SaveChanges();
                */

                
            }

        }
    }
}
