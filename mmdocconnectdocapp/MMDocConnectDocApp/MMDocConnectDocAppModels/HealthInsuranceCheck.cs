using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class HealthInsuranceCheck
    {
        public bool isValid { get; set; }
      
        public List<warning_message> warning_messages { get; set; }

        public HealthInsuranceCheck()
        {
            isValid = true;
        }

    }

    public class warning_message
    {
        public string messaga { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}
