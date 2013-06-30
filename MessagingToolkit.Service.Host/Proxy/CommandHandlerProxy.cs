using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Provider;
using MessagingToolkit.Service.Provider.Commands;
using MessagingToolkit.Service.Provider.CompositionRoot;

namespace MessagingToolkit.Service.Host.Proxy
{
    public static class CommandHandlerProxy
    {
        public static TResult Process<TResult>(ICommand<TResult> command)
        {
            Type commandType = command.GetType();
            Type resultType = CommandTypesProvider.GetCommandResultType(commandType);
            Type commandHandlerType = typeof(ICommandHandler<,>).MakeGenericType(commandType, resultType);
            object commandHandler = Bootstrapper.GetInstance(commandHandlerType);
            return (TResult)commandHandlerType.GetMethod("Process").Invoke(commandHandler, new object[] { command });
        }
    }
}
