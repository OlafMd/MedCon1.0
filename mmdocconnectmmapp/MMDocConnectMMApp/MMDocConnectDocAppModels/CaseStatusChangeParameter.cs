using MMDocConnectMMAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class CaseStatusChangeParameter
    {
        public Guid[] selected_action_ids { get; set; }
        public Guid[] deselected_action_ids { get; set; }
        public bool all_selected { get; set; }
        public string password { get; set; }
        public bool? is_management_fee_waived { get; set; }
        public int? case_status { get; set; }
        public string case_status_ground { get; set; }
        public FilterObject filter_by { get; set; }
        public bool is_filtered { get; set; }
        public Guid[] eligible_cases_for_status_edit { get; set; }
    }

}