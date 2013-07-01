using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingToolkit.Service.Client.Models
{
    public class MessageInformation
    {
       
        public string Content { get; set; }
       
        public int CurrentPiece { get; set; }
       
        public List<byte> DataBytes { get; set; }
       
        public int DeliveryStatus { get; set; }
       
        public int DestinationPort { get; set; }
       
        public DateTime DestinationReceivedDate { get; set; }
       
        public string GatewayId { get; set; }
       
        public int Index { get; set; }
       
        public List<int> Indexes { get; set; }
       
        public int MessageStatusType { get; set; }
       
        public int MessageType { get; set; }
       
        public string PhoneNumber { get; set; }
       
        public string RawMessage { get; set; }
       
        public DateTime ReceivedDate { get; set; }
       
        public int ReferenceNo { get; set; }
       
        public string ServiceCentreAddress { get; set; }
       
        public int ServiceCentreAddressType { get; set; }
       
        public int SourcePort { get; set; }
       
        public int Status { get; set; }
       
        public string Timezone { get; set; }
       
        public int TotalPiece { get; set; }
       
        public int TotalPieceReceived { get; set; }
       
        public DateTime ValidityTimestamp { get; set; }
    }
}
