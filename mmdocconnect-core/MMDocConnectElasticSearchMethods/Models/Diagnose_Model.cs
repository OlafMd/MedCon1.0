using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{
    public class Diagnose_Model : IElasticMapper
    {
        public string id { get; set; }
        public string icd10 { get; set; }
        public string name { get; set; }
    }
}
