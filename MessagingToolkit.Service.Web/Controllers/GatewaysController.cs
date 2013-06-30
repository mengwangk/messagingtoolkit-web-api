using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MessagingToolkit.Service.Common.Log;
using MessagingToolkit.Service.Common.Models;
using MessagingToolkit.Service.Provider.Commands;

namespace MessagingToolkit.Service.Web.Controllers
{
    /// <summary>
    /// Gateways controller class, providing all Web APIs related
    /// for gateway management.
    /// </summary>
    public class GatewaysController : ApiController
    {
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private readonly ICommandProcessor processor;


        /// <summary>
        /// Initializes a new instance of the <see cref="GatewaysController" /> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        /// <exception cref="System.ArgumentNullException">processor</exception>
        public GatewaysController(ICommandProcessor processor)
        {
            if (processor == null)
            {
                throw new ArgumentNullException("processor");
            }
            this.processor = processor;
        }

        [HttpGet]
        [ActionName("all")]
        public IEnumerable<Gateway> Get()
        {
            try
            {
                return this.processor.Execute(new GetAllGatewaysCommand());
            }
            catch (Exception ex)
            {
                logger.Error("Error retrieving gateways", ex);
                return new Gateway[] { };
            }
        }

        [HttpGet]
        [ActionName("get")]
        public Gateway Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Gateway gateway = this.processor.Execute(new GetGatewayByIdCommand() { Id = id });
            if (gateway == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return gateway;

        }

        /// <summary>
        /// Get the gateway status.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("status")]
        public GatewayStatusInfo Status(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return this.processor.Execute(new GetGatewayStatusCommand() { Id = id });
        }

        /// <summary>
        /// Start the gateway
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("start")]
        public bool Start(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return this.processor.Execute(new StartGatewayCommand() { Id = id });
        }

        /// <summary>
        /// Stop the gateway
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("stop")]
        public bool Stop(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return this.processor.Execute(new StopGatewayCommand() { Id = id });
        }


        [HttpPost]
        [ActionName("add")]
        public HttpResponseMessage Post(Gateway gateway)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    gateway = this.processor.Execute(new AddGatewayCommand() { Gateway = gateway });
                    var response = Request.CreateResponse<Gateway>(HttpStatusCode.Created, gateway);

                    string uri = Url.Link(RouteName.Gateways, new { id = gateway.id });
                    response.Headers.Location = new Uri(uri);
                    return response;
                }
                catch (Exception ex)
                {
                    logger.Error("Error adding gateway with id " + gateway.id, ex);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [ActionName("update")]
        public HttpResponseMessage Put(string id, Gateway gateway)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(id) && id.Equals(gateway.id))
            {
                try
                {
                    gateway = this.processor.Execute(new UpdateGatewayCommand() { Gateway = gateway } );
                    return Request.CreateResponse<Gateway>(HttpStatusCode.OK, gateway);
                }
                catch (Exception ex)
                {
                    logger.Error("Error updating gateway with id " + id, ex);
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [ActionName("remove")]
        public HttpResponseMessage Delete(string id)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(id))
            {
                try
                {
                    Gateway gateway = this.processor.Execute(new DeleteGatewayCommand() { Id = id });
                    return Request.CreateResponse<Gateway>(HttpStatusCode.OK, gateway);
                }
                catch (Exception ex)
                {
                    logger.Error("Error deleting gateway with id " + id, ex);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

    }
}
