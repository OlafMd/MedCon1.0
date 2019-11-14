using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Case.Entity
{
    public class AftercareHipParameter
    {
        public string HipIk { get; set; }

        public string MinimumTreatmentDate { get; set; }

        public string OverdueDate { get; set; }

        public AftercareHipParameter()
        {
            MinimumTreatmentDate = "0001-01-01";
            OverdueDate = "0001-01-01";        
        }
    }
}
