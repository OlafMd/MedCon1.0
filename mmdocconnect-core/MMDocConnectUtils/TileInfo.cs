using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectUtils
{
    public class TileInfo
    {
        public TileInfoModel settlementTile { get; set; }
        public TileInfoModel responseTile { get; set; }
        public TileInfoModel paymentTile { get; set; }
        public TileInfoModel errorCorrectionsTile { get; set; }
        public TileInfoModel casesOnHoldTile { get; set; }
        public TileInfoModel drugOrdersTile { get; set; }
        public TileInfoModel completeReportTile { get; set; }
        public TileInfoModel temporaryDoctorsTile { get; set; }
        public TileInfoModel completeOrdersReportTile { get; set; }

        public TileInfo()
        {
            this.settlementTile = new TileInfoModel();
            this.responseTile = new TileInfoModel();
            this.paymentTile = new TileInfoModel();
            this.errorCorrectionsTile = new TileInfoModel();
            this.drugOrdersTile = new TileInfoModel();
            this.completeReportTile = new TileInfoModel();
            this.casesOnHoldTile = new TileInfoModel();
            this.temporaryDoctorsTile = new TileInfoModel();
            this.completeOrdersReportTile = new TileInfoModel();
        }
    }

    public static class TileInfoExtensionMethods
    {
        public static bool AnyTileDataChanged(this TileInfo source, TileInfo newData)
        {
            return source.casesOnHoldTile.IsDifferentFrom(newData.casesOnHoldTile) || 
                   source.settlementTile.IsDifferentFrom(newData.settlementTile) || 
                   source.completeReportTile.IsDifferentFrom(newData.completeReportTile) || 
                   source.drugOrdersTile.IsDifferentFrom(newData.drugOrdersTile) || 
                   source.errorCorrectionsTile.IsDifferentFrom(newData.errorCorrectionsTile) || 
                   source.paymentTile.IsDifferentFrom(newData.paymentTile) || 
                   source.temporaryDoctorsTile.IsDifferentFrom(newData.temporaryDoctorsTile);

        }

        public static bool IsDifferentFrom(this TileInfoModel source, TileInfoModel newData)
        {
            return source.ammountOfMoney != newData.ammountOfMoney || source.dateOfOldest != newData.dateOfOldest || source.numberOfCases != newData.numberOfCases;
        }

    }
}
