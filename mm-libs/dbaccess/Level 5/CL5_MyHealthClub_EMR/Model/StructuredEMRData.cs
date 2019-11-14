using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using CL5_MyHealthClub_EMR.Model;

namespace pocdoc.Models.ERMClasses
{
    public class StructuredEMRData
    {
        [XmlAttribute(AttributeName = "VersionID")]
        public String VersionID { get; set; }



        [XmlElement(ElementName = "BaseData")]
        public PatientBaseData BaseData { get; set; }



        [XmlArray(ElementName = "Examinations")]
        public List<Examination> Examinations { get; set; }


        [XmlArray(ElementName = "Documents")]
        public List<Document> Documents { get; set; }


        public StructuredEMRData()
        {
            Examinations = new List<Examination>();
            Documents = new List<Document>();
        }
    }
}