using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace DLCore_MessageListener.Messages.Zugseil
{
    [DataContract(Name = "ProcurementOrderHeader")]
    public class ProcurementOrderHeader
    {
        public const string MESSAGE_TYPE = "realm.zugseil.customer-order-request-creation.request";

        #region properties
        [XmlElement(ElementName = "ProcurementOrderID")]
        public Guid  ProcurementOrderID { get; set; }

        [XmlElement(ElementName = "OrderNumber")]
        public string OrderNumber { get; set; }

        [XmlElement(ElementName = "OrderingCustomerBusinessParticipantID")]
        public Guid OrderingCustomerBusinessParticipantID { get; set; }

        [XmlElement(ElementName = "CreatedByBusinessParticipantID")]
        public Guid CreatedByBusinessParticipantID { get; set; }

        [XmlElement(ElementName = "CurrencyISOCode")]
        public string CurrencyISOCode { get; set; }

        [XmlElement(ElementName = "TotalValueBeforeTax")]
        public decimal TotalValueBeforeTax { get; set; }

        [XmlArray(ElementName = "Positions")]
        public List<ProcurementOrderPosition> Positions { get; set; }
        #endregion
    }

    #region HELPER CLASSES
    public class ProcurementOrderPosition
    {
        [XmlElement(ElementName = "ProcurementOrderPositionID")]
        public Guid ProcurementOrderPositionID { get; set; }

        [XmlElement(ElementName = "OridinalNumber")]
        public int OridinalNumber { get; set; }

        [XmlElement(ElementName = "Quantity")]
        public double Quantity { get; set; }

        [XmlElement(ElementName = "ValuePerunit")]
        public decimal ValuePerunit { get; set; }

        [XmlElement(ElementName = "ValueTotal")]
        public decimal ValueTotal { get; set; }

        [XmlElement(ElementName = "Comment")]
        public string Comment { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "RequestedDateOfDelivery")]
        public DateTime RequestedDateOfDelivery { get; set; }

        [XmlElement(ElementName = "ProductRefID")]
        public Guid ProductRefID { get; set; }

        [XmlElement(ElementName = "ProductVariantRefID")]
        public Guid ProductVariantRefID { get; set; }

        [XmlElement(ElementName = "IsProductReplacementAllowed")]
        public bool IsProductReplacementAllowed { get; set; }

        [XmlElement(ElementName = "PriceListReleaseID")]
        public Guid PriceListReleaseID { get; set; }

        [XmlArray(ElementName = "PositionCustomizations")]
        public List<ProcurementOrderCustomization> PositionCustomizations { get; set; }
    }

    public class ProcurementOrderCustomization
    {
        [XmlElement(ElementName = "CustomizationName")]
        public string CustomizationName { get; set; }

        [XmlElement(ElementName = "CustomizationVariantName")]
        public string CustomizationVariantName { get; set; }
         
        [XmlElement(ElementName = "ValuePerUnit")]
        public decimal ValuePerUnit { get; set; }

        [XmlElement(ElementName = "ValueTotal")]
        public decimal ValueTotal { get; set; }

    }
    #endregion
}