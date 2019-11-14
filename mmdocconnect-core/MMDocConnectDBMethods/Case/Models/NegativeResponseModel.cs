using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDBMethods.Case.Models
{
    public class NegativeResponseModel
    {
        public Guid caseID { get; set; }
        public string type { get; set; }
        public Guid plannedActionID { get; set; }
    }
}
