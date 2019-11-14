using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.TrustRelation
{
    [DataContract]
    public class TrustRelationRequestInvitation 
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }
        [DataMember(Name = "text")]
        public string Text { get; set; }
        [DataMember(Name = "configuration")]
        public string Configuration { get; set; }
        [DataMember(Name = "groups")]
        public List<string> Groups { get; set; }
        [DataMember(Name = "status")]
        public InvitationStatus Status { get; set; }

        public TrustRelationRequestInvitation()
        {
            Groups = new List<string>();
        }
    }


}
