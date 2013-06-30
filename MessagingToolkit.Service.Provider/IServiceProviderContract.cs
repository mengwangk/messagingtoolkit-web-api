using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MessagingToolkit.Service.Common;
using MessagingToolkit.Service.Common.Models;
using MessagingToolkit.Service.Provider.Commands;

namespace MessagingToolkit.Service.Provider
{
    /// <summary>
    /// Service contract interface
    /// </summary>
    [ServiceContract(Namespace = "http://www.twit88.com/messagingtoolkit/v1.0")]
    [ServiceKnownType("GetKnownTypes", typeof(CommandTypesProvider))]
    public interface IServiceProviderContract
    {

        /// <summary>
        /// Executes the request synchrononously.
        /// </summary>
        /// <typeparam name="TResult">The expected return result.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        TResult ExecuteRequest<TResult>(ICommand command);

        /// <summary>
        /// Executes the request asynchrononously.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="command">The command.</param>
        void ExecuteRequestAsync(ICommand command);

        /// <summary>
        /// Container hosting the service.
        /// </summary>
        /// <value>
        /// The hosting container
        /// </value>
        IServiceProviderContainer Container { get; set; }


        [WebInvoke(Method = "POST",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped,
          UriTemplate = "Execute")]
        [OperationContract, FaultContract(typeof(ServiceFault))]
        object Execute(object command);
    }
}
