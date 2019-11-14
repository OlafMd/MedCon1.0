using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMApp.Models
{
    public class Practice
    {
        public Guid PracticeID { get; set; }
        public string PracticeName { get; set; }
        public string BSNR { get; set; }
        public string Street { get; set; }
        public string No { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string MainEmail { get; set; }
        public string MainPhone { get; set; }
        public string Fax { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AccountHolder { get; set; }
        public string Bic { get; set; }
        public string IBAN { get; set; }
        public string Bank { get; set; }
        public string PracticeAccount { get; set; }
        public string LoginEmail { get; set; }
        public string inPassword { get; set; }

        public bool IsSurgeryPractice { get; set; }
        public bool IsOrderDrugs { get; set; }
        public string DefaultShippingDateOffset { get; set; }
        public bool IsOnlyLabelRequired { get; set; }
        public bool isWaiveServiceFee { get; set; }
        public bool IsAccountDeactivated { get; set; }
        public bool Change_Doctor_Account_Statuses { get; set; }
        public bool ShouldDownloadReportUponSubmission { get; set; }

        public bool PressEnterToSearch { get; set; }

        public string DefaultPharmacy { get; set; }
        public bool IsQuickOrderActive { get; set; }
        public string DeliveryDateFrom { get; set; }
        public string DeliveryDateTo { get; set; }
        public bool UseGracePeriod { get; set; }
    }


    public class Doctor
    {
        public Guid DoctorID { get; set; }
        public string Salutation { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastNAme { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LANR { get; set; }
        public string Practice { get; set; }
        public string BankAccount { get; set; }
        public string AccountHolder { get; set; }
        public string Bic { get; set; }
        public string Iban { get; set; }
        public string Bank { get; set; }
        public string LoginEmail { get; set; }
        public string inPassword { get; set; }
        public Guid PracticeID { get; set; }
        public string Account_PasswordForEmail { get; set; }
        public bool IsUserPRacticeBank { get; set; }
        public bool IsAccountDeactivated { get; set; }
        public Guid TemporaryDoctorID { get; set; }
        public string CustomerNumber { get; set; }
        public bool IsCertificatedForOCT { get; set; }
        public string OctValidFrom { get; set; }
    }

    public class LoginEmail
    {
        public string loginEmailValue { get; set; }
    }
}
