using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using DLCore_MessageListener.Messages;

namespace Realm.APODemand
{
    public class CustomerOrderCreation
    {
        public const string MESSAGE_TYPE = "realm.apo-demand.customer-order-creation.request";
        public const string MESSAGE_VERSION = "2.0";
        public const string MESSAGE_DEFAULTLANGUAGE = "DE";

        public CustomerOrderCreation()
        {
            OrganizationalStructure = new OrganizationalStructureUpdateMessage();
            FrameContracts = new List<Contracts>();
            UndersigningContacts = new List<Person>();
            Procurements = new List<Procurement>();
        }

        public OrganizationalStructureUpdateMessage OrganizationalStructure { get; set; }

        [XmlElement(ElementName = "ProcurementOrder_PolicyRequests")]
        public PolicyRequest ProcurementOrderPolicyRequest { get; set; }

        [XmlArray(ElementName = "FrameContracts")]
        public List<Contracts> FrameContracts { get; set; }

        [XmlArray(ElementName = "UndersigningContacts")]
        public List<Person> UndersigningContacts { get; set; }

        [XmlArray(ElementName = "Procurements")]
        public List<Procurement> Procurements { get; set; }
    }

    public class PolicyRequest{

        #region XML Attributes

        [XmlAttribute(AttributeName = "CustomerOrderPolicy")]
        public String CustomerOrderPolicy { get; set; }

        [XmlAttribute(AttributeName = "ShipmentPolicy")]
        public String ShipmentPolicy { get; set; }

        #endregion  
    }

    public class Contracts {

        #region XML Attributes

        [XmlAttribute(AttributeName = "ITL")]
        public String ITL { get; set; }

        [XmlAttribute(AttributeName = "Number")]
        public String Number { get; set; }

        #endregion    
    }

    public class Person {

        #region XML Attributes

        [XmlAttribute(AttributeName = "AssociatedBusinessparticipantITL")]
        public String AssociatedBusinessparticipantITL { get; set; }

        #endregion  

        #region XML Elements

        [XmlElement(ElementName = "FirstName")]
        public String FirstName { get; set; }

        [XmlElement(ElementName = "LastName")]
        public String LastName { get; set; }

        [XmlElement(ElementName = "Position")]
        public String Position { get; set; }

        [XmlElement(ElementName = "Telephone")]
        public String Telephone { get; set; }

        [XmlElement(ElementName = "Mobile")]
        public String Mobile { get; set; }

        [XmlElement(ElementName = "Email")]
        public String Email { get; set; }

        #endregion  
    
    }

    public class Procurement
    {
        #region XML Elements

        [XmlElement(ElementName = "ProcurementHeader")]
        public ProcurementHeader ProcurementHeaderInfo { get; set; }

        [XmlArray(ElementName = "ProcurementPositions")]
        public List<ProcurementPosition> ProcurementPositions { get; set; }

        [XmlArray(ElementName = "ProcurementComments")]
        public List<ProcurementComment> ProcurementComments { get; set; }

        #endregion 
    }

    public class ProcurementHeader
    {
        #region XML Elements

        [XmlElement(ElementName = "ProcurementOrder")]
        public ProcurementOrder ProcurementOrderInfo { get; set; }

        [XmlElement(ElementName = "RequestedDeliveryInfo")]
        public DeliveryInfo RequestedDeliveryInfo { get; set; }

        #endregion 
    }

    public class ProcurementOrder
    {
        #region XML Attributes

        [XmlAttribute(AttributeName = "ITL")]
        public String ITL { get; set; }

        #endregion

        #region XML Elements

        [XmlElement(ElementName = "OrderNumber")]
        public String OrderNumber { get; set; }

        [XmlElement(ElementName = "OrderDate")]
        public DateTime OrderDate { get; set; }

        #endregion 
    }

    public class DeliveryInfo
    {
        #region XML Elements

        [XmlElement(ElementName = "Requested_LogisticsProvider")]
        public LogisticsProvider Requested_LogisticsProvider { get; set; }

        [XmlElement(ElementName = "DeliveryDate")]
        public String DeliveryDate { get; set; }

        #endregion 

    }

    public class LogisticsProvider
    {
        #region XML Attributes

        [XmlAttribute(AttributeName = "TenantITL")]
        public String TenantITL { get; set; }

        [XmlAttribute(AttributeName = "DeliveryCompany_BusinessparticipantITL")]
        public String DeliveryCompany_BusinessparticipantITL { get; set; }

        #endregion
    }

    public class ProcurementPosition
    {
        [XmlElement(ElementName = "Product")]
        public ProcurementProduct Product { get; set; }

        [XmlElement(ElementName = "TotalOrderQuantity")]
        public Double TotalOrderQuantity { get; set; }

        [XmlArray(ElementName = "TargetOrgUnitInfo")]
        public List<TargetOrgUnit> TargetOrgUnitInfo { get; set; }

        [XmlElement(ElementName = "BillingInfo")]
        public Billing BillingInfo { get; set; }
    }

    public class ProcurementProduct
    {
        #region XML Attributes

        [XmlAttribute(AttributeName = "ProductITL")]
        public String ProductITL { get; set; }

        [XmlAttribute(AttributeName = "ReleaseITL")]
        public String ReleaseITL { get; set; }

        [XmlAttribute(AttributeName = "VariantITL")]
        public String VariantITL { get; set; }

        [XmlAttribute(AttributeName = "SourceCatalogITL")]
        public String SourceCatalogITL { get; set; }

        [XmlAttribute(AttributeName = "IsProductReplacementAllowed")]
        public Boolean IsProductReplacementAllowed { get; set; }

        #endregion

        #region XML Elements

        [XmlElement(ElementName = "ProductCode")]
        public String ProductCode { get; set; }

        [XmlElement(ElementName = "ProductName")]
        public String ProductName { get; set; }

        [XmlElement(ElementName = "ProductDescription")]
        public String ProductDescription { get; set; }

        [XmlElement(ElementName = "Comment")]
        public String Comment { get; set; }

        #endregion 
    }

    public class TargetOrgUnit
    {
        #region XML Attributes

        [XmlAttribute(AttributeName = "OfficeITL")]
        public String OfficeITL { get; set; }

        #endregion

        #region XML Elements

        [XmlElement(ElementName = "SubQuantity")]
        public Double SubQuantity { get; set; }

        #endregion 

    }

    public class Billing
    {
        #region XML Attributes

        [XmlAttribute(AttributeName = "BookToFrameContractITL")]
        public String BookToFrameContractITL { get; set; }

        #endregion

        #region XML Elements

        [XmlElement(ElementName = "NetUnitPrice")]
        public Decimal NetUnitPrice { get; set; }

        [XmlElement(ElementName = "NetValue")]
        public Decimal NetValue { get; set; }

        #endregion 
    }

    public class RelevantCompanies
    {
        #region XML Attributes

        [XmlAttribute(AttributeName = "Company_TenantITL")]
        public String TenantITL { get; set; }

        [XmlAttribute(AttributeName = "Company_BusinessparticipantITL")]
        public String BusinessparticipantITL { get; set; }

        #endregion

        #region XML Elements

        [XmlElement(ElementName = "CompanyName")]
        public String CompanyName { get; set; }

        [XmlArray(ElementName = "ContactPersons")]
        public List<Person> ContactPersons { get; set; }

        #endregion
    }

    public class ProcurementComment
    {
        #region XML Attributes

        [XmlAttribute(AttributeName = "OfficeITL")]
        public String OfficeITL { get; set; }

        #endregion

        #region XML Elements

        [XmlElement(ElementName = "Title")]
        public String Title { get; set; }

        [XmlElement(ElementName = "Content")]
        public String Content { get; set; }

        [XmlElement(ElementName = "PublilshDate")]
        public DateTime PublilshDate { get; set; }

        [XmlElement(ElementName = "SequenceNumber")]
        public int SequenceNumber { get; set; }

        #endregion

    }
}
