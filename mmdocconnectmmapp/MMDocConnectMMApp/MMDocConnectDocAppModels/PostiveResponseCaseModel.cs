using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMApp.Models
{
   public class PositioveResponseCaseModel
    {
       public List<PositiveResponseModel> positiveModelL { get; set; }
        public int CasesImportedXLs { get; set; }
        public int CasesImported { get; set; }
    }
}
