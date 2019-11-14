using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL5_MyHealtClub_Slot.Model.AppointmentSpace
{
    public class ReqStaffByAbillity
    {
        public Guid ID { get; set; } 
        public Guid ProfessionID { get; set; }
        public List<Guid> SkillIDs { get; set; }
        public int Count { get; set; }

        public ReqStaffByAbillity()
        {
            Count = 1;
            SkillIDs = new List<Guid>();
        }
    }
}
