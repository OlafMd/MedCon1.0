using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL5_MyHealtClub_Slot.Model.Emplyee
{
    public class StaffProfession
    {
        public Guid ID { get; set; }
        public bool IsDefault { get; set; }
        public List<Skill> Skills { get; set; }

        public StaffProfession()
        {
            Skills = new List<Skill>();
        }
    }
}
