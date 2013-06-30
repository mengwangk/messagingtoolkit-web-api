using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingToolkit.Service.Provider.Commands
{
    public interface ICommandHandler
    {
        IServiceProviderContract Provider { get; set; }
    }

    public interface ICommandHandler<TCommand, TResult>: ICommandHandler where TCommand : ICommand<TResult> 
    {
        TResult Process(TCommand command);
    }
}
