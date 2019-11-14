using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppModels
{
    public class NegativeResponseCaseModel
    {
        public List<NegativeResponseModel> NegativeResponseList { get; set; }
        public string ediMessage { get; set; }
        public string ediName { get; set; }
        public DateTime dateOfTransmitionToHIP { get; set; }
        public NegativeResponseCaseModel()
        {
            this.NegativeResponseList = new List<NegativeResponseModel>();
        }
    }
}
