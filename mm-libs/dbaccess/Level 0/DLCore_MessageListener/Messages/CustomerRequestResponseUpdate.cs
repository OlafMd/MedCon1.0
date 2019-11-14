using System.Collections.Generic;
using System.Xml.Serialization;

namespace Realm.APODemand
{
    public class CustomerRequestResponseUpdate
    {
        public const string MESSAGE_TYPE = "realm.cmn.customer.request_response.update";

        public CustomerRequestResponseUpdate() { }

        [XmlElement]
        public RequestResponseUpdate_ContentHeader ContentHeader { get; set; }

        [XmlElement]
        public RequestResponseUpdate_Positions Positions { get; set; }

        public class RequestResponseUpdate_ContentHeader
        {
            [XmlElement(ElementName = "RequestResponse")]
            public RequestResponseItem RequestResponse { get; set; }

            [XmlElement(ElementName = "RequestForProposal")]
            public RequestForProposalItem RequestForProposal { get; set; }         
        }

        public class RequestResponseUpdate_Positions
        {
            public RequestResponseUpdate_Positions()
            {
                OrderSequence = new List<RequestResponsePosition>();
            }

            [XmlArray(ElementName = "OrderSequence")]
            public List<RequestResponsePosition> OrderSequence { get; set; }
        }
    }
}
