using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class Preexamination
    {
        public bool is_left_eye { get; set; }
        public string password { get; set; }
        public Guid patient_id { get; set; }
        public Guid doctor_id { get; set; }
        public string date { get; set; }
        public bool shouldSubmit { get; set; }
        public bool isResubmit { get; set; }
        public Guid case_id { get; set; }
    }
}
