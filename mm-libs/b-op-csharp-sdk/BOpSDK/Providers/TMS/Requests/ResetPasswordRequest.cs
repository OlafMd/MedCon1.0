using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.TMS.Requests
{
    [DataContract]
    public class ResetPasswordRequest
    {
        [DataMember(Name = "sessionToken")]
        public string SessionToken { get; set; }
        [DataMember(Name = "accountId")]
        public Guid AccountID { get; set; }
        [DataMember(Name = "newPasswordHash")]
        public String NewPassword { get; set; }

    }
}
