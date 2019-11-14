using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL5_MyHealtClub_Slot.Model.Device
{
    public class RequiredDeviceType
    {
        public Guid ID { get; set; }
        public int Count { get; set; }

        public RequiredDeviceType()
        {
            Count = 1;
        }
    }
}
