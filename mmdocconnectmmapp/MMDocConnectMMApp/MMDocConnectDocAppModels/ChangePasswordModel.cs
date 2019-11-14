using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMApp.Models
{
   public class ChangePasswordModel
    {
        public Guid ID { get; set; }
        public String password { get; set; }
        public String type { get; set; }
    }
}
