using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL5_MyHealtClub_Slot.Model
{
    public class RangeIntersection
    {
        public bool IsIntersects { get; set; }
        public double DurationInSec { get; set; }
        public DateTime IntersectionStart { get; set; }
        public DateTime IntersectionEnd { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public RangeIntersection()
        {
            IntersectionStart = DateTime.MinValue;
            IntersectionEnd = DateTime.MinValue;
        }
    }
}
