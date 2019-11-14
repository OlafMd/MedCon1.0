using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class ErrorCorrectionAftercare
    {
        public Guid id { get; set; }

        public Guid aftercare_doctor_practice_id { get; set; }

        public string surgery_date_string { get; set; }
    }
}
