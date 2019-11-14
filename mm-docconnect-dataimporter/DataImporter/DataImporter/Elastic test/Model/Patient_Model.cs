using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Elastic_test.Model
{
    public class Patient_Model_xls : IElasticMapper
    {
        public string id { get; set; }
        public string name { get; set; }
        public string LastName { get; set; }
        public string name_with_birthdate { get; set; }
        public DateTime birthday { get; set; }
        public string birthday_string { get; set; }
        public string sex { get; set; }
        public string health_insurance_provider { get; set; }
        public string health_insurance_providerNumber { get; set; }
        public string insurance_id { get; set; }
        public string insurance_status { get; set; }
        public string participation_consent { get; set; }
        public string practice_id { get; set; }
        public string practice_name { get; set; }
        public string practice_bsnr { get; set; }
        public string group_name { get; set; }
        public bool isValid { get; set; }
        public string ValidationErrors { get; set; }
        public bool isPrivatelyInsured { get; set; }
    }
}
