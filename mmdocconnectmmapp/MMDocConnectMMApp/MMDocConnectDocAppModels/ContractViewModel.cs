using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class ContractViewModel
    {
        public Guid contract_id { get; set; }
        public string contract_name { get; set; }
        public string contract_valid_from { get; set; }
        public string contract_valid_through { get; set; }
        public string hip_names { get; set; }
        public string characteristic_id { get; set; }
        public int next_edifact_number { get; set; }
        public string edifact_type { get; set; }
        public bool encrypt_edifact { get; set; }
        public string contract_type { get; set; }
        public string ik_number { get; set; }
        public string message_type { get; set; }
        public bool merger_for_all_hips { get; set; }
        public bool use_k_for_correction { get; set; }
        public IEnumerable<GposDetailModel> gpos_data { get; set; }
        public IEnumerable<CoveredItemModel> covered_drugs { get; set; }
        public IEnumerable<CoveredItemModel> covered_diagnoses { get; set; }
        public IEnumerable<CoveredItemModel> covered_insurance_companies { get; set; }
        public IEnumerable<ContractParticipatingDoctorModel> participating_doctors { get; set; }
        public ContractDueDates contract_due_dates { get; set; }
    }
}