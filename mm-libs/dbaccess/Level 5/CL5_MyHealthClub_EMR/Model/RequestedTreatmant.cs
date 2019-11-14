using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CL5_MyHealthClub_EMR.Model
{
    public class RequestedTreatmant
    {
        [XmlAttribute(AttributeName = "ITL")]
        public String ITL { get; set; }

        [XmlAttribute(AttributeName = "ReferralITL")]
        public String ReferralITL { get; set; }

        [XmlAttribute(AttributeName = "PotentialTreatmantITL")]
        public String PotentialTreatmantITL { get; set; }



        [XmlElement(ElementName = "ProposedDate")]
        public String ProposedDate { get; set; }


        [XmlElement(ElementName = "Name")]
        public String Name { get; set; }

      
    }
}
