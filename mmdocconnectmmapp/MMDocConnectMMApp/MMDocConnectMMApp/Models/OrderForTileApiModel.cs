using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectMMAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class OrderForTileApiModel : TransactionalInformation
    {
        public  Order_Model_for_Tile orderForTile { get; set; }
    }

}