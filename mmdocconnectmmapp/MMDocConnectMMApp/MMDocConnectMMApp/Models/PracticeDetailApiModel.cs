
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class PracticeDetailApiModel : TransactionalInformation
    {
        public PracticeDetails practice { get; set; }
    }
}