using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.TMS.Requests
{
    [DataContract]
    public class AccountStatus
    {
        [DataMember(Name = "accountId")]
        public Guid AccountID { get; set; }
        [DataMember(Name = "status")]
        public EAccountStatus Status;
        [DataMember(Name = "comment")]
        public String Comment { get; set; }
        [DataMember(Name = "creationTimestamp")]
        public DateTime CreationTimestamp { get; set; }
    }

    [DataContract]
    public enum EAccountStatus
    {
        CREATED = 0,
        DEACTIVATED = 1,
        DEACTIVATED_DUE_TO_EXPIRY = 2,
        DEACTIVATED_DUE_TO_NUMBER_OF_ACCESSES = 3,
        REACTIVATED = 4,
        BANNED = 5,
        UNBANNED = 6,
        DELETED = 7,
    }
}
