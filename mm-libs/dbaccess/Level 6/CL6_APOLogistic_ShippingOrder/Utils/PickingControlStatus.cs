using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL6_APOLogistic_ShippingOrder.Utils
{
    public enum EPickingControlStatus
    {
        Finished,
        Error_AlreadyFinished,
        Error_InconsistentData
    }
}
