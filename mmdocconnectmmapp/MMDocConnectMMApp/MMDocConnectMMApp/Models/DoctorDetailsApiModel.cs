using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MMDocConnectMMAppModels;

namespace MMDocConnectMMApp.Models
{
    public class DoctorDetailApiModel : TransactionalInformation
    {
        public DoctorDetail doctor { get; set; }
    }

}