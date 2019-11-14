using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectUtils
{
    public class Documents
    {
        public Guid documentID { get; set; }
        public string documentName { get; set; }
        public string mimeType { get; set; }
        public string documentOutputLocation { get; set; }
        public string receiver { get; set; }
        public Guid ContractID { get; set; }
    }
}
