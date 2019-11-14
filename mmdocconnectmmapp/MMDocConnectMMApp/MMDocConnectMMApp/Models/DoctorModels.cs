using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class DoctorModel : TransactionalInformation
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
        public string IBAN { get; set; }
        public string Bank { get; set; }

        public string Account { get; set; }
        public string LoginEmail { get; set; }
        public string inPassword { get; set; }
        public Guid PracticeID { get; set; }
        public string Account_PasswordForEmail { get; set; }
        public bool IsUserPRacticeBank { get; set; }

        public string Type { get; set; }
    }
}