using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingToolkit.Service.Host
{
    /// <summary>
    /// Service status
    /// </summary>
    public enum ServiceStatus
    {
        /// <summary>
        /// Service is started
        /// </summary>
        Started,
        /// <summary>
        /// Service is stopped
        /// </summary>
        Stopped,
        /// <summary>
        /// Service is paused
        /// </summary>
        Paused,
        /// <summary>
        /// Service is continued
        /// </summary>
        Continue,
        /// <summary>
        /// Service is shutdown
        /// </summary>
        Shutdown
    }
}
