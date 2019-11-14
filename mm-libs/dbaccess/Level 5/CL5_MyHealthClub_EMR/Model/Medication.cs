using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace pocdoc.Models.ERMClasses
{
    public class Medication
    {
        [XmlAttribute(AttributeName = "Product_RefITL")]
        public String Product_RefITL { get; set; }

        [XmlAttribute(AttributeName = "Substance_RefITL")]
        public String Substance_RefITL { get; set; }

        [XmlAttribute(AttributeName = "PatientMedicationITL")]
        public String PatientMedicationITL { get; set; }

        [XmlAttribute(AttributeName = "Diagnosis_RefITL")]
        public String Diagnosis_RefITL { get; set; }


        [XmlElement(ElementName = "IsActive")]
        public bool IsActive { get; set; }

        [XmlElement(ElementName = "ActiveUntil")]
        public String ActiveUntil { get; set; }

        [XmlElement(ElementName = "IsSubstance")]
        public bool IsSubstance { get; set; }

        [XmlElement(ElementName = "IsHealthCareProduct")]
        public bool IsHealthCareProduct { get; set; }

        [XmlElement(ElementName = "Dosage")]
        public String Dosage { get; set; }

        [XmlElement(ElementName = "DosageForm")]
        public String DosageForm { get; set; }

        [XmlElement(ElementName = "Strength")]
        public String Strength { get; set; }

        [XmlElement(ElementName = "StrengthUnit")]
        public String StrengthUnit { get; set; }

        [XmlElement(ElementName = "SpecialInstructions")]
        public String SpecialInstructions { get; set; }

        [XmlElement(ElementName = "DurationInDays")]
        public String DurationInDays { get; set; }

        [XmlElement(ElementName = "Name")]
        public String Name { get; set; }
    }
}