using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL5_MyHealtClub_Slot.Model.AppointmentSpace;
using CL5_MyHealtClub_Slot.Model.Device;

namespace CL5_MyHealtClub_Slot.Model
{
    public class ResourceCombination
    {
        public Guid CombinationID { get; set; }
        public Guid OfficeID { get; set; }
        public Guid AppointmentTypeID { get; set; }
        public bool IsDeviceNeeded { get; set; }

        public StaffCombination StaffCombination { get; set; }
        public DeviceCombination DeviceInstancesCombination { get; set; }

        public List<RangeIntersection> TimeIntersections { get; set; }

        public ResourceCombination()
        {
            CombinationID = Guid.NewGuid();
            TimeIntersections = new List<RangeIntersection>();
        }
    }
}
