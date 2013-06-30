using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using MessagingToolkit.Service.Common;
using MessagingToolkit.Service.Provider.Commands;
using MessagingToolkit.Service.Provider.CompositionRoot;
using MessagingToolkit.Service.Common.Log;
using MessagingToolkit.Service.Provider.Events;

namespace MessagingToolkit.Service.Provider
{

    /// <summary>
    /// Base class for all services.
    /// </summary>
#if DEBUG
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
     MaxItemsInObjectGraph = 131072, IncludeExceptionDetailInFaults = true)]
#else
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
     MaxItemsInObjectGraph = 131072, IncludeExceptionDetailInFaults = false)]
#endif
    public sealed class CommandService : IServiceProviderContract
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);


        /// <summary>
        /// Synchronous event handler.
        /// </summary>
        public event ExecutionRequestEventHandler ExecutionRequest;

        /// <summary>
        /// Asynchronous event handler.
        /// </summary>
        public event ExecutionRequestEventHandler ExecutionRequestAsync;


        /// <summary>
        /// Container hosting the service.
        /// </summary>
        /// <value>
        /// The hosting container
        /// </value>
        public IServiceProviderContainer Container { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandService" /> class.
        /// </summary>
        /// <param name="container">The service container.</param>
        public CommandService(IServiceProviderContainer container)
        {
            this.Container = container;
            this.Container.ExecutionCompleted += Container_ExecutionCompleted;
            
        }

        public object Execute(object command)
        {
            Type commandType = command.GetType();

            if (logger.IsDebugEnabled)
                logger.Debug("Command received: " + commandType.FullName);

            Type resultType = CommandTypesProvider.GetCommandResultType(commandType);

            Type commandHandlerType = typeof(ICommandHandler<,>).MakeGenericType(commandType, resultType);
            ICommandHandler commandHandler = Bootstrapper.GetInstance(commandHandlerType) as ICommandHandler;
            commandHandler.Provider = this;
            return commandHandlerType.GetMethod("Process").Invoke(commandHandler, new[] { command });
        }


        private void Container_ExecutionCompleted(object sender, ExecutionCompletedEventArgs e)
        {
            logger.InfoFormat("Execution completed for command {0}", e.Command.GetType().FullName);
        }


        /// <summary>
        /// Executes the request synchrononously.
        /// </summary>
        /// <typeparam name="TResult">The expected return result.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public TResult ExecuteRequest<TResult>(ICommand command)
        {
            if (ExecutionRequest != null)
            {
                ExecutionRequestEventArgs args = new ExecutionRequestEventArgs(command);
                ExecutionRequest(this, args);
                return (TResult)args.Result;
            }
            return default(TResult);
        }



        /// <summary>
        /// Executes the request asynchrononously.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public void ExecuteRequestAsync(ICommand command)
        {
            if (ExecutionRequestAsync != null)
            {
                ExecutionRequestEventArgs args = new ExecutionRequestEventArgs(command);
                ExecutionRequestAsync.BeginInvoke(this, args, new AsyncCallback(this.AsyncCallback), null);
            }
        }


        /// <summary>
        /// Asynchronous callback method
        /// </summary>
        /// <param name="param">Result</param>
        private void AsyncCallback(IAsyncResult param)
        {
            try
            {
                System.Runtime.Remoting.Messaging.AsyncResult result = (System.Runtime.Remoting.Messaging.AsyncResult)param;
                if (result.AsyncDelegate is ExecutionRequestEventHandler)
                {
                    logger.Info("Ending async ExecutionRequestEventHandler call");
                    ((ExecutionRequestEventHandler)result.AsyncDelegate).EndInvoke(result);
                }
                else
                {
                    logger.Warn("Warning: AsyncCallback got unknown delegate: " + result.AsyncDelegate.GetType().ToString());
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error in asynchronous call back", ex);
            }
        }
    }
}
