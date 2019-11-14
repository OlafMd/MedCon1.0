using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Models
{
    public class ParticipationConsentModel
    {
        public string insurance_id { get; set; }
        public string bsnr { get; set; }
        public DateTime start_date { get; set; }
        public bool isValid { get; set; }
        public string validationMessage { get; set; }
    }


}
