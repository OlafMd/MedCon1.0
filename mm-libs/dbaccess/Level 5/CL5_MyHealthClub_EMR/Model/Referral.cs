using CL5_MyHealthClub_EMR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace pocdoc.Models.ERMClasses
{
    public class Referral
    {

        [XmlAttribute(AttributeName = "PatientReferralITL")]
        public String PatientReferralITL { get; set; }

        [XmlAttribute(AttributeName = "SuggestedMedicalPractice_RefITL")]
        public String SuggestedMedicalPractice_RefITL { get; set; }

        [XmlAttribute(AttributeName = "PracticeType_RefITL")]
        public String PracticeType_RefITL { get; set; }



        [XmlElement(ElementName = "PracticeTypeName")]
        public String PracticeTypeName { get; set; }

        [XmlElement(ElementName = "SuggestedMedicalPracticeName")]
        public String SuggestedMedicalPracticeName { get; set; }

        [XmlElement(ElementName = "Comment")]
        public String Comment { get; set; }

        [XmlElement(ElementName = "RelevantPatientDiagnosis_RefITL")]
        public String RelevantPatientDiagnosis_RefITL { get; set; }

        [XmlElement(ElementName = "RelevantPatientDiagnosisName")]
        public String RelevantPatientDiagnosisName { get; set; }

        [XmlArray(ElementName = "AttachedPatientDocuments")]
        public List<Document> AttachedPatientDocuments { get; set; }

        [XmlArray(ElementName = "RequestedTreatmants")]
        public List<RequestedTreatmant> RequestedTreatmants { get; set; }

        public Referral()
        {
            AttachedPatientDocuments = new List<Document>();
            RequestedTreatmants = new List<RequestedTreatmant>();
        }

    }
}