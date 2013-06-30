using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagingToolkit.Service.Common.Log
{
    /// <summary>
    /// Console Log
    /// </summary>
    public class ConsoleLog : ILog
    {
        private string name = string.Empty;

        private const string MessageTemplate = "{0}-{1}: {2}";

        private const string DebugLevel = "DEBUG";

        private const string ErrorLevel = "ERROR";

        private const string FatalLevel = "FATAL";

        private const string InfoLevel = "INFO";

        private const string WarnLevel = "WARN";


        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleLog" /> class.
        /// </summary>
        public ConsoleLog()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleLog"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public ConsoleLog(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is debug enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is debug enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsDebugEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is error enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is error enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsErrorEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is fatal enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is fatal enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsFatalEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is info enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is info enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsInfoEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is warn enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is warn enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsWarnEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(object message)
        {
            Console.WriteLine(MessageTemplate, name, DebugLevel, message);
        }

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Debug(object message, Exception exception)
        {
            Console.WriteLine(MessageTemplate, name, DebugLevel, message + Environment.NewLine + exception.Message + Environment.StackTrace);
        }

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        public void DebugFormat(string format, object arg0)
        {
            Console.WriteLine(MessageTemplate, name, DebugLevel, string.Format(format, arg0));
        }

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void DebugFormat(string format, params object[] args)
        {
            Console.WriteLine(MessageTemplate, name, DebugLevel, string.Format(format, args));
        }

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            Console.WriteLine(MessageTemplate, name, DebugLevel, string.Format(provider, format, args));
        }

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        public void DebugFormat(string format, object arg0, object arg1)
        {
            Console.WriteLine(MessageTemplate, name, DebugLevel, string.Format(format, arg0, arg1));
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
            Console.WriteLine(MessageTemplate, name, DebugLevel, string.Format(format, arg0, arg1, arg2));
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(object message)
        {
            Console.WriteLine(MessageTemplate, name, ErrorLevel, message);
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Error(object message, Exception exception)
        {
            Console.WriteLine(MessageTemplate, name, ErrorLevel, message + Environment.NewLine + exception.Message + Environment.StackTrace);
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        public void ErrorFormat(string format, object arg0)
        {
            Console.WriteLine(MessageTemplate, name, ErrorLevel, string.Format(format, arg0));
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void ErrorFormat(string format, params object[] args)
        {
            Console.WriteLine(MessageTemplate, name, ErrorLevel, string.Format(format, args));
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            Console.WriteLine(MessageTemplate, name, ErrorLevel, string.Format(provider, format, args));
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        public void ErrorFormat(string format, object arg0, object arg1)
        {
            Console.WriteLine(MessageTemplate, name, ErrorLevel, string.Format(format, arg0, arg1));
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
            Console.WriteLine(MessageTemplate, name, ErrorLevel, string.Format(format, arg0, arg2));
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Fatal(object message)
        {
            Console.WriteLine(MessageTemplate, name, FatalLevel, message);
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Fatal(object message, Exception exception)
        {
            Console.WriteLine(MessageTemplate, name, FatalLevel, message + Environment.NewLine + exception.Message + Environment.StackTrace);
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        public void FatalFormat(string format, object arg0)
        {
            Console.WriteLine(MessageTemplate, name, FatalLevel, string.Format(format, arg0));
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void FatalFormat(string format, params object[] args)
        {
            Console.WriteLine(MessageTemplate, name, FatalLevel, string.Format(format, args));
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            Console.WriteLine(MessageTemplate, name, FatalLevel, string.Format(provider, format, args));
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        public void FatalFormat(string format, object arg0, object arg1)
        {
            Console.WriteLine(MessageTemplate, name, FatalLevel, string.Format(format, arg0, arg1));
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
            Console.WriteLine(MessageTemplate, name, FatalLevel, string.Format(format, arg0, arg1, arg2));
        }

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info(object message)
        {
            Console.WriteLine(MessageTemplate, name, InfoLevel, message);
        }

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Info(object message, Exception exception)
        {
            Console.WriteLine(MessageTemplate, name, InfoLevel, message + Environment.NewLine + exception.Message + Environment.StackTrace);
        }

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        public void InfoFormat(string format, object arg0)
        {
            Console.WriteLine(MessageTemplate, name, InfoLevel, string.Format(format, arg0));
        }

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void InfoFormat(string format, params object[] args)
        {
            Console.WriteLine(MessageTemplate, name, InfoLevel, string.Format(format, args));
        }

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            Console.WriteLine(MessageTemplate, name, InfoLevel, string.Format(provider, format, args));
        }

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        public void InfoFormat(string format, object arg0, object arg1)
        {
            Console.WriteLine(MessageTemplate, name, InfoLevel, string.Format(format, arg0, arg1));
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
            Console.WriteLine(MessageTemplate, name, InfoLevel, string.Format(format, arg0, arg1, arg2));
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warn(object message)
        {
            Console.WriteLine(MessageTemplate, name, WarnLevel, message);
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Warn(object message, Exception exception)
        {
            Console.WriteLine(MessageTemplate, name, WarnLevel, message + Environment.NewLine + exception.Message + Environment.StackTrace);
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        public void WarnFormat(string format, object arg0)
        {
            Console.WriteLine(MessageTemplate, name, WarnLevel, string.Format(format, arg0));
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void WarnFormat(string format, params object[] args)
        {
            Console.WriteLine(MessageTemplate, name, WarnLevel, string.Format(format, args));
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            Console.WriteLine(MessageTemplate, name, WarnLevel, string.Format(provider, format, args));
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        public void WarnFormat(string format, object arg0, object arg1)
        {
            Console.WriteLine(MessageTemplate, name, WarnLevel, string.Format(format, arg0, arg1));
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
            Console.WriteLine(MessageTemplate, name, WarnLevel, string.Format(format, arg0, arg1, arg2));
        }
    }
}
