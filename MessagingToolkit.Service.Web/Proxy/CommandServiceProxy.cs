using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessagingToolkit.Service.Provider.Commands;
using MessagingToolkit.Service.Web.CommandService;

namespace MessagingToolkit.Service.Web.Proxy
{
    /// <summary>
    /// Invoke the command service 
    /// </summary>
    /// <typeparam name="TCommand">The type of the query.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public sealed class CommandServiceProxy<TCommand, TResult> : CommandHandlerBase, ICommandHandler<TCommand, TResult>
         where TCommand : ICommand<TResult>
    {
        public TResult Process(TCommand command)
        {
            using (var service = new ServiceProviderContractClient())
            {
                return (TResult)service.Execute(command);
            }
        }
    }
}