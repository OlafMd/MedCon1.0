using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.TMS.Requests
{
    [DataContract]
    public class CommunicationContact
    {
        [DataMember(Name = "id")]
        public String Id { get; set; }

        [DataMember(Name = "communicationContactType")]
        public CommunicationContactType CommunicationContactType { get; set; }

        [DataMember(Name = "value")]
        public String Value { get; set; }

        [DataMember(Name = "defaultContactForThisContactType")]
        public bool DefaultContactForThisContactType { get; set; }
    }

    [DataContract]
    public enum CommunicationContactType
    {
        UNDEFINED = 0,
        PHONE = 1,
        EMAIL = 2,
        FAX = 3,
        EXTENSION = 4, 
        MOBILE = 5, 
        SKYPENAME = 6
    }


}
