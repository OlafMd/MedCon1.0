using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Models
{
    public class PatientModel
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int sex { get; set; }
        public DateTime birthday { get; set; }
        public Guid health_insurance_provider_id { get; set; }
        public string insurance_id { get; set; }
        public string insurance_status { get; set; }
        public Guid contract_id { get; set; }
        public DateTime issue_date_from { get; set; }

        public DateTime issue_date_to { get; set; }
    }
}
