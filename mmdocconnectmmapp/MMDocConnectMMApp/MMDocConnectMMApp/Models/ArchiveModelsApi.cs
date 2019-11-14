using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class ArchiveModelsApi : TransactionalInformation
    {
        public List<Archive_Model> ArchItem { get; set; }
    }
}