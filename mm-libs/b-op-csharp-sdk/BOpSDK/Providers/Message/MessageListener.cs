using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BOp.Providers.Message
{
    [DataContract]
    public class MessageListener
    {
        [DataMember(Name = "applicationId")]
        public Guid ApplicationID { get; set; }
        [DataMember(Name = "moduleId")]
        public Guid ModuleID { get; set; }
        [DataMember(Name = "endpoints")]
        public List<Uri> Endpoints { get; set; }
        [DataMember(Name = "messageTypes")]
        public List<String> MessageTypes { get; set; }

    }
}
