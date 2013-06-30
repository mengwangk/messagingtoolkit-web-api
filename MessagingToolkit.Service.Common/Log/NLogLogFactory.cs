using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLog;

namespace MessagingToolkit.Service.Common.Log
{
    /// <summary>
    /// NLog log factory. To be implemented.
    /// </summary>
    public sealed class NLogLogFactory : LogFactoryBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NLogLogFactory"/> class.
        /// </summary>
        public NLogLogFactory()
            : this("NLog.config")
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogLogFactory"/> class.
        /// </summary>
        /// <param name="nlogConfig">The log4net config.</param>
        public NLogLogFactory(string nlogConfig)
            : base(nlogConfig)
        {
        }


        /// <summary>
        /// Gets the log by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public override ILog GetLog(string name)
        {
            return new NLogLog(NLog.LogManager.GetLogger(name));
        }
    }
}
