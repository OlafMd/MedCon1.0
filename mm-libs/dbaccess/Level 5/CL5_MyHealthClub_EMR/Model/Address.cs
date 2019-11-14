using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CL5_MyHealthClub_EMR.Model
{
    public class Address
    {

        [XmlElement(ElementName = "StreetName")]
        public String StreetName { get; set; }

        [XmlElement(ElementName = "StreetNumber")]
        public String StreetNumber { get; set; }

        [XmlElement(ElementName = "CityName")]
        public String CityName { get; set; }
    }
}
