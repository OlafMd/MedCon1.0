using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;
using CL5_MyHealthClub_EMR.Model;

namespace pocdoc.Models.ERMClasses
{
    [DataContract(Name = "Doctor")]
    public class Doctor
    {
        [XmlAttribute(AttributeName = "ITL")]
        public String ITL { get; set; }

        [XmlAttribute(AttributeName = "PracticeBPITL")]
        public String PracticeBPITL { get; set; }

        [XmlElement(ElementName = "FirstName")]
        public String FirstName { get; set; }

        [XmlElement(ElementName = "LastName")]
        public String LastName { get; set; }

        [XmlElement(ElementName = "Initials")]
        public String Initials { get; set; }

        [XmlElement(ElementName = "Title")]
        public String Title { get; set; }

        [XmlElement(ElementName = "PracticeName")]
        public String PracticeName { get; set; }

        //[XmlElement(ElementName = "Address")]
        //public Address Address { get; set; }        
    }
}