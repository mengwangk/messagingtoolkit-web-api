using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingToolkit.Service.Provider
{
    /// <summary>
    /// Service provider interface to enable WFC service to communicate with the
    /// hosted service.
    /// </summary>
    public interface IServiceProviderContainer
    {
        event ExecutionCompletedEventHandler ExecutionCompleted;
    }
}
