using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class ContractParticipatingDoctorModel
    {
        public Guid doctor_id { get; set; }
        public Guid id { get; set; }
        public string name { get; set; }
        public string lanr { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string sortable_name { get; set; }
        public string practice { get; set; }
        public string expanded_name { get; set; }
        public bool is_consent_active { get; set; }
        public bool is_participating { get; set; }
        public string consent_date { get; set; }

        // these fields are used for view only
        public string consent_start_date { get; set; }
        public string consent_end_date { get; set; }
        public DateTime consent_start_date_datetime { get; set; }
        public DateTime consent_end_date_datetime { get; set; }

        public ContractParticipatingDoctorModel()
        {
            is_participating = true;
        }
    }
}