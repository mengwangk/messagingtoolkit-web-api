using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Provider.Commands;

namespace MessagingToolkit.Service.Provider.Events
{
    public sealed class ExecutionCompletedEventArgs: EventArgs
    {

        public ICommand Command { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public object Result { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public Exception Error { get; set; }
    }
}
