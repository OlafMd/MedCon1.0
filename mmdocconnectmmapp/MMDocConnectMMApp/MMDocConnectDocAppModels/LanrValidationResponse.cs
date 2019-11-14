using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppModels
{
    public class LanrValidationResponse
    {
        public bool exists { get; set; }
        public LanrValidationDoctorDetails[] doctors { get; set; }

        public LanrValidationResponse() {
            doctors = new LanrValidationDoctorDetails[] { };
        }
    }

    public class LanrValidationDoctorDetails
    {
        public Guid doctor_id { get; set; }
        public Guid practice_id { get; set; }
        public string doctor_name { get; set; }
        public string practice_name { get; set; }

    }
}
