using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Oct.Entity
{
    public class OctHipParameter
    {
        public string HipIk { get; set; }

        public string MinimumTreatmentDate { get; set; }

        public string OverdueDate { get; set; }

        public string MaxOCTs { get; set; }

        public OctHipParameter()
        {
            MinimumTreatmentDate = "0001-01-01";
            OverdueDate = "0001-01-01";
        }
    }
}
