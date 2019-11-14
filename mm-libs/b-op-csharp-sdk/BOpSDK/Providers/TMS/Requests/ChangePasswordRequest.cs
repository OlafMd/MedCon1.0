using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BOp.Providers.TMS.Requests
{
    [DataContract]
    public class ChangePasswordRequest
    {
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "tenantId", EmitDefaultValue=false)]
        public Guid TenantID { get; set; }
        [DataMember(Name = "oldPasswordHash")]
        public string OldPassword { get; set; }
        [DataMember(Name = "newPasswordHash")]
        public string NewPassword { get; set; }
    }
}
