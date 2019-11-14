using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppModels
{
    public class EmployeeVerificationObject
    {
        public string logged_in_user_email { get; set; }
        public Employee[] employees { get; set; }
    }

    public class Employee {
        public string email { get; set; }
        public string name { get; set; }
    }
}
