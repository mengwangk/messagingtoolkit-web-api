using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using MessagingToolkit.Service.Provider.Commands;

namespace MessagingToolkit.Service.Web.CompositionRoot
{
    public sealed class CommandProcessor: ICommandProcessor
    {
        private readonly IUnityContainer container;

        public CommandProcessor(IUnityContainer container)
        {
            this.container = container;
        }

        [DebuggerStepThrough]
        public TResult Execute<TResult>(ICommand<TResult> command)
        {
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = this.container.Resolve(handlerType);

            return handler.Process((dynamic)command);
        }
    }
}
