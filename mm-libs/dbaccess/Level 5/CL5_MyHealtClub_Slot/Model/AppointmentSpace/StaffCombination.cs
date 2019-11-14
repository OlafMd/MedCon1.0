using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL5_MyHealtClub_Slot.Model.AppointmentSpace
{
    public class StaffCombination
    {
        public Guid ID { get; set; }
        public List<TemplateRequiredStaffInfo> Data { get; set; }

        public StaffCombination()
        {
            ID = Guid.NewGuid();
            Data = new List<TemplateRequiredStaffInfo>();
        }
    }
}
