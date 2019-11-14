using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CL6_Lucentis_BillingHistory.Utils
{
    public class DoctorsBilling_Excel
    {

        public string treatmentDate { get; set; }
        public int processNumber { get; set; }
        public string billlingStatus { get; set; }
        public string patientFirstName { get; set; }
        public string patientLastName { get; set; }
        public string patientBirthday { get; set; }
        public string BSNR { get; set; }
        public string mainArticle { get; set; }
        public List<string> diagnosis { get; set; }
        public string GPOS { get; set; }
        public string GPOSText { get; set; }
        public string amount { get; set; }
        public string insuranceState { get; set; }
        public string insuranceNumber { get; set; }
        public string doctorsPractice { get; set; }
        public string doctorsPracticeStreetNameAndNumber { get; set; }
        public string doctorsPracticeCityAndPostalCode { get; set; }
        public string LANR { get; set; }
        public string doctorsFirstName { get; set; }
        public string doctorsLastName { get; set; }
        public string accountHolder { get; set; }
        public string accountNumber { get; set; }
        public string nameOfTheBank { get; set; }
        public string BLZ { get; set; }
        public Guid BIL_BillPositionID { get; set; }
        public Guid DoctorID { get; set; }
        public Guid TreatmentID { get; set; }
        public string selectedMonth { get; set; }
        public string selectedMonthHeder { get; set; }
        public string reportHeader { get; set; }
        public string managmentPaushale { get; set; }
        public double managmentPaushaleDouble { get; set; }
        public string price { get; set; }
        public string summe { get; set; }
        public DoctorsBilling_Excel AdditionalCompensationData { get; set; }
        public DoctorsBilling_Excel BevacizumabData { get; set; }
        public DoctorsBilling_Excel FollowupData { get; set; } //this will be deleted in the future, we are going to make a dynamic table and we will not need this
        // this is just quick fix
        public string followupPrice { get; set; }
    }

    public class TreatmentData
    {
        public String Date { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Birthday { get; set; }
        public String Article { get; set; }
        public List<GPOS> GPOS { get; set; }
        public bool isAOKConfirmedStatus { get; set; }
        public Guid PracticeID { get; set; }
        public String Vorgassnumber { get; set; }
    }

    public class GPOS
    {
        public String Number { get; set; }
        public String Text { get; set; }
        public double Price { get; set; }
        public int ID { get; set; }
    }

    public class WordReportData
    {
        public Guid PracticeID { get; set; }
        public String PracticeName { get; set; }
        public String PracticeAddress { get; set; }
        public String PracticePostalCodeAndCity { get; set; }
        public String SelectedMonth { get; set; }
        public List<TreatmentData> Treatments { get; set; }
    }

    public class TreatmentsByAOKStatusForSubReport
    {
        public List<TreatmentData> Treatments { get; set; }
        public bool isAOKConfirmedTreatments { get; set; }
        public String SelectedMonth { get; set; }
    }
}
