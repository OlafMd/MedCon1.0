using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHCWidget_Web.Models.Backoffice
{
    public class Availability
    {
        public Guid ID { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }

}