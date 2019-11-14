using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
   public class User
    {
        public Guid id { get; set; }
        public String Salutation { get; set; }
        public String Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool isAdmin { get; set; }
        public bool ReceiveNotification { get; set; }
        public bool isDeactivated { get; set; }
        public string LoginEmail { get; set; }
        public string inPassword { get; set; }
    }
}
