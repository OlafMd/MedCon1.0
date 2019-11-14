using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.TMS.Responses
{
    [DataContract]
    public class TenantBasicInfo
    {
        [DataMember(Name="id")]
        public Guid ID { get; set; }
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }
    }
}
