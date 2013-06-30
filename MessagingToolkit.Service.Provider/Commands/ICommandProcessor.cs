using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingToolkit.Service.Provider.Commands
{
    public interface ICommandProcessor
    {
        TResult Execute<TResult>(ICommand<TResult> command);
    }

}
