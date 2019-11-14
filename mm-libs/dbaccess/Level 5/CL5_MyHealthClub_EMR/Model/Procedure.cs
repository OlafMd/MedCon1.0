using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace pocdoc.Models.ERMClasses
{
    public class Procedure
    {
        [XmlAttribute(AttributeName = "PotentialProcedure_RefITL")]
        public String PotentialProcedure_RefITL { get; set; }

        [XmlAttribute(AttributeName = "ProcedureITL")]
        public String ProcedureITL { get; set; }

        //[XmlElement(ElementName = "Comment")]
        //public String Comment { get; set; }

        [XmlElement(ElementName = "Name")]
        public String Name { get; set; }


        [XmlElement(ElementName = "Document")]
        public Document Document { get; set; }
    }
}