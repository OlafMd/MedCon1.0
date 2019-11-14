using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL5_MyHealtClub_Slot.Model.AppointmentSpace
{
    class Appointment
    {
        public Guid ID { get; set; }
        public List<Guid> StaffIDs { get; set; }
        public List<Guid> DeviceInstanceIDs { get; set; }
        public DateTime AppointmentStart { get; set; }
        public DateTime AppointmentEnd { get; set; }


        public Appointment()
        {
            StaffIDs = new List<Guid>();
            DeviceInstanceIDs = new List<Guid>();
        }
    }


}
