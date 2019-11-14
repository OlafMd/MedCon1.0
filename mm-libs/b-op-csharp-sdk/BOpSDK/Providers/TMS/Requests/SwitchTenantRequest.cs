using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BOp.Providers.TMS.Requests
{
    [DataContract]
    public class SwitchTenantRequest
    {
        [DataMember(Name = "tenantIdHash")]
        public string TenantIdHash { get; set; }
    }
}
