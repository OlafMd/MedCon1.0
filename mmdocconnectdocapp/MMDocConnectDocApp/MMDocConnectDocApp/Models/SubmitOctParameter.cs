using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class SubmitOctParameter
    {
        public IEnumerable<Guid> oct_ids { get; set; }

        public string date_of_performed_action { get; set; }

        public Guid authorizing_doctor_id { get; set; }

        public bool is_resubmit { get; set; }
    }
}