using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using CL5_MyHealthClub_EMR.Model;

namespace pocdoc.Models.ERMClasses
{
    public class Examination
    {
        [XmlAttribute(AttributeName = "ITL")]
        public String ITL { get; set; }

        //[XmlElement(ElementName = "IsPlanned")]
        //public bool IsPlanned { get; set; }

        //[XmlElement(ElementName = "IsPlannedDate")]
        //public String IsPlannedDate { get; set; }

        //[XmlElement(ElementName = "IsPerformedExternally")]
        //public bool IsPerformedExternally { get; set; }

        [XmlElement(ElementName = "Date")]
        public String Date { get; set; }

        //[XmlElement(ElementName = "PerformingDoctor_RefID")]
        //public String PerformingDoctor_RefID { get; set; }


        [XmlArray(ElementName = "TreatingDoctors")]
        public List<Doctor> TreatingDoctors { get; set; }

        [XmlArray(ElementName = "PatientParameters")]
        public List<PatientParameter> PatientParameters { get; set; }

        [XmlArray(ElementName = "Diagnoses")]
        public List<Diagnosis> Diagnoses { get; set; }

        [XmlArray(ElementName = "Medications")]
        public List<Medication> Medications { get; set; }

        [XmlArray(ElementName = "Procedures")]
        public List<Procedure> Procedures { get; set; }

        [XmlArray(ElementName = "Referrals")]
        public List<Referral> Referrals { get; set; }

        [XmlArray(ElementName = "PrescriptionHeaders")]
        public List<PrescriptionHeader> PrescriptionHeaders { get; set; }

        public Examination()
        {
            TreatingDoctors = new List<Doctor>();
            PatientParameters = new List<PatientParameter>();
            Diagnoses = new List<Diagnosis>();
            Medications = new List<Medication>();
            Procedures = new List<Procedure>();
            Referrals = new List<Referral>();
            PrescriptionHeaders = new List<PrescriptionHeader>();
        }
    }
}