using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace pocdoc.Models.ERMClasses
{
    [DataContract(Name = "Parameter")]
    public class PatientParameter
    {
        [XmlAttribute(AttributeName = "ITL")]
        public String ITL { get; set; }

        [XmlAttribute(AttributeName = "ConfirmedByDoctorITL")]
        public String ConfirmedByDoctorITL { get; set; }

        [XmlAttribute(AttributeName = "ParameterTypeITL")]
        public String ParameterTypeITL { get; set; }



        [XmlElement(ElementName = "Value")]
        public String Value { get; set; }

        [XmlElement(ElementName = "ConfirmedOn")]
        public String ConfirmedOn { get; set; }

        [XmlElement(ElementName = "IsVital")]
        public bool IsVital { get; set; }

        [XmlElement(ElementName = "DateOfEntry")]
        public String DateOfEntry { get; set; }
    }
}