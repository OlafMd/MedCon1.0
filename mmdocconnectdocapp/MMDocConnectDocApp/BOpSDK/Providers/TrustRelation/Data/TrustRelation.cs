using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.TrustRelation
{
    [DataContract]
    public class TrustRelation
    {
        [DataMember(Name = "code")]
        public Guid ID { get; set; }
        [DataMember(Name = "active")]
        public Boolean IsActive { get; set; }
        [DataMember(Name = "terminationReason")]
        public string TerminationReason { get; set; }
        [DataMember(Name = "terminationDate")]
        public Nullable<DateTime> TerminationDate { get; set; }
        [DataMember(Name = "fromTenant")]
        public Guid FromTenant { get; set; }
        [DataMember(Name = "fromRealm")]
        public Guid FromRealm { get; set; }
        [DataMember(Name = "toTenant")]
        public Guid ToTenant { get; set; }
        [DataMember(Name = "toRealm")]
        public Guid ToRealm { get; set; }
        [DataMember(Name = "offeredTrustTypes")]
        public List<TrustRelationTypeInfo> OfferedTrustTypes { get; set; }
        [DataMember(Name = "requestedTrustTypes")]
        public List<TrustRelationTypeInfo> RequestedTrustType { get; set; }
        [DataMember(Name = "requestDate")]
        public Nullable<DateTime> RequestDate { get; set; }
        [DataMember(Name = "autoApproved")]
        public Boolean? IsAutoApproved { get; set; }
        [DataMember(Name = "initiatedFromTenant")]
        public string InitiatedFromTenant { get; set; }
        [DataMember(Name = "initiatedFromRealm")]
        public string InitiatedFromRealm { get; set; }
    }
    public class TrustRelationFilter
    {
        public Nullable<Boolean> Active { get; set; }
    }
}
