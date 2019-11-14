using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace pocdoc.Models.ERMClasses
{
    public class Localization
    {
        [XmlAttribute(AttributeName = "LocalizationITL")]
        public String LocalizationITL { get; set; }

        [XmlElement(ElementName = "Name")]
        public String Name { get; set; }

    }
}