using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHCWidget_Web.Models.Device;

namespace CL5_MyHealtClub_Slot.Model.Device
{
    public class DeviceCombination
    {
        public Guid ID { get; set; }
        public List<DeviceInstance> Data { get; set; }

        public DeviceCombination()
        {
            ID = Guid.NewGuid();
            Data = new List<DeviceInstance>();
        }
    }
}
