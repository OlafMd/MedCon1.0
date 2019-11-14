using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace pocdoc.Models.ERMClasses
{
    public class Observation
    {
        //[XmlAttribute(AttributeName = "PotentialObservationITL")]
        //public String PotentialObservationITL { get; set; }

        [XmlAttribute(AttributeName = "MadeObservationITL")]
        public String MadeObservationITL { get; set; }

        [XmlElement(ElementName = "Text")]
        public String Text { get; set; }

        [XmlArray(ElementName = "AttachedPatientDocuments")]
        public List<Document> AttachedPatientDocuments { get; set; }

        public Observation()
        {
            AttachedPatientDocuments = new List<Document>();
        }
    }
}