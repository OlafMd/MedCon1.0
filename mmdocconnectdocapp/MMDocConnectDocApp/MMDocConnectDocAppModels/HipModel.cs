using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class HipModel
    {
        public Guid id { get; set; }
        public string display_name { get; set; }
        public string secondary_display_name { get; set; }
        public string name { get; set; }
    }
}
