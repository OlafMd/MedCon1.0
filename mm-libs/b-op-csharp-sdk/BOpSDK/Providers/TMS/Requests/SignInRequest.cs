using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BOp.Providers.TMS.Requests
{
    [DataContract]
    public class SignInRequest
    {
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "password")]
        public string Password { get; set; }
        [DataMember(Name = "tenantId", EmitDefaultValue = false)]
        public Guid TenantID { get; set; }
        [DataMember(Name = "useDefaultTenant", EmitDefaultValue = false)]
        public Boolean UseDefaultTenant { get; set; }
        [DataMember(Name = "sessionDetails", EmitDefaultValue=false)]
        public SessionDetails SessionDetails { get; set; }
    }

    [DataContract]
    public class SessionDetails
    {
        [DataMember(Name = "userAgent", EmitDefaultValue = false)]
        public string UserAgent { get; set; }
        [DataMember(Name = "externalAddress", EmitDefaultValue = false)]
        public string ExternalAddress { get; set; }
        [DataMember(Name = "timeout", EmitDefaultValue = false)]
        public int Timeout { get; set; }
    }

}
