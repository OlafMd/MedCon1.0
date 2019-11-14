using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace DLCore_MessageListener.Messages
{
    public class OrganizationalStructureUpdateMessage
    {
        public OrganizationalStructureUpdateMessage()
        {
            Addresses = new List<Address>();
            OrganizationUnits = new List<OrganizationUnit>();
        }

        public const String MESSAGE_TYPE = "realm.cmn.organizational_structure.create_update";

        [XmlArray(ElementName="Addresses")]
        public List<Address> Addresses { get; set; }

        [XmlArray(ElementName="TargetOrgUnits")]
        public List<OrganizationUnit> OrganizationUnits { get; set; }
    }

    [DataContract(Name="Address")]
    public class Address
    {
        #region XML Attributes

        [XmlAttribute(AttributeName = "AddressITL")]
        public String AddressITL { get; set; }

        [XmlAttribute(AttributeName = "IsPrimaryShippingAddress")]
        public Boolean IsPrimaryShippingAddress { get; set; }

        [XmlAttribute(AttributeName = "IsPrimaryBillingAddress")]
        public Boolean IsPrimaryBillingAddress { get; set; }
        
        #endregion

        #region XML Elements
        
        [XmlElement(ElementName = "StreetName")]
        public String StreetName { get; set; }

        [XmlElement(ElementName = "StreetNumber")]
        public String StreetNumber { get; set; }

        [XmlElement(ElementName = "POBox")]
        public String POBox { get; set; }

        [XmlElement(ElementName = "ZipCode")]
        public String ZipCode { get; set; }

        [XmlElement(ElementName = "City")]
        public String City { get; set; }

        [XmlElement(ElementName = "CountryISO")]
        public String CountryISO { get; set; }

        #endregion
    }

    [DataContract(Name = "OrgUnit")]
    public class OrganizationUnit
    {
        #region XML Attributes

        [XmlAttribute(AttributeName = "OfficeITL")]
        public String OfficeITL { get; set; }

        [XmlAttribute(AttributeName = "ParentOfficeITL")]
        public String ParentOfficeITL { get; set; }

        [XmlAttribute(AttributeName = "ShippingAddressITL")]
        public String ShippingAddressITL { get; set; }

        [XmlAttribute(AttributeName = "BillingAddressITL")]
        public String BillingAddressITL { get; set; }
        
        #endregion

        #region XML Elements

        [XmlElement(ElementName = "Code")]
        public String Code { get; set; }

        [XmlElement(ElementName = "Name")]
        public String Name { get; set; }

        [XmlElement(ElementName = "ContactPhone")]
        public String ContactPhone { get; set; }

        [XmlElement(ElementName = "ContactFax")]
        public String ContactFax { get; set; }

        #endregion
    }
    
}

