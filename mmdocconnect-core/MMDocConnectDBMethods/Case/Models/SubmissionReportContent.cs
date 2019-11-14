using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MMDocConnectDBMethods.Case.Models
{
    [Serializable(), XmlRoot("SubmissionReportContent")]
    public class SubmissionReportContent
    {
        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("FirstParagraph")]
        public string FirstParagraph { get; set; }

        [XmlElement("Patient")]
        public string Patient { get; set; }

        [XmlElement("SecondParagraph")]
        public string SecondParagraph { get; set; }

        [XmlElement("SecondParagraphNoConsent")]
        public string SecondParagraphNoConsent { get; set; }

        [XmlElement("Diagnose")]
        public string Diagnose { get; set; }

        [XmlElement("ConfirmedDiagnose")]
        public string ConfirmedDiagnose { get; set; }

        [XmlElement("Localization")]
        public string Localization { get; set; }

        [XmlElement("CaseType")]
        public string CaseType { get; set; }

        [XmlElement("Drug")]
        public string Drug { get; set; }

        [XmlElement("TreatmentDate")]
        public string TreatmentDate { get; set; }

        [XmlElement("TreatmentYear")]
        public string TreatmentYear { get; set; }

        [XmlElement("TreatmentDoctor")]
        public string TreatmentDoctor { get; set; }

        [XmlElement("Practice")]
        public string Practice { get; set; }

        [XmlElement("OpDoctor")]
        public string OpDoctor { get; set; }

        [XmlElement("OpPractice")]
        public string OpPractice { get; set; }

        [XmlElement("Footer")]
        public string Footer { get; set; }

        [XmlElement("OpDate")]
        public string OpDate { get; set; }

        [XmlElement("ReferenceNumber")]
        public string ReferenceNumber { get; set; }

        [XmlElement("PatientID")]
        public string PatientID { get; set; }                
    }
}
