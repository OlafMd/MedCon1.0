using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL5_APOLogistic_ShippingOrder.Utils
{
    public enum ResultMessage
    {
        SplitShipment_OK,
        SplitShipment_FreeQuantityNotAvailable,
        SplitShipment_ThereIsNoDifferenceBetweenNewAndOldOne
    }

    public class ShipmentHeaderException: Exception
    {
        public ResultMessage ExceptionType { get; set; }

        public ShipmentHeaderException(ResultMessage type)
        {
            ExceptionType = type;
        }
    }
}
