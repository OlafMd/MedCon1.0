using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class MultiEditOct
    {
        public IEnumerable<Guid> oct_ids { get; set; }

        public Guid oct_doctor_id { get; set; }

        public string date_of_performed_action { get; set; }
    }

    public class EditOctDoctorParameter
    {
        public Guid patient_id { get; set; }

        public bool is_left_eye { get; set; }

        public Guid oct_doctor_id { get; set; }

        public bool withdraw_oct { get; set; }

        public string oct_withdrawal_date { get; set; }
    }

    public class ErrorCorrectionOctEditParameter
    {
        public Guid id { get; set; }

        public Guid treatment_doctor_id { get; set; }

        public string surgery_date_string { get; set; }

        public bool is_left_eye { get; set; }
    }
}
