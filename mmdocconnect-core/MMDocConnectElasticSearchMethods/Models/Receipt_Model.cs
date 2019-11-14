using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{
    public class Receipt_Model : IElasticMapper
    {
        public string id { get; set; }
        public string documentID { get; set; }
        public string doctorID { get; set; }
        public DateTime filedate { get; set; }
        public string filedateString { get; set; }
        public string period { get; set; }
        public DateTime periodDate { get; set; }
        public string amount { get; set; }
        public int amountNo { get; set; }
        public string group_name { get; set; }
        public bool isViewed { get; set; }
    }
}
