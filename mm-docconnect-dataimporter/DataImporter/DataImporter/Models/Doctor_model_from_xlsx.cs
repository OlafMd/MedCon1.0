using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Models
{
    public class Doctor_model_from_xlsx
    {
        public Guid DoctorID { get; set; }
        public string Salutation { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastNAme { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LANR { get; set; }
        public string BSNR { get; set; }
        public string PracticeName { get; set; }
        public Guid PracticeID { get; set; }
        public bool IsUsePracticeBank { get; set; }
        public string AccountHolder { get; set; }
        public string Bic { get; set; }
        public string IBAN { get; set; }
        public string Bank { get; set; }
        public string LoginEmail { get; set; }
        public string inPassword { get; set; }
        public bool isValid { get; set; }
        public string ValidationErrors { get; set; }
        public Guid account_id { get; set; }
    }
}
