using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.PCH.Data
{
    [DataContract]
    public class PrintingAgentStatus
    {
        [DataMember(Name = "id")]
        public string ID { get; set; }
        [DataMember(Name = "status")]
        public PrintJobStatus Status { get; set; }
        [DataMember(Name = "details")]
        public string Details { get; set; }
        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }
    }
}
