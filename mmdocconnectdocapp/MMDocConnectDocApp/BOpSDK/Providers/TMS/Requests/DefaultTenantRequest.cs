using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.TMS.Requests
{
    [DataContract]
    public class DefaultTenantRequest
    {
        [DataMember(Name = "email")]
        public String Email {get ; set;}
        [DataMember(Name = "password")]
        public String Password {get; set; }
        [DataMember(Name = "tenantId")]
        public String TenantID { get; set; }

    }
}
