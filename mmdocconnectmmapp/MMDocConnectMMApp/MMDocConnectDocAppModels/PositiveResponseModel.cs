using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMApp.Models
{
    public  class PositiveResponseModel
    {
        public string Kasse { get; set; }
        public string PatientInsuranceID { get; set; }
        public string InvoiceNumberHIP { get; set; }
        public int AmountGPOS { get; set; }
    }
}
