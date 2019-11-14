using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL5_VacationPlanner_Employees.Atomic.Retrieval;
using CLE_L5_PlannicoMobile_Events.Complex.Retrieval;
using VacationPlannerCore.CustomClasses;


namespace CLE_L6_PlannicoMobile_LeaveRequest.Complex.Retrieval
{
    public static class cls_Get_LeaveRequests_By_ID_extensions
    {
        public static double duration(this L6LR_GLR_ID_1339 leave, L5_EM_GEWI_1628 intervalsActiveContract, L5LR_EV_TSD_1047[] Events, DateTime start, DateTime end, bool inDays)
        {
            double leaveDuration = 0;
            for (DateTime iteratorDate = new DateTime(start.Year,start.Month,start.Day); iteratorDate < end; iteratorDate = iteratorDate.AddDays(1))
            {
                double duration;
                if (intervalsActiveContract.isWorkingOn(iteratorDate.DayOfWeek))
                {
                    //take a duration from interval
                    duration = (inDays ? intervalsActiveContract.dayDuration() : intervalsActiveContract.hoursDuration());

                    DateTimeRange currentRange = new DateTimeRange { Start = iteratorDate, End = new DateTime(iteratorDate.Year, iteratorDate.Month, iteratorDate.Day, end.Hour, end.Minute, end.Second) };
                    //get all events that fit given range (should be only one)
                    var Event = (from e in Events from r in e.repetitions where r.Intersects(currentRange) select e).FirstOrDefault();
                    if (Event != null)
                    {
                        if (Event.EventType_IsHalfWorkingDay)
                            duration *= 0.5;
                        else if (Event.EventType_IsNonWorkingDay)
                            duration = 0;
                    }
                    leaveDuration += duration;
                }
            }
            return leaveDuration;
        }

        public static double duration(this L6LR_GLR_ID_1339 leave, L5_EM_GEWI_1628 intervalsActiveContract, L5LR_EV_TSD_1047[] Events, bool inDays) 
        {
            return duration(leave, intervalsActiveContract, Events, leave.Leave.StartTime, leave.Leave.EndTime, inDays);
        }
    }
}
