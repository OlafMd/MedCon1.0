using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{
    public class PatientDetailViewModelExtended : PatientDetailViewModel
    {
        public bool is_edit_button_visible { get; set; }
        public bool is_aftercare_performed { get; set; }
        public bool is_my_practice { get; set; }
        public bool is_ac_submissible { get; set; }
        public bool is_deleteable { get; set; }
        public string op_date_string { get; set; }
        public bool cancel_disabled { get; set; }
    }
}
