using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.TrustRelation
{
    [DataContract]
    public class TrustRelationTypeGroup
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }
        [DataMember(Name = "application")]
        public Guid ApplicationID { get; set; }
        [DataMember(Name = "name")]
        public Dictionary<string, string> Name { get; set; }
        [DataMember(Name = "description")]
        public Dictionary<string, string> Description { get; set; }
        [DataMember(Name = "offeredTrustTypes")]
        public List<Guid> OfferedTrustTypes { get; set; }
        [DataMember(Name = "requestedTrustTypes")]
        public List<Guid> RequestedTrustTypes { get; set; }

        public TrustRelationTypeGroup()
        {
            OfferedTrustTypes = new List<Guid>();
            RequestedTrustTypes = new List<Guid>();
            Name = new Dictionary<string, string>();
            Description = new Dictionary<string, string>();
        }
    }
}
