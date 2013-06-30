using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NLog;

namespace MessagingToolkit.Service.Common.Log
{
    /// <summary>
    /// NLog logging implementation. To be implemented
    /// </summary>
    public sealed class NLogLog : ILog
    {
        private Logger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogLog"/> class.
        /// </summary>
        /// <param name="log">The log.</param>
        public NLogLog(Logger log)
        {
            if (log == null)
                throw new ArgumentNullException("log");

            logger = log;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is debug enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is debug enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsDebugEnabled
        {
            get { return logger.IsDebugEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is error enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is error enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsErrorEnabled
        {
            get { return logger.IsErrorEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is fatal enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is fatal enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsFatalEnabled
        {
            get { return logger.IsFatalEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is info enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is info enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsInfoEnabled
        {
            get { return logger.IsInfoEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is warn enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is warn enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsWarnEnabled
        {
            get { return logger.IsWarnEnabled; }
        }

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(object message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Debug(object message, Exception exception)
        {
            logger.DebugException(message.ToString(), exception);
        }

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        public void DebugFormat(string format, object arg0)
        {
            logger.Debug(format, arg0);
        }

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void DebugFormat(string format, params object[] args)
        {
            logger.Debug(format, args);
        }

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            logger.Debug(provider, format, args);
        }

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        public void DebugFormat(string format, object arg0, object arg1)
        {
            logger.Debug(format, arg0, arg1);
        }

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            logger.Debug(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(object message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Error(object message, Exception exception)
        {
            logger.ErrorException(message.ToString(), exception);
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        public void ErrorFormat(string format, object arg0)
        {
            logger.Error(format, arg0);
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void ErrorFormat(string format, params object[] args)
        {
            logger.Error(format, args);
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            logger.Error(provider, format, args);
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        public void ErrorFormat(string format, object arg0, object arg1)
        {
            logger.Error(format, arg0, arg1);
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            logger.Error(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Fatal(object message)
        {
            logger.Fatal(message);
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Fatal(object message, Exception exception)
        {
            logger.FatalException(message.ToString(), exception);
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        public void FatalFormat(string format, object arg0)
        {
            logger.Fatal(format, arg0);
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void FatalFormat(string format, params object[] args)
        {
            logger.Fatal(format, args);
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            logger.Fatal(provider, format, args);
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        public void FatalFormat(string format, object arg0, object arg1)
        {
            logger.Fatal(format, arg0, arg1);
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            logger.Fatal(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info(object message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Info(object message, Exception exception)
        {
            logger.InfoException(message.ToString(), exception);
        }

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        public void InfoFormat(string format, object arg0)
        {
            logger.Info(format, arg0);
        }

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void InfoFormat(string format, params object[] args)
        {
            logger.Info(format, args);
        }

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            logger.Info(provider, format, args);
        }

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        public void InfoFormat(string format, object arg0, object arg1)
        {
            logger.Info(format, arg0, arg1);
        }

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            logger.Info(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warn(object message)
        {
            logger.Warn(message);
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Warn(object message, Exception exception)
        {
            logger.WarnException(message.ToString(), exception);
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        public void WarnFormat(string format, object arg0)
        {
            logger.Warn(format, arg0);
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void WarnFormat(string format, params object[] args)
        {
            logger.Warn(format, args);
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            logger.Warn(provider, format, args);
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        public void WarnFormat(string format, object arg0, object arg1)
        {
            logger.Warn(format, arg0, arg1);
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            logger.Warn(format, arg0, arg1, arg2);
        }
    }
}
