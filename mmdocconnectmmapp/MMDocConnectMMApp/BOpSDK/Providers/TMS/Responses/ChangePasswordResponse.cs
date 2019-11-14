using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.TMS.Responses
{
    [DataContract]
    public class ChangePasswordResponse
    {
        [DataMember(Name="changedAccounts")]
        public List<BOp.Providers.TMS.Requests.Account> ChangedAccounts { get; set; }
    }
}
