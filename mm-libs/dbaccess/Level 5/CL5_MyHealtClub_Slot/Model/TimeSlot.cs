using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL5_MyHealtClub_Slot.Model
{
    class TimeSlot
    {
        public Guid ID { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public bool IsWebBookable { get; set; }
        public List<ResourceCombination> ResourceCombination { get; set; }

        public TimeSlot()
        {
            ResourceCombination = new List<ResourceCombination>();
        }
    }
}
