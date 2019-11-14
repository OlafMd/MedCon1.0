using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class ContractDueDates
    {
        public ContractDueDatesModel participation_consent_duration { get; set; }
        public ContractDueDatesModel number_of_days_between_surgery_and_aftercare { get; set; }
        public ContractDueDatesModel number_of_days_between_surgery_and_settlement_claim { get; set; }
        public ContractDueDatesModel number_of_days_between_submission_to_hip_and_reply { get; set; }
        public ContractDueDatesModel number_of_days_between_response_and_payment { get; set; }
        public ContractDueDatesModel number_of_days_between_hip_response_and_rejection { get; set; }

        public ContractDueDatesModel number_of_max_preexaminations_value { get; set; }
        public ContractDueDatesModel number_of_max_preexaminations_days { get; set; }

        public ContractDueDatesModel oct_max_number_of_days_before_op { get; set; }
        public ContractDueDatesModel op_renews_patient_consent { get; set; }
        public ContractDueDatesModel use_settlement_year { get; set; }
        public ContractDueDatesModel doctor_needs_certification { get; set; }
    }

    public class ContractDueDatesModel
    {
        public Guid id { get; set; }
        public bool active { get; set; }
        public string value { get; set; }
    }
}