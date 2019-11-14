using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.PCH
{
    [DataContract]
    public class PrintJob
    {
        [DataMember(Name = "id")]
        public Guid ID { get; set; }
        [DataMember(Name = "priority")]
        public int Priority { get; set; }
        [DataMember(Name = "type")]
        public EPrintJobType Type { get; set; }
        [DataMember(Name = "template")]
        public string Template { get; set; }
        [DataMember(Name = "data")]
        public string Data { get; set; }

    }
}
