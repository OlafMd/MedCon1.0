using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Realm.APODemand
{
    //[DataContract(Name = "SupplierRequestForProposalCreate")]
    public class SupplierRequestForProposalCreate
    {
        public const string MESSAGE_TYPE = "realm.apo-demand.supplier.request_for_proposal.create";

        public SupplierRequestForProposalCreate() {}        

        #region Properties

        [XmlElement]
        public RequestForProposal_ContentHeader ContentHeader { get; set; }

        [XmlElement]
        public RequestForProposal_Positions Positions { get; set; }

        #endregion

        public class RequestForProposal_ContentHeader
        {
            [XmlElement(ElementName = "RequestForProposal")]
            public RequestForProposalItem RequestForProposal { get; set; }

            [XmlElement(ElementName = "CompleteDeliveryUntil ")]
            public String CompleteDeliveryUntil { get; set; }

            [XmlElement(ElementName = "ProposalDeadline ")]
            public String ProposalDeadline { get; set; }
        }

        public class RequestForProposal_Positions
        {
            public RequestForProposal_Positions()
            {
                OrderSequence = new List<ProposalPosition>();
            }

            [XmlArray(ElementName = "OrderSequence")]
            public List<ProposalPosition> OrderSequence { get; set; }
        }
       
    }

    

    public class RequestForProposalItem
    {
        public RequestForProposalItem(){}

        public RequestForProposalItem(string requestForProposalITPL = "")
        {
            RequestForProposalITPL = requestForProposalITPL;
        }

        [XmlAttribute(AttributeName = "RequestForProposalITPL")]
        public String RequestForProposalITPL { get; set; }
    }   

    public class ProposalPosition : Position
    {
        public ProposalPosition() : base()
        {           
            IsReplacementAllowed = new Replacement();
        }

        [XmlAttribute(AttributeName = "ProposalPositionITPL")]
        public String ProposalPositionITPL { get; set; }     

        [XmlElement(ElementName = "IsReplacementAllowed ")]
        public Replacement IsReplacementAllowed { get; set; }

        [XmlElement(ElementName = "LatestDateOfDelivery")]
        public String LatestDateOfDelivery { get; set; }

 
    }

    public class Position
    {
        public Position()
        {
            CurrentHealthInsuranceCompany = new HealthInsuranceCompany();
            Product = new RequestProposalProduct();           
        }

        [XmlElement(ElementName = "Product")]
        public Realm.APODemand.RequestProposalProduct Product { get; set; }

        [XmlElement(ElementName = "Quantity")]
        public String Quantity { get; set; }

        [XmlElement(ElementName = "CurrentHealthInsuranceCompany ")]
        public HealthInsuranceCompany CurrentHealthInsuranceCompany { get; set; }
    }

    public class HealthInsuranceCompany
    {
        [XmlAttribute(AttributeName = "BusinessparticipantITL")]
        public String BusinessparticipantITL { get; set; }

        [XmlElement(ElementName = "Name")]
        public String Name { get; set; }

        [XmlElement(ElementName = "IKNumber")]
        public String IKNumber { get; set; }
    }

    public class RequestProposalProduct
    {
        [XmlAttribute(AttributeName = "ProductITL")]
        public String ProductITL { get; set; }

        [XmlAttribute(AttributeName = "VariantITL")]
        public String VariantITL { get; set; }

        [XmlAttribute(AttributeName = "CatalogITL")]
        public String CatalogITL { get; set; }
    }

    public class Replacement
    {
        [XmlAttribute(AttributeName = "Value")]
        public String Value { get; set; }
    }
}
