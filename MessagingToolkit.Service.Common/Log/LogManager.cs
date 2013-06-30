using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagingToolkit.Service.Common.Log
{
    /// <summary>
    /// Factory provider for a custom logger
    /// </summary>
    public static class LogManager
    {
        private static ILogFactory logFactory;

        // Static initializer
        static LogManager()
        {
            // Default to log4net, you can use NLogLogFactory as well
            logFactory = new Log4NetLogFactory();
        }

        /// <summary>
        /// Sets the log factory.
        /// </summary>
        /// <param name="factory">The log factory.</param>
        public static void SetLogFactory(ILogFactory factory)
        {
            logFactory = factory;
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static ILog GetLogger(string name)
        {
            return logFactory.GetLog(name);
        }
    }
}
