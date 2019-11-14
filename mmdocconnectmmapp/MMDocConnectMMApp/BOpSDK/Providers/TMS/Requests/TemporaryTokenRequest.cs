using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.TMS.Requests
{
    [DataContract]
    public class TemporaryTokenRequest
    {
        [DataMember(Name = "accountId")]
        public Guid AccountID { get; set; }
        [DataMember(Name = "tenantId")]
        public Guid TenantID { get; set; }
        [DataMember(Name = "timeToLive", EmitDefaultValue = false)]
        public int TimeToLive { get; set; }
    }
}
