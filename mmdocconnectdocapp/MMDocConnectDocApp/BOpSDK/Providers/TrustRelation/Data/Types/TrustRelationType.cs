using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.TrustRelation
{
    [DataContract]
    public class TrustRelationType : ITrustRelationTypeDetails
    {
        [DataMember(Name = "externalId")]
        public Guid ID { get; set; }
        [DataMember(Name = "name")]
        public Dictionary<string, string> Name { get; set; }
        [DataMember(Name = "description")]
        public Dictionary<string, string> Description { get; set; }
        [DataMember(Name = "createdByApplicationId")]
        public Guid? CreatedByApplicationID { get; set; }
        [DataMember(Name = "messageTypes")]
        public List<string> MessageTypes { get; set; }
        [DataMember(Name = "version",EmitDefaultValue = false)]
        public int? Version { get; set; }
    }
    [DataContract]
    public class TrustRelationTypeInfo
    {
        [DataMember(Name = "externalId")]
        public Guid ID { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "createdByApplicationId", EmitDefaultValue = false)]
        public Guid? CreatedByApplicationID { get; set; }
        [DataMember(Name = "messageTypes")]
        public List<string> MessageTypes { get; set; }
        [DataMember(Name = "version")]
        public int? Version { get; set; }
        [DataMember(Name = "fromGroupId")]
        public string FromGroupID { get; set; }

    }
    public interface ITrustRelationTypeDetails : ITrustRelationTypeInfo
    {
        List<string> MessageTypes { get; set; }
    }

    public interface ITrustRelationTypeInfo
    {
        Guid? CreatedByApplicationID { get; set; }
        Guid ID { get; set; }
        Dictionary<string, string> Description { get; set; }
        Dictionary<string, string> Name { get; set; }
        int? Version { get; set; }
    }
}
