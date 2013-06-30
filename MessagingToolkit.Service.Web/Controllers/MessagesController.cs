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
    public class MessagesController : ApiController
    {
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private readonly ICommandProcessor processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagesController" /> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        /// <exception cref="System.ArgumentNullException">processor</exception>
        public MessagesController(ICommandProcessor processor)
        {
            if (processor == null)
            {
                throw new ArgumentNullException("processor");
            }
            this.processor = processor;
        }


        /// <summary>
        /// Send a message.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("send")]
        public HttpResponseMessage Send(Outgoing msg)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    msg = this.processor.Execute(new AddOutgoingMessageCommand() { Message = msg });
                    var response = Request.CreateResponse<Outgoing>(HttpStatusCode.Created, msg);

                    string uri = Url.Link(RouteName.Messages, new { id = msg.id });
                    response.Headers.Location = new Uri(uri);

                    logger.InfoFormat("Message is saved successfully with id - {0} ", msg.id);

                    return response;
                }
                catch (Exception ex)
                {
                    logger.Error("Error adding message with id " + msg.id, ex);
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Return all received messages.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("received")]
        public IEnumerable<Incoming> Received()
        {
            return this.processor.Execute(new GetAllIncomingMessagesCommand());
        }

        /// <summary>
        /// Search for a particular received message.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <exception cref="System.Web.Http.HttpResponseException"></exception>
        [HttpGet]
        [ActionName("received")]
        public Incoming Received(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Incoming msg = this.processor.Execute(new GetIncomingMessageByIdCommand() { Id = id });
            if (msg == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return msg;
        }

        [HttpPut]
        [ActionName("received")]
        public HttpResponseMessage UpdateReceived(string id, Incoming msg)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(id) && id.Equals(msg.id))
            {
                try
                {
                    msg = this.processor.Execute(new UpdateIncomingMessageCommand() { Message = msg });
                    return Request.CreateResponse<Incoming>(HttpStatusCode.OK, msg);
                }
                catch (Exception ex)
                {
                    logger.Error("Error updating message with id " + id, ex);
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [ActionName("received")]
        public HttpResponseMessage DeleteReceived(string id)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(id))
            {
                try
                {
                    Incoming msg = this.processor.Execute(new DeleteIncomingMessageCommand() { Id = id });
                    return Request.CreateResponse<Incoming>(HttpStatusCode.OK, msg);
                }
                catch (Exception ex)
                {
                    logger.Error("Error deleting message with id " + id, ex);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }


        /// <summary>
        /// Get all received messages.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("sent")]
        public IEnumerable<Outgoing> Sent()
        {
            return this.processor.Execute(new GetAllOutgoingMessagesCommand());
        }

        /// <summary>
        /// Search for a particular sent message.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <exception cref="System.Web.Http.HttpResponseException"></exception>
        [HttpGet]
        [ActionName("sent")]
        public Outgoing Sent(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Outgoing msg = this.processor.Execute(new GetOutgoingMessageByIdCommand() { Id = id });
            if (msg == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return msg;
        }

        [HttpPut]
        [ActionName("sent")]
        public HttpResponseMessage UpdateSent(string id, Outgoing msg)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(id) && id.Equals(msg.id))
            {
                try
                {
                    msg = this.processor.Execute(new UpdateOutgoingMessageCommand() { Message = msg });
                    return Request.CreateResponse<Outgoing>(HttpStatusCode.OK, msg);
                }
                catch (Exception ex)
                {
                    logger.Error("Error updating message with id " + id, ex);
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [ActionName("sent")]
        public HttpResponseMessage DeleteSent(string id)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(id))
            {
                try
                {
                    Outgoing msg = this.processor.Execute(new DeleteOutgoingMessageCommand() { Id = id });
                    return Request.CreateResponse<Outgoing>(HttpStatusCode.OK, msg);
                }
                catch (Exception ex)
                {
                    logger.Error("Error deleting message with id " + id, ex);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }


    }
}