using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL5_VacationPlanner_Employees.Atomic.Retrieval
{
    public static class cls_Get_Employee_WorktimeIntervals_extensions
    {
        public static bool isWorkingOn(this L5_EM_GEWI_1628 interval, DayOfWeek dayOfWeek) 
        {
            switch (dayOfWeek)
            {
                case        DayOfWeek.Friday:
                    return interval.IsFriday;
                case        DayOfWeek.Monday:
                    return interval.IsMonday;
                case        DayOfWeek.Saturday:
                    return interval.IsSaturday;
                case        DayOfWeek.Sunday:
                    return interval.IsSunday;
                case        DayOfWeek.Thursday:
                    return interval.IsThursday;
                case        DayOfWeek.Tuesday:
                    return interval.IsTuesday;
                case        DayOfWeek.Wednesday:
                    return interval.IsWednesday;
                default:
                    return false;
            }
        }

        public static double dayDuration(this L5_EM_GEWI_1628 interval) 
        {
            if (!interval.IsWholeDay)
            {
                return 0.5;
            }
            else
            {
                return 1;
            }
        }

        public static double hoursDuration(this L5_EM_GEWI_1628 interval)
        {
            return interval.TimeTo_InMinutes / 60;
        }
    }
}
