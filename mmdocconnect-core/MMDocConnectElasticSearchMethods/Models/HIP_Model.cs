using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{
    public class HIP_Model : IElasticMapper
    {
        public string id { get; set; }
        public string ik_number { get; set; }
        public string name { get; set; }
    }
}
