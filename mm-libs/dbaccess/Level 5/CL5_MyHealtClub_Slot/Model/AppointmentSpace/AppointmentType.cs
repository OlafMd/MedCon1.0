using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL5_MyHealtClub_Slot.Model.Device;

namespace CL5_MyHealtClub_Slot.Model.AppointmentSpace
{
    public class AppointmentType
    {
        public Guid ID { get; set; }
        public int DurationInSec { get; set; }

        public List<ReqStaffByName> RequiredStaff { get; set; }
        public List<ReqStaffByAbillity> ReqStaffByAbillities { get; set; }
        public List<RequiredDeviceType> RequiredDeviceTypes { get; set; }

        public AppointmentType()
        {
            RequiredStaff = new List<ReqStaffByName>();
            ReqStaffByAbillities = new List<ReqStaffByAbillity>();
            RequiredDeviceTypes = new List<RequiredDeviceType>();
        }
    }
}
