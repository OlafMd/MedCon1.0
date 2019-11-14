using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectUtils
{
    public class TileInfoModel
    {
        public string ammountOfMoney { get; set; }
        public string numberOfCases { get; set; }
        public string dateOfOldest { get; set; }

        public TileInfoModel()
        {
            this.ammountOfMoney = "0";
            this.numberOfCases = "0";
            this.dateOfOldest = "-";
        }
    }
}
