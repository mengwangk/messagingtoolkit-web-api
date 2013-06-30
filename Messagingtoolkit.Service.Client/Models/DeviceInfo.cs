using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messagingtoolkit.Service.Client.Models
{

    /// <summary>
    /// Gateway configuration.
    /// </summary>
    /// <example>
    /// {
    //  "BaudRate": 115200,
    //  "DataBits": 8,
    //  "Handshake": 0,
    //  "PortName": "COM8",
    //  "Parity": 0,
    //  "StopBits": 1,
    //  "RtsEnable": true,
    //  "DtrEnable": true,
    //  "DataConnectionTimeout": 0,
    //  "SafeConnect": false,
    //  "SafeDisconnect": false,
    //  "GatewayId": "",
    //  "InitializationString": "",
    //  "Pin": "",
    //  "Model": "",
    //  "SendRetries": 3,
    //  "SendWaitInterval": 200,
    //  "CommandFile": "command.txt",
    //  "WatchDogInterval": 60000,
    //  "MessagePollingInterval": 10000,
    //  "DeleteReceivedMessage": false,
    //  "ConcatenateMessage": true,
    //  "DisablePinCheck": false,
    //  "DisableWatchDog": false,
    //  "CheckNetworkRegistrationOnStartup": true,
    //  "ResetGatewayAfterTimeout": false,
    //  "AutoDisconnectIncomingCall": false,
    //  "DeviceName": "",
    //  "ProviderMMSC": "",
    //  "ProviderAPN": "",
    //  "ProviderWAPGateway": "",
    //  "ProviderAPNAccount": "",
    //  "ProviderAPNPassword": "",
    //  "DataCompressionControl": false,
    //  "HeaderCompressionControl": false,
    //  "InternetProtocol": 0,
    //  "UserAgent": "",
    //  "XWAPProfile": "",
    //  "Prefixes": [],
    //  "PersistenceQueue": false,
    //  "PersistenceFolder": "",
    //  "OperatorSelectionFormat": 2,
    //  "SkipOperatorSelection": false,
    //  "EncodedUssdCommand": false,
    //  "CommandWaitInterval": 300,
    //  "CommandWaitRetryCount": 100,
    //  "LogFile": "messagingtoolkit",
    //  "LicenseKey": "",
    //  "LogLevel": 1,
    //  "LogQuotaFormat": 0,
    //  "LogSizeMax": 0,
    //  "LogNameFormat": 0,
    //  "LogLocation": "",
    //  "DebugMode": false
    //}
    /// </example>
    public sealed class DeviceInfo
    {
        public int BaudRate { get; set;}
        public int DataBits {get; set;}
        public int Handshake { get; set;}
        public string PortName { get; set;}
        public int Parity {get; set;}
        public int StopBits { get; set;}
        public string Pin { get; set; }
        public bool DisablePinCheck { get; set; }
        public string LicenseKey { get; set; }
    }
}
