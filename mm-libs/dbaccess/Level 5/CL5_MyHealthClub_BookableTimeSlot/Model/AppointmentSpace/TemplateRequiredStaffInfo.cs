using System;
using System.Collections.Generic;
using System.Linq;
using CL5_MyHealtClub_Slot.Model.Emplyee;

namespace CL5_MyHealtClub_Slot.Model.AppointmentSpace
{
    public class TemplateRequiredStaffInfo
    {
        public Guid ID { get; set; }
        public Staff Staff { get; set; }

        public TemplateRequiredStaffInfo()
        {
            Staff = new Staff();
        }
    }
}
