using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class MultiEditSettlement
    {
        public Guid[] items_for_multiedit { get; set; }
     
        public int status { get; set; }
    }
    public class settlementMultiResult {
        public List<Guid> ids_to_change_list { get; set; }
        public int ids_to_change { get; set; }
        public int ids_changed { get; set; }
        public int status { get; set; }
}
}
