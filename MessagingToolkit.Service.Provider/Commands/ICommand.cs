using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MessagingToolkit.Service.Provider.Commands
{
    public interface ICommand
    {

    }

    public interface ICommand<TResult>: ICommand
    {
    }
}
