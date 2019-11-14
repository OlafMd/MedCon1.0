using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class CoveredItemModel
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string expanded_name { get; set; }
        public string additional_info { get; set; }
    }
}