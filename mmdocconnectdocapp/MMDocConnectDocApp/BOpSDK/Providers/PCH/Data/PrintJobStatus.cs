using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.PCH
{
    [DataContract]
    public class PrintJobStatus
    {
        [DataMember(Name = "id")]
        public Guid ID { get; set; }
        [DataMember(Name = "status")]
        public EPrintJobStatus Status { get; set; }
        [DataMember(Name = "details")]
        public string Details { get; set; }
        [DataMember(Name = "timestamp")]
        public DateTime Timestamp { get; set; }

    }
}
