using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Provider.Commands;

namespace MessagingToolkit.Service.Provider.Events
{
    public sealed class ExecutionRequestEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionRequestEventArgs" /> class.
        /// </summary>
        /// <param name="command">The command.</param>
        public ExecutionRequestEventArgs(ICommand command)
        {
            this.Command = command;
        }

        /// <summary>
        /// The command to be executed.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public ICommand Command { get; private set; }


        /// <summary>
        /// Execution result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public object Result { get; set; }
    }
}
