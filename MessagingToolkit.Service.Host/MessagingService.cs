using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;
using System.Configuration.Install;
using System.Collections;
using System.Reflection;
using System.Threading;

using MessagingToolkit.Core;
using MessagingToolkit.Core.Base;
using MessagingToolkit.Core.Mobile;
using MessagingToolkit.Core.Service;
using MessagingToolkit.Core.Mobile.Event;
using MessagingToolkit.Core.Mobile.Message;
using MessagingToolkit.Service.Provider.CompositionRoot;
using MessagingToolkit.Service.Common.Log;
using MessagingToolkit.Service.Provider;
using MessagingToolkit.Service.Common.Pollers;
using MessagingToolkit.Service.Host.Pollers;
using MessagingToolkit.Service.Host.Properties;
using MessagingToolkit.Service.Provider.Commands;
using MessagingToolkit.Service.Host.Proxy;
using MessagingToolkit.Service.Common.Models;
using MessagingToolkit.Service.Common.Helpers;
using MessagingToolkit.Service.Provider.Events;


namespace MessagingToolkit.Service.Host
{
    /// <summary>
    /// Service container for hosted MessagingToolkit services.
    /// </summary>
    public partial class MessagingService : ServiceBase, IServiceProviderContainer
    {
        protected static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        /// <summary>
        /// Interval to wait for thread to complete, in milliseconds
        /// </summary>
        private const int ThreadWaitInterval = 500;

        /// <summary>
        /// Thread to start the service
        /// </summary>
        private Thread serviceControlThread;


        /// <summary>
        /// Message gateway service
        /// </summary>
        private MessageGatewayService messageGatewayService;

        /// <summary>
        /// Indicate if the service is started
        /// </summary>
        private ServiceStatus serviceStatus = ServiceStatus.Stopped;

        internal static ServiceHost serviceHost = null;

        private List<Thread> workerThreads;
        private List<Poller> pollers;

        public event ExecutionCompletedEventHandler ExecutionCompleted;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingService" /> class.
        /// </summary>
        public MessagingService()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Start the program in foreground
        /// </summary>
        /// <param name="args">The args.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public void StartForeground(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "/install":
                    case "-install":
                    case "--install":
                        {
                            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                            if (args.Length > 1)
                            {
                                directory = Path.GetFullPath(args[1]);
                            }
                            if (!Directory.Exists(directory))
                                throw new ArgumentException(String.Format("The directory {0} doesn't exists.", directory));

                            var transactedInstaller = new TransactedInstaller();
                            var serviceInstaller = new ServiceInstaller();
                            transactedInstaller.Installers.Add(serviceInstaller);
                            var ctx = new InstallContext();
                            ctx.Parameters["assemblypath"] = String.Format("{0} \"{1}\"", Assembly.GetExecutingAssembly().Location, directory);
                            transactedInstaller.Context = ctx;
                            transactedInstaller.Install(new Hashtable());

                            Console.WriteLine("The service is installed.");
                        }
                        return;
                    case "/uninstall":
                    case "-uninstall":
                    case "--uninstall":
                        {
                            var transactedInstaller = new TransactedInstaller();
                            var serviceInstaller = new ServiceInstaller();
                            transactedInstaller.Installers.Add(serviceInstaller);
                            var ctx = new InstallContext();
                            ctx.Parameters["assemblypath"] = String.Format("{0}", Assembly.GetExecutingAssembly().Location);
                            transactedInstaller.Context = ctx;
                            transactedInstaller.Uninstall(null);

                            Console.WriteLine("The service is uninstalled.");
                        }
                        return;
                    default:
                        if (args[0][0] != '/' &&
                            args[0][0] != '-')
                            throw new ArgumentException(string.Format("The argument {0} isn't supported.", args[0]));
                        break;
                }
            }

            OnStart(args);

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }


        protected override void OnStart(string[] args)
        {
            try
            {
                if (serviceControlThread != null && serviceControlThread.IsAlive)
                {
                    serviceControlThread.Abort();
                    serviceControlThread = null;
                }

                serviceControlThread = new Thread(InitializeService);
                serviceControlThread.IsBackground = true;
                serviceControlThread.Start();
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("Error starting service", ex.Message), ex);
                throw ex;
            }

            // Set to started
            serviceStatus = ServiceStatus.Started;
        }

        protected override void OnStop()
        {
            // Stop the service
            StopService();

            // Set to stopped
            serviceStatus = ServiceStatus.Stopped;
        }

        /// <summary>
        /// Setups the service.
        /// </summary>
        private void InitializeService()
        {
            PrepareService();
            AddRequestHandlers();
            StartMessageService();
            StartServiceHost();
            StartPollers();
        }

        private void StopService()
        {
            try
            {
                logger.Info("Stopping messaging service");
                StopMessageService();

                logger.Info("Stop event listener");
                StopServiceHost();

                logger.Info("Stop pollers");
                StopPollers();
            }
            catch (Exception ex)
            {
                logger.Error("Error stopping service", ex);
            }
        }

        /// <summary>
        /// Stops the message service.
        /// </summary>
        private void StopMessageService()
        {
            try
            {
                if (serviceControlThread != null && serviceControlThread.IsAlive)
                {
                    serviceControlThread.Abort();
                    serviceControlThread = null;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error stoppping messaging service", ex);
            }
        }

        private void StopServiceHost()
        {

            if (serviceHost != null)
            {
                try
                {
                    serviceHost.Close();
                    serviceHost = null;
                }
                catch (Exception e)
                {
                    logger.Error("Error shutting service", e);
                }
            }
        }

        /// <summary>
        /// Prepares the service.
        /// </summary>
        private void PrepareService()
        {
            try
            {
                GetOutgoingMessagesByStatusCommand getMsgCmd = new GetOutgoingMessagesByStatusCommand() { Status = StringEnum.GetStringValue(MessageStatus.Sending) };
                Outgoing[] outgoings = CommandHandlerProxy.Process(getMsgCmd);
                foreach (Outgoing msg in outgoings)
                {
                    msg.status = StringEnum.GetStringValue(MessageStatus.Pending);
                    UpdateOutgoingMessageCommand updateMsgCmd = new UpdateOutgoingMessageCommand() { Message = msg };
                    CommandHandlerProxy.Process(updateMsgCmd);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error preparing the service", ex);
            }
        }


        /// <summary>
        /// Starts the message service.
        /// </summary>
        private void StartMessageService()
        {
            try
            {
                logger.Info("Start messaging service");

                if (messageGatewayService != null)
                {
                    messageGatewayService.RemoveAll();
                    messageGatewayService = null;
                }

                // Create the gateway service instance
                messageGatewayService = MessageGatewayService.NewInstance();

                GetAllGatewaysCommand getAllGwCommand = new GetAllGatewaysCommand();
                Gateway[] gateways = CommandHandlerProxy.Process(getAllGwCommand);
                foreach (Gateway gw in gateways)
                {
                    if (gw.auto_start)
                        ConnectGateway(gw);
                }

                logger.Info("Messaging service started successfully");
            }
            catch (Exception ex)
            {
                logger.Error("Error starting messaging service", ex);
            }
        }


        private void StartServiceHost()
        {
            try
            {
                logger.Debug("Starting service host");

                // Starting the WCF TCP listener
                if (serviceHost != null)
                {
                    serviceHost.Close();
                }

                CommandService commandService = new CommandService(this);
                commandService.ExecutionRequest += CommandService_ExecutionRequest;
                commandService.ExecutionRequestAsync += CommandService_ExecutionRequestAsync;

                //serviceHost = new ServiceHost(typeof(CommandService));

                serviceHost = new ServiceHost(commandService);
                serviceHost.Open();

                // Create event based queue for event processing

                logger.Info("Base address: " + serviceHost.BaseAddresses[0].OriginalString);
            }
            catch (Exception ex)
            {
                logger.Error("Error starting service host", ex);
            }
        }


        /// <summary>
        /// Starts the pollers.
        /// </summary>
        private void StartPollers()
        {
            try
            {
                logger.Debug("Starting outgoing message poller");

                // Stop all pollers, just in case
                StopPollers();

                // Start to poll incoming message
                if (workerThreads == null) workerThreads = new List<Thread>(1);
                if (pollers == null) pollers = new List<Poller>(1);

                OutgoingMessagePoller outgoingMessagePoller = new OutgoingMessagePoller(this.messageGatewayService);
                outgoingMessagePoller.Name = Resources.OutgoingMessagePollerName;
                pollers.Add(outgoingMessagePoller);

                Thread worker = new Thread(new ThreadStart(outgoingMessagePoller.StartTimer));
                worker.IsBackground = true;
                worker.Name = Resources.OutgoingMessagePollerName;
                workerThreads.Add(worker);
                worker.Start();

                logger.Info("Outgoing message poller is started successfully");

            }
            catch (Exception ex)
            {
                logger.Error("Error starting poller", ex);
                StopPollers(); // calls StopPollers
            }
        }

        /// <summary>
        /// Stops the pollers.
        /// </summary>
        private void StopPollers()
        {
            try
            {
                if (pollers == null) return;
                foreach (Poller poller in pollers)
                {
                    logger.InfoFormat("Stopping {0}", poller.Name);
                    poller.StopTimer();
                }
                pollers.Clear();
                pollers = null;

                // Stop all threads
                foreach (Thread t in workerThreads)
                {
                    try
                    {
                        logger.InfoFormat("Stopping thread {0}", t.Name);
                        t.Abort();
                    }
                    catch (Exception ex)
                    {
                        logger.Error(string.Format("Error aborting thread [{0}]", t.Name), ex);
                    }
                }
                workerThreads.Clear();
                workerThreads = null;
            }
            catch (Exception ex)
            {
                logger.Error("Error stoppping poller", ex);
            }
        }


        /// <summary>
        /// Connects the gateway.
        /// </summary>
        /// <param name="id">The id.</param>
        private IGateway ConnectGateway(string id)
        {
            GetGatewayByIdCommand getGatewayCmd = new GetGatewayByIdCommand() { Id = id };
            Gateway gateway = CommandHandlerProxy.Process(getGatewayCmd);
            if (gateway != null)
            {
                return ConnectGateway(gateway);
            }
            return null;
        }


        /// <summary>
        /// Connects to the gateway
        /// </summary>
        /// <param name="gwConfig">The gateway config.</param>
        private IGateway ConnectGateway(Gateway gateway)
        {
            GatewayType gatewayType = (GatewayType)Enum.Parse(typeof(GatewayType), gateway.gw_type.ToString());
            if (gatewayType == GatewayType.Modem)
            {
                MobileGatewayConfiguration config = EntityHelper.FromCommonRepresentation<MobileGatewayConfiguration>(gateway.gw_config);
                MessageGateway<IMobileGateway, MobileGatewayConfiguration> messageGateway = MessageGateway<IMobileGateway, MobileGatewayConfiguration>.NewInstance();
                try
                {
                    IMobileGateway mobileGateway;
                    mobileGateway = messageGateway.Find(config);
                    if (mobileGateway == null)
                    {
                        logger.ErrorFormat("Error connecting to gateway at port {0}. Check the log file", config.PortName);
                    }
                    mobileGateway.Id = gateway.id;
                    mobileGateway.EnableNewMessageNotification(MessageNotification.StatusReport);
                    mobileGateway.PollNewMessages = true;
                    mobileGateway.MessageReceived += new MessageReceivedEventHandler(mobileGateway_MessageReceived);
                    mobileGateway.MessageSendingFailed += new MessageErrorEventHandler(mobileGateway_MessageSendingFailed);
                    mobileGateway.MessageSent += new MessageEventHandler(mobileGateway_MessageSent);
                    logger.InfoFormat("Successfully connected to gateway. Model is {0}. Port is {1}", mobileGateway.DeviceInformation.Model, config.PortName);

                    // Todo: Control sending or receiving only

                    if (!gateway.initialize)
                    {
                        logger.Info("Initializing gateway for the first time");
                        List<MessageInformation> messages = mobileGateway.GetMessages(MessageStatusType.ReceivedReadMessages);
                        bool isSuccessfulSave1 = SaveReceivedMessages(gateway, messages);
                        messages = mobileGateway.GetMessages(MessageStatusType.ReceivedUnreadMessages);
                        bool isSuccessfulSave2 = SaveReceivedMessages(gateway, messages);

                        if (isSuccessfulSave1 && isSuccessfulSave2)
                        {
                            gateway.initialize = true;
                            UpdateGatewayCommand updateGwCmd = new UpdateGatewayCommand() { Gateway = gateway };
                            CommandHandlerProxy.Process(updateGwCmd);
                            logger.Info("Gateway initialized successfully");
                        }
                    }

                    if (!messageGatewayService.Add(mobileGateway))
                    {
                        throw messageGatewayService.LastError;
                    }
                    return mobileGateway;
                }
                catch (Exception ex)
                {
                    logger.ErrorFormat("Failed to connect to gateway using {0}", config.PortName);
                    logger.Error("Error trace", ex);
                }
            }
            else if (gatewayType == GatewayType.SmartPhone)
            {
                // Todo
            }
            return null;
        }

        /// <summary>
        /// Handles the MessageReceived event of the mobileGateway control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MessagingToolkit.Core.Mobile.Event.MessageReceivedEventArgs"/> instance containing the event data.</param>
        void mobileGateway_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            MessageInformation receivedMessage = e.Message;
            logger.InfoFormat("Received message from [{0}] on [{1}]", receivedMessage.PhoneNumber, receivedMessage.ReceivedDate.ToString());

            // Save the message
            SaveIncomingMessage(receivedMessage);
        }

        /// <summary>
        /// Handles the MessageSendingFailed event of the mobileGateway control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MessagingToolkit.Core.Mobile.Event.MessageErrorEventArgs"/> instance containing the event data.</param>
        void mobileGateway_MessageSendingFailed(object sender, MessageErrorEventArgs e)
        {
            if (e.Message != null)
            {
                if (e.Message is Sms)
                {
                    Sms sms = e.Message as Sms;
                    logger.Info(string.Format("Failed to send message [{0}] to [{1}]", sms.Identifier, sms.DestinationAddress));

                    UpdateMessageStatus(sms, MessageStatus.Failed);
                }
            }
        }

        /// <summary>
        /// Handles the MessageSent event of the mobileGateway control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MessagingToolkit.Core.Mobile.Event.MessageEventArgs"/> instance containing the event data.</param>
        void mobileGateway_MessageSent(object sender, MessageEventArgs e)
        {
            if (e.Message != null)
            {
                if (e.Message is Sms)
                {
                    Sms sms = e.Message as Sms;
                    logger.Info(string.Format("Message [{0}] is sent to [{1}] successfully", sms.Identifier, sms.DestinationAddress));

                    UpdateMessageStatus(sms, MessageStatus.Sent);
                }
            }
        }

        private void UpdateMessageStatus(Sms sms, MessageStatus status)
        {
            GetOutgoingMessageByIdCommand getMsgCommand = new GetOutgoingMessageByIdCommand() { Id = sms.Identifier };
            Outgoing outgoing = CommandHandlerProxy.Process(getMsgCommand);
            if (outgoing != null)
            {
                outgoing.status = StringEnum.GetStringValue(status);
            }
            UpdateOutgoingMessageCommand updateMsgCommand = new UpdateOutgoingMessageCommand() { Message = outgoing };
            CommandHandlerProxy.Process(updateMsgCommand);
        }

        /// <summary>
        /// Saves the messages.
        /// </summary>
        /// <param name="gateway">The gateway.</param>
        /// <param name="messages">The messages.</param>
        /// <returns></returns>
        private bool SaveReceivedMessages(Gateway gateway, List<MessageInformation> messages)
        {
            bool isSuccessful = true;
            foreach (MessageInformation message in messages)
            {
                message.GatewayId = gateway.id;
                if (!SaveIncomingMessage(message))
                    isSuccessful = false;
            }
            return isSuccessful;
        }

        /// <summary>
        /// Saves the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="gatewayId">The gateway id.</param>
        /// <returns></returns>
        private bool SaveIncomingMessage(MessageInformation message)
        {
            try
            {
                Incoming incoming = new Incoming() { msg_content = EntityHelper.ToCommonRepreseentation<MessageInformation>(message) };
                AddIncomingMessageCommand command = new AddIncomingMessageCommand() { Message = incoming };
                CommandHandlerProxy.Process(command);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Failed to save message", ex);
            }
            return false;
        }


        #region ------------------ Handling incoming processing request commands ----------------


        private IDictionary<string, Func<ICommand, object>> RequestHandlers = new Dictionary<string, Func<ICommand, object>>();


        /// <summary>
        /// Adds the request handlers.
        /// </summary>
        private void AddRequestHandlers()
        {
            RequestHandlers.Add(typeof(GetGatewayStatusCommand).FullName, CheckGatewayStatus);
            RequestHandlers.Add(typeof(StartGatewayCommand).FullName, StartGateway);
            RequestHandlers.Add(typeof(StopGatewayCommand).FullName, StopGateway);
        }


        /// <summary>
        /// Handles the ExecutionRequest event of the CommandService control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ExecutionRequestEventArgs" /> instance containing the event data.</param>
        private void CommandService_ExecutionRequest(object sender, ExecutionRequestEventArgs e)
        {
            string requestName = e.Command.GetType().FullName;
            Func<ICommand, object> handler;
            if (RequestHandlers.TryGetValue(requestName, out handler))
            {
                e.Result = handler(e.Command);
            }
        }


        /// <summary>
        /// Handles the ExecutionRequestAsync event of the CommandService control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ExecutionRequestEventArgs" /> instance containing the event data.</param>
        private void CommandService_ExecutionRequestAsync(object sender, ExecutionRequestEventArgs e)
        {
            string requestName = e.Command.GetType().FullName;
            Func<ICommand, object> handler;
            if (RequestHandlers.TryGetValue(requestName, out handler))
            {
                e.Result = handler(e.Command);
                if (this.ExecutionCompleted != null)
                {
                    ExecutionCompletedEventArgs args = new ExecutionCompletedEventArgs() { Command = e.Command, Result = e.Result };
                    this.ExecutionCompleted(this, args);
                }
            }
        }

        /// <summary>
        /// Checks the gateway status.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        private GatewayStatusInfo CheckGatewayStatus(ICommand command)
        {
            GetGatewayStatusCommand getGatewayStatusCommand = command as GetGatewayStatusCommand;
            logger.DebugFormat("Check gateway status. ID is [{0}]", getGatewayStatusCommand.Id);
            GatewayStatusInfo statusInfo = new GatewayStatusInfo();
            IGateway gateway;
            if (messageGatewayService.Find(getGatewayStatusCommand.Id, out gateway))
            {
                // Gateway found
                statusInfo.Status = StringEnum.GetStringValue(gateway.Status);
                if (gateway.Status == GatewayStatus.Started)
                {
                    IMobileGateway mobileGateway = gateway as IMobileGateway;
                    statusInfo.OperatorInfo = mobileGateway.NetworkOperator.OperatorInfo;
                    statusInfo.SignalStrengthPercent = mobileGateway.SignalQuality.SignalStrengthPercent;
                }
            }
            else
            {
                statusInfo.Status = StringEnum.GetStringValue(GatewayStatus.Stopped);
            }

            return statusInfo;
        }

        private GatewayStatusInfo StartGateway(ICommand command)
        {
            StartGatewayCommand startGwCmd = command as StartGatewayCommand;
            logger.DebugFormat("Start gateway. ID is [{0}]", startGwCmd.Id);
            IGateway gateway;
            if (messageGatewayService.Find(startGwCmd.Id, out gateway))
            {
                // Check if the status is Stopped/Failed/Restart, if yes, remove and restart
                if (gateway.Status == GatewayStatus.Failed ||
                    gateway.Status == GatewayStatus.Stopped ||
                    gateway.Status == GatewayStatus.Restart)
                {
                    messageGatewayService.Remove(startGwCmd.Id);
                    gateway = ConnectGateway(startGwCmd.Id);
                }
            }
            else
            {
                gateway = ConnectGateway(startGwCmd.Id);
            }

            IMobileGateway mobileGateway = gateway as IMobileGateway;
            return new GatewayStatusInfo()
            {
                Status = StringEnum.GetStringValue(GatewayStatus.Started),
                OperatorInfo = mobileGateway.NetworkOperator.OperatorInfo,
                SignalStrengthPercent = mobileGateway.SignalQuality.SignalStrengthPercent

            };
        }



        /// <summary>
        /// Stops the gateway.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        private GatewayStatusInfo StopGateway(ICommand command)
        {
            StopGatewayCommand stopGwCmd = command as StopGatewayCommand;
            logger.DebugFormat("Start gateway. ID is [{0}]", stopGwCmd.Id);
            IGateway gateway;
            if (messageGatewayService.Find(stopGwCmd.Id, out gateway))
            {
                messageGatewayService.Remove(stopGwCmd.Id);
            }

            return new GatewayStatusInfo() { Status = StringEnum.GetStringValue(GatewayStatus.Stopped)};
        }

        #endregion  ------------- End request handling -----------------------------------------


    }
}
