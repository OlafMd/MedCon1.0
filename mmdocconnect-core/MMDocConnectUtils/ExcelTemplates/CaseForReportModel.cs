using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectUtils.ExcelTemplates
{
    public class CaseForReportModel
    {
        public Guid CaseID { get; set; }
        public Guid ContractID { get; set; }
        public string HIP_IK { get; set; }
        public string HIP { get; set; }
        public string PatientInsuranceNumber { get; set; }
        public string PatientStatusNumber { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public DateTime PatientBirthday { get; set; }
        public DateTime PatientParticipationConsentValidUntil { get; set; }
        public int CaseNumber { get; set; }
        public string Drug { get; set; }
        public string Diagnose { get; set; }
        public string DiagnoseCode { get; set; }
        public string Localization { get; set; }
        public int TreatmentCount { get; set; }
        public string GPOS { get; set; }
        public DateTime TreatmentDay { get; set; }
        public DateTime SurgeryDateForThisCase { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime DateOfCurrentStatus { get; set; }
        public string PreCurrentStatus { get; set; }
        public DateTime DateOfPreCurrentStatus { get; set; }
        public int InvoiceNumberForTheHIP { get; set; }
        public double AmountForThisGPOS { get; set; }
        public string NumberOfNegativeTry { get; set; }
        public DateTime DateOfTheSubmissionToTheHIP { get; set; }
        public DateTime FeedBackOfTheHIP { get; set; }
        public DateTime PaymentDate { get; set; }
        public string DrugOrdered { get; set; }
        public string NoFee { get; set; }
        public string InvoiceToPractice { get; set; }
        public string OnlyLabelRequired { get; set; }
        public string ManagementFee { get; set; }
        public string BSNR { get; set; }
        public string PracticeName { get; set; }
        public string LANR { get; set; }
        public string DocName { get; set; }
        public string BankAccountHolder { get; set; }
        public string BankName { get; set; }
        public string IBAN { get; set; }
        public string BIC { get; set; }
        public int PatientGender { get; set; }
        public string PatientSalutation { get; set; }
        public string CaseType { get; set; }
        public string CodeForType { get; set; }
        public Guid GposID { get; set; }
        public Guid TransmitionStatusID { get; set; }
        public Guid UniqueID { get; set; }
        public int FsStatus { get; set; }
        public bool PositionWasPaid { get; set; }
        public Guid DoctorID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string DoctorTitle { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorEmail { get; set; }

        public int CurrentFsStatusCode { get; set; }
    }
}
