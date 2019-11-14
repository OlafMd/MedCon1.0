using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
  public  class AppSettings
    {
      public string Email { get; set; }
      public int OrderInterval { get; set; }
      public int ImmediateOrderInterval { get; set; }
      public Guid AdminUser { get; set; }
      public string Password { get; set; }
     }
}
