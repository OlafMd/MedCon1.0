using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using pocdoc.Models.ERMClasses;

namespace CL5_MyHealthClub_EMR.Model
{
    public class PrescriptionPosition
    {
        [XmlAttribute(AttributeName = "PrescriptionPositionITL")]
        public String PrescriptionPositionITL { get; set; }

        [XmlAttribute(AttributeName = "PatientMedicationITL")]
        public String PatientMedicationITL { get; set; }
    }
}
