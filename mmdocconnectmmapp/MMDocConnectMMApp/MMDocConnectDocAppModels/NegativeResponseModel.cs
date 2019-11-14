using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppModels
{
    public class NegativeResponseModel
    {
        public string billPositionNumber { get; set; }
        public string message { get; set; }
        public string hipId { get; set; }
        public DateTime transmitionDate { get; set; }
    }
}
