using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{
    public class Archive_Model : IElasticMapper
    {
        public string id { get; set; }
        public string documentId { get; set; }
        public DateTime filedate { get; set; }
        public string filetime { get; set; }
        public DateTime creationtimestamp { get; set; }
        public string datestring { get; set; }
        public string filetype { get; set; }
        public string recipient { get; set; }
        public string description { get; set; }
        public string group_name { get; set; }
    }
}
