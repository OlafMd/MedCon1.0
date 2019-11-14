using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace pocdoc.Models.ERMClasses
{
    public class Diagnosis
    {
        [XmlAttribute(AttributeName = "PatientDiagnosisITL")]
        public String PatientDiagnosisITL { get; set; }

        [XmlAttribute(AttributeName = "PotentialDiagnosisITL")]
        public String PotentialDiagnosisITL { get; set; }



        [XmlElement(ElementName = "ICD10Code")]
        public String ICD10Code { get; set; }

        [XmlElement(ElementName = "DiagnosisName")]
        public String DiagnosisName { get; set; }

        [XmlElement(ElementName = "DiagnosedOn")]
        public String DiagnosedOn { get; set; }

        [XmlElement(ElementName = "ScheduledExpiryDate")]
        public String ScheduledExpiryDate { get; set; }     

        [XmlElement(ElementName = "IsActive")]
        public Boolean IsActive { get; set; }     

        [XmlElement(ElementName = "IsConfirmed")]
        public Boolean IsConfirmed { get; set; }     

        [XmlElement(ElementName = "IsNegated")]
        public Boolean IsNegated { get; set; }     

        [XmlElement(ElementName = "IsAssumed")]
        public Boolean IsAssumed { get; set; }

        [XmlElement(ElementName = "DeactivatedOnDate")]
        public DateTime DeactivatedOnDate { get; set; }        

        [XmlArray(ElementName = "Observations")]
        public List<Observation> Observations { get; set; }

        [XmlArray(ElementName = "AttachedPatientDocuments")]
        public List<Document> AttachedPatientDocuments { get; set; }

        [XmlArray(ElementName = "Localizations")]
        public List<Localization> Localizations { get; set; }


        public Diagnosis()
        {
            Localizations = new List<Localization>();
            AttachedPatientDocuments = new List<Document>();
            Observations = new List<Observation>();
        }


    }
}