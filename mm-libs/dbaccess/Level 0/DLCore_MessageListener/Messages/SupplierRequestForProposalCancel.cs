using System;
using System.Xml.Serialization;

namespace Realm.APODemand
{
    public class SupplierRequestForProposalCancel
    {
        public const string MESSAGE_TYPE = "realm.cmn.supplier.request_for_proposal_cancel.create";

        public SupplierRequestForProposalCancel() { }        

        #region Properties

        [XmlElement]
        public RequestForProposalCancel_ContentHeader ContentHeader { get; set; }      

        #endregion
        
        public class RequestForProposalCancel_ContentHeader
        {
            [XmlElement(ElementName = "RequestForProposal")]
            public RequestForProposalItem RequestForProposal { get; set; }

            [XmlElement(ElementName = "Comment ")]
            public String Comment { get; set; }
        }

        public class RequestForProposalCancel_Positions
        {
                
        }
    }
}
