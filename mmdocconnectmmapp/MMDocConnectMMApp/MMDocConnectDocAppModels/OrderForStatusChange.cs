using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMApp.Models
{
    public class OrderForStatusChange
    {
        public Guid CaseID {get; set;}
        public Guid OrderID { get; set; }
        public int StatusTo {get; set;}
        public string StatusToStr { get; set; }

    }
    public class OrdersChangeInfo 
    {
  
        public List<OrderForStatusChange> orderForChange {get; set;}
        public int NumberChangeXls {get; set;}
        public int NumberChange {get; set;}
     }
}
