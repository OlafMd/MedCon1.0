using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BOp.Providers.TMS.Requests
{
    [DataContract]
    public class ReasonWrapper
    {
        [DataMember(Name = "reason")]
        public string Reason { get; set; }
    }
}
