using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL5_MyHealtClub_Slot.Model
{ 
    public class ExceptionTime
    {
        public Guid ID { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public Recurency Recurency { get; set; }

        public ExceptionTime()
        {
            PeriodStart = DateTime.MinValue;
            PeriodEnd = DateTime.MinValue;
            Recurency = Model.Recurency.None;
        }

    }

    public enum Recurency { None, Daily, Weekly, Monthly, Yearly };
}
