using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Core;
using MessagingToolkit.Core.Log;
using MessagingToolkit.Core.Mobile;
using MessagingToolkit.Service.Provider.Commands;
using MessagingToolkit.Service.Provider.Events;

namespace MessagingToolkit.Service.Provider
{
    /// <summary>
    /// Message format
    /// </summary>
    public enum MessageFormat
    {
        [StringValue("Auto Detect")]
        Auto,
        [StringValue("Text")]
        Text,
        [StringValue("Unicode")]
        Unicode,
        [StringValue("Ansi - 8 Bits")]
        Ansi8Bits
    }

    /// <summary>
    /// Message status
    /// </summary>
    public enum MessageStatus
    {
        /// <summary>
        /// Unsent status
        /// </summary>
        [StringValue("Pending")]
        Pending,
        /// <summary>
        /// Sending status
        /// </summary>
        [StringValue("Sending")]
        Sending,
        /// <summary>
        /// Sent status
        /// </summary>
        [StringValue("Sent")]
        Sent,
        /// <summary>
        /// Failed sending status
        /// </summary>
        [StringValue("Failed")]
        Failed,
        /// <summary>
        /// Archived status
        /// </summary>
        [StringValue("Archived")]
        Archived,
        /// <summary>
        /// Received status
        /// </summary>
        [StringValue("Received")]
        Received
    }

    /// <summary>
    /// Outgoing message type.
    /// </summary>
    public enum OutgoingMessageType
    {
        [StringValue("SMS")]
        SMS,
        [StringValue("WAP Push")]
        WAPPush,
        [StringValue("vCard")]
        vCard,
        [StringValue("vCalendar")]
        vCalendar
    }

    /// <summary>
    /// Gateway type
    /// </summary>
    public enum GatewayType
    {
        Modem = 1,
        SmartPhone = 2
    }


    /// <summary>
    /// Service event handler.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ExecutionRequestEventHandler(object sender, ExecutionRequestEventArgs e);

    /// <summary>
    /// Service event response handler.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ExecutionCompletedEventHandler(object sender, ExecutionCompletedEventArgs e);
   
}
