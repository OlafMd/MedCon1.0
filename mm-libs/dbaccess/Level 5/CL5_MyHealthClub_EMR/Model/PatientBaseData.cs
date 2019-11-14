using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace pocdoc.Models.ERMClasses
{
    [DataContract(Name = "BaseData")]
    public class PatientBaseData
    {
        [XmlAttribute(AttributeName = "PatientITL")]
        public String PatientITL { get; set; }

        [XmlElement(ElementName = "PatientPicture")]
        public String PatientPicture { get; set; }

        [XmlElement(ElementName = "FirstName")]
        public String FirstName { get; set; }

        [XmlElement(ElementName = "LastName")]
        public String LastName { get; set; }

        [XmlElement(ElementName = "Email")]
        public String Email { get; set; }

        [XmlElement(ElementName = "Gender")]
        public String Gender { get; set; }

        [XmlElement(ElementName = "PhoneNumber")]
        public String PhoneNumber { get; set; }

        [XmlElement(ElementName = "YearOfBirth")]
        public String YearOfBirth { get; set; }

        [XmlElement(ElementName = "DateOfBirth")]
        public String DateOfBirth { get; set; }
    }
}