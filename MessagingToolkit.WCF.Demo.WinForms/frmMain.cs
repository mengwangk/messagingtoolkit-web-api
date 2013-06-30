using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

using MessagingToolkit.Core.Mobile;
using MessagingToolkit.Service.Common;
using MessagingToolkit.Service.Common.Helpers;
using MessagingToolkit.Service.Common.Models;
using MessagingToolkit.Service.Common.Models.Mapping;
using MessagingToolkit.WCF.Demo.WinForms.Models;
using MessagingToolkit.WCF.Demo.WinForms;
using MessagingToolkit.WCF.Demo.WinForms.CommandService;
using MessagingToolkit.Service.Provider.Commands;
using MessagingToolkit.Core.Mobile.Message;

namespace MessagingToolkit.WCF.Demo.WinForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnHeartBeat_Click(object sender, EventArgs e)
        {
            /*
            SMSServiceClient client = new SMSServiceClient();
            string echo = client.HeartBeat("hello world");
            MessageBox.Show(echo);


            client.Close();
            */
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            /*
            SmsMessage message = new SmsMessage { Id = "abc", Content = "testing", Timestamp = DateTime.Now };
            SMSServiceClient client = new SMSServiceClient();
            SmsMessage msg = client.SendSMS(message);
            MessageBox.Show(msg.Id);
            client.Close();
            */
        }

        private void btnTestGetConfig_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new mainContext())
                {
                    if (context.Database.Exists())
                    {
                        // Insert a new entry

                        var config = new AppConfig()
                            {
                                id = EntityHelper.GenerateGuid(),
                                configurable = false,
                                description = "testing",
                                name = "test_param",
                                module = "testmodule",
                                value = "test value",
                                date_created = DateTime.Now.ToString(),
                                date_modified = DateTime.Now.ToString()
                            };

                        context.AppConfigs.Add(config);
                        context.SaveChanges();

                        // Display all entries
                        var appConfigs = from a in context.AppConfigs
                                         orderby a.name
                                         select a;

                        foreach (var appConfig in appConfigs)
                        {
                            Console.WriteLine(appConfig.name);
                        }

                        // Update an entry for a particular field
                        context.AppConfigs.Attach(config);
                        var entry = context.Entry(config);
                        config.module = "modified value";
                        entry.Property(c => c.module).IsModified = true;
                        context.SaveChanges();


                        // Display all entries
                        appConfigs = from a in context.AppConfigs
                                     orderby a.name
                                     select a;

                        foreach (var appConfig in appConfigs)
                        {
                            Console.WriteLine(appConfig.name);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnGenerateJson_Click(object sender, EventArgs e)
        {
            //DeviceInfo device = new DeviceInfo() { PortName = "COM8" };
            MobileGatewayConfiguration config = MobileGatewayConfiguration.NewInstance();
            config.PortName = "COM8";
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            txtOutput.Text = json;


            MobileGatewayConfiguration config1 = JsonConvert.DeserializeObject<MobileGatewayConfiguration>(json);

            Console.WriteLine(config1.PortName);
        }

        private void btnInvokeService_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:40281/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List all products.
            HttpResponseMessage response = client.GetAsync("api/gateways/status").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var reply = response.Content.ReadAsStringAsync().Result;
                txtOutput.Text = reply;
            }
            else
            {
                txtOutput.Text = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private void btnAddGateway_Click(object sender, EventArgs e)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:1689/messagingtoolkit/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            DeviceInfo device = new DeviceInfo() { PortName = "COM8" };
            string json = JsonConvert.SerializeObject(device, Formatting.Indented);

            Gateway gateway = new Gateway() { gw_type = 1, gw_config = json };

            // Added a new gateway
            HttpResponseMessage response = client.PostAsJsonAsync<Gateway>("api/gateways", gateway).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var uri = response.Headers.Location;
                var result = response.Content.ReadAsAsync<Gateway>().Result;
                txtOutput.AppendText("Gateway added. Id = " + result.id);
                txtOutput.AppendText("\r\n");

                // Update it
                device.PortName = "COM100";
                result.gw_config = JsonConvert.SerializeObject(device, Formatting.Indented);
                response = client.PutAsJsonAsync<Gateway>("api/gateways/" + result.id, result).Result;
                if (response.IsSuccessStatusCode)
                {
                    txtOutput.AppendText("Gateway updated. Id = " + result.id);
                    txtOutput.AppendText("\r\n");
                }
                else
                {
                    txtOutput.AppendText(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
                    txtOutput.AppendText("\r\n");
                }

                // Retrieve it
                response = client.GetAsync("api/gateways/" + result.id).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var queryGateway = response.Content.ReadAsAsync<Gateway>().Result;
                    txtOutput.AppendText("Gateway JSON Config: " + queryGateway.gw_config);
                    txtOutput.AppendText("\r\n");
                }
                else
                {
                    txtOutput.AppendText(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
                    txtOutput.AppendText("\r\n");
                }

                // Delete it
                response = client.DeleteAsync("api/gateways/" + result.id).Result;
                if (response.IsSuccessStatusCode)
                {
                    txtOutput.AppendText("Gateway deleted. Id = " + result.id);
                    txtOutput.AppendText("\r\n");
                }
                else
                {
                    txtOutput.AppendText(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
                    txtOutput.AppendText("\r\n");
                }

                // Retrieve it. Should be an error now
                response = client.GetAsync("api/gateways/" + result.id).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var queryGateway = response.Content.ReadAsAsync<Gateway>().Result;
                    txtOutput.AppendText("Gateway JSON Config: " + queryGateway.gw_config);
                    txtOutput.AppendText("\r\n");
                }
                else
                {
                    txtOutput.AppendText(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
                    txtOutput.AppendText("\r\n");
                }
            }
            else
            {
                txtOutput.AppendText(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
                txtOutput.AppendText("\r\n");
            }
        }

        private void btnWcfCommandService_Click(object sender, EventArgs e)
        {
            ServiceProviderContractClient client = new ServiceProviderContractClient();
            /*
            NullCommand command = new NullCommand();
            command.Name = "asfsdfsd";
           
            NullObject result = client.Execute(command) as NullObject;
            */
            //txtOutput.AppendText(result.Name);

            GetAllGatewaysCommand command = new GetAllGatewaysCommand();
            object result = client.Execute(command);

            Console.WriteLine(result.GetType());
            //txtOutput.AppendText(result.Count<Gateway>() + "");


        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:40281/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Sms sms = Sms.NewInstance();
            sms.DestinationAddress = "0192292309";
            sms.Content = "testing message";

            Outgoing outgoing = new Outgoing { msg_content = JsonConvert.SerializeObject(sms, Formatting.Indented) };

            HttpResponseMessage response = client.PostAsJsonAsync<Outgoing>("api/messages/send", outgoing).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var uri = response.Headers.Location;
                var result = response.Content.ReadAsAsync<Outgoing>().Result;
                txtOutput.AppendText("Message added. Id = " + result.id);
                txtOutput.AppendText("\r\n");
            }
            else
            {
                txtOutput.AppendText(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
                txtOutput.AppendText("\r\n");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var client = new ServiceProviderContractClient())
            {
                GetGatewayStatusCommand command = new GetGatewayStatusCommand() { Id = "12232"};
                string result = (string)client.Execute(command);
                Console.WriteLine("status: " + result);
            }
        }
    }
}
