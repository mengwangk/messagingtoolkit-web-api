using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingToolkit.Service.Client.Models
{
    public class SMS
    {
        public string DestinationAddress { get; set; }
        public string Content { get; set; }
        public int DestinationPort { get; set; }
        public bool Flash { get; set; }
        public List<int> Indexes { get; set; }
        public int LongMessageOption { get; set; }
        public int Protocol { get; set; }
        public bool RawMessage { get; set; }
        public List<int> ReferenceNo { get; set; }
        public string ReplyPath { get; set; }
        public bool SaveSentMessage { get; set; }
        public int SourcePort { get; set; }
        public bool Binary { get; set; }
        public int ContentLength { get; set; }
        public int CustomValidityPeriod { get; set; }
        public byte[] DataBytes { get; set; }
        public int DataCodingScheme { get; set; }
        public int DcsMessageClass { get; set; }
        public int MessageReference { get; set; }
        public string ServiceCenterNumber { get; set; }
        public int StatusReportRequest { get; set; }
        public int ValidityPeriod { get; set; }
        public string GatewayId { get; set; }
        public string Identifier { get; set; }
        public bool Persisted { get; set; }
        public int QueuePriority { get; set; }
        public DateTime ScheduledDeliveryDate { get; set; }
    }
}
