using System;
using System.Xml.Serialization;

namespace Realm.APODemand
{
    public class SupplierRequestForProposalAcceptDecline
    {
        public const string MESSAGE_TYPE = "realm.cmn.supplier.request response_accept_decline.create";

        public SupplierRequestForProposalAcceptDecline() { }

        #region Properties

        [XmlElement]
        public RequestForProposalAcceptDecline_ContentHeader ContentHeader { get; set; }

        #endregion

        public class RequestForProposalAcceptDecline_ContentHeader
        {

            public RequestForProposalAcceptDecline_ContentHeader()
            {
                RequestForProposal = new RequestForProposalItem();
                RequestResponse = new RequestResponseItem();
            }

            [XmlElement(ElementName = "RequestForProposal")]
            public RequestForProposalItem RequestForProposal { get; set; }

            [XmlElement(ElementName = "RequestResponse")]
            public RequestResponseItem RequestResponse { get; set; }

            [XmlElement(ElementName = "Comment ")]
            public String Comment { get; set; }
            
            [XmlElement(ElementName = "IsRequestResponseAccepted")]
            public IsRequestResponseAcceptedItem IsRequestResponseAccepted { get; set; }
        }

        public class RequestForProposalAcceptDecline_Positions
        {

        }
    }

    public class IsRequestResponseAcceptedItem
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }

        [XmlElement(ElementName = "Comment")]
        public string Comment { get; set; }
    }
    
}
