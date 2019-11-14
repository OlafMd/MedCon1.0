using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using pocdoc.Models.ERMClasses;

namespace CL5_MyHealthClub_EMR.Model
{
    public class PrescriptionHeader
    {

        [XmlAttribute(AttributeName = "PrescriptionITL")]
        public String PrescriptionITL { get; set; }

        [XmlAttribute(AttributeName = "ExaminationITL")]
        public String ExaminationITL { get; set; }

        [XmlElement(ElementName = "PrescribedOn")]
        public String PrescribedOn { get; set; }

        [XmlElement(ElementName = "Doctor")]
        public Doctor Doctor { get; set; }


        [XmlArray(ElementName = "PrescriptionPositions")]
        public List<PrescriptionPosition> PrescriptionPositions { get; set; }


        public PrescriptionHeader()
        {
            PrescriptionPositions = new List<PrescriptionPosition>();
        }
    }
}
