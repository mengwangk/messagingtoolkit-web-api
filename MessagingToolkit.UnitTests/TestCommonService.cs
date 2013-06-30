using System;
using MessagingToolkit.Core.Mobile;
using MessagingToolkit.Service.Common.Helpers;
using Newtonsoft.Json;

using Xunit;

namespace MessagingToolkit.UnitTests
{
    public class TestCommonService
    {
        [Fact]
        public void TestJson()
        {
            MobileGatewayConfiguration config = MobileGatewayConfiguration.NewInstance();
            config.PortName = "COM8";
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            Console.WriteLine(json);
            MobileGatewayConfiguration config1 = JsonConvert.DeserializeObject<MobileGatewayConfiguration>(json);
            Assert.Equal(config, config1);
        }

        [Fact]
        public void TestEntityHelper()
        {
            string dtString = EntityHelper.CurrentLocalDateString();
            Console.WriteLine(dtString);

            DateTime dt = EntityHelper.ConvertDate(dtString);

            Console.WriteLine(dt.ToString());
        }
    }
}
