using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using CL5_VacationPlanner_Contract.Atomic.Manipulation;
namespace VacationPlaner.Utils
{

    public enum LeaveRequestCheckStatus { Successful, EndTimeIsLower, ContainsForbidenEvent, AlreadyExistsRequest, MoreDaysThenAllowed, Failed, NotValidDates, InvalidAbsenceReason }

    public class LeaveRequestUtils
    {


        public static double DaysToHoursPeriod(P_L5CT_SECT_1810_WeeklyOfficeHours[] workingDays, double durationInDays)
        {
            if (workingDays.Length == 0)
                return 0;

            double retVal = 0;
            var workingHours = new HoursDays[7];
            var workingDay = new P_L5CT_SECT_1810_WeeklyOfficeHours();
            workingDay = workingDays.Where(x => x.IsMonday).FirstOrDefault();
            if (workingDay != null)
            {
                workingHours[0] = new HoursDays();
                workingHours[0].value = ((Double)(workingDay.TimeTo_InMinutes - workingDay.TimeFrom_InMinutes)) / 60;
                workingHours[0].isWholeDay = workingDay.IsWholeDay;

            }
            workingDay = workingDays.Where(x => x.IsTuesday).FirstOrDefault();
            if (workingDay != null)
            {
                workingHours[1] = new HoursDays();
                workingHours[1].value = ((Double)(workingDay.TimeTo_InMinutes - workingDay.TimeFrom_InMinutes)) / 60;
                workingHours[1].isWholeDay = workingDay.IsWholeDay;
            }
            workingDay = workingDays.Where(x => x.IsWednesday).FirstOrDefault();
            if (workingDay != null)
            {
                workingHours[2] = new HoursDays();
                workingHours[2].value = ((Double)(workingDay.TimeTo_InMinutes - workingDay.TimeFrom_InMinutes)) / 60;
                workingHours[2].isWholeDay = workingDay.IsWholeDay;
            }
            workingDay = workingDays.Where(x => x.IsThursday).FirstOrDefault();
            if (workingDay != null)
            {
                workingHours[3] = new HoursDays();
                workingHours[3].value = ((Double)(workingDay.TimeTo_InMinutes - workingDay.TimeFrom_InMinutes)) / 60;
                workingHours[3].isWholeDay = workingDay.IsWholeDay;
            }
            workingDay = workingDays.Where(x => x.IsFriday).FirstOrDefault();
            if (workingDay != null)
            {
                workingHours[4] = new HoursDays();
                workingHours[4].value = ((Double)(workingDay.TimeTo_InMinutes - workingDay.TimeFrom_InMinutes)) / 60;
                workingHours[4].isWholeDay = workingDay.IsWholeDay;
            }
            workingDay = workingDays.Where(x => x.IsSaturday).FirstOrDefault();
            if (workingDay != null)
            {
                workingHours[5] = new HoursDays();
                workingHours[5].value = ((Double)(workingDay.TimeTo_InMinutes - workingDay.TimeFrom_InMinutes)) / 60;
                workingHours[5].isWholeDay = workingDay.IsWholeDay;
            }
            workingDay = workingDays.Where(x => x.IsSunday).FirstOrDefault();
            if (workingDay != null)
            {
                workingHours[6] = new HoursDays();
                workingHours[6].value = ((Double)(workingDay.TimeTo_InMinutes - workingDay.TimeFrom_InMinutes)) / 60;
                workingHours[6].isWholeDay = workingDay.IsWholeDay;
            }
            var isNegative = false;
            double days;
            if (durationInDays < 0)
            {
                days = -durationInDays;
                isNegative = true;
            }
            else
                days = durationInDays;

            var dayCounter = 0;
            while (days > 0)
            {
                if (workingHours[dayCounter] != null)
                {
                    retVal += (double)workingHours[dayCounter].value;
                    if (workingHours[dayCounter].isWholeDay)
                    {
                        days -= 1;
                    }
                    else
                    {
                        days -= 0.5;
                    }
                }
                dayCounter++;
                if (dayCounter == 7)
                    dayCounter = 0;
            }
            if (isNegative)
                return -retVal;
            else
                return retVal;
        }

        public static double HoursToDaysPeriod(P_L5CT_SECT_1810_WeeklyOfficeHours[] workingDays, double durationInHours)
        {
            if (workingDays.Length == 0)
                return 0;

            var employeeWorkingDays = new HoursDays[7];
            double retVal = 0;
            var workingDay = new P_L5CT_SECT_1810_WeeklyOfficeHours();
            workingDay = workingDays.Where(x => x.IsMonday).FirstOrDefault();
            if (workingDay != null)
            {
                employeeWorkingDays[0] = new HoursDays();
                employeeWorkingDays[0].value = ((Double)(workingDay.TimeTo_InMinutes - workingDay.TimeFrom_InMinutes)) / 60;
                employeeWorkingDays[0].isWholeDay = workingDay.IsWholeDay;
            }
            workingDay = workingDays.Where(x => x.IsTuesday).FirstOrDefault();
            if (workingDay != null)
            {
                employeeWorkingDays[1] = new HoursDays();
                employeeWorkingDays[1].value = ((Double)(workingDay.TimeTo_InMinutes - workingDay.TimeFrom_InMinutes)) / 60;
                employeeWorkingDays[1].isWholeDay = workingDay.IsWholeDay;
            }
            workingDay = workingDays.Where(x => x.IsWednesday).FirstOrDefault();
            if (workingDay != null)
            {
                employeeWorkingDays[2] = new HoursDays();
                employeeWorkingDays[2].value = ((Double)(workingDay.TimeTo_InMinutes - workingDay.TimeFrom_InMinutes)) / 60;
                employeeWorkingDays[2].isWholeDay = workingDay.IsWholeDay;
            }
            workingDay = workingDays.Where(x => x.IsThursday).FirstOrDefault();
            if (workingDay != null)
            {
                employeeWorkingDays[3] = new HoursDays();
                employeeWorkingDays[3].value = ((Double)(workingDay.TimeTo_InMinutes - workingDay.TimeFrom_InMinutes)) / 60;
                employeeWorkingDays[3].isWholeDay = workingDay.IsWholeDay;
            }
            workingDay = workingDays.Where(x => x.IsFriday).FirstOrDefault();
            if (workingDay != null)
            {
                employeeWorkingDays[4] = new HoursDays();
                employeeWorkingDays[4].value = ((Double)(workingDay.TimeTo_InMinutes - workingDay.TimeFrom_InMinutes)) / 60;
                employeeWorkingDays[4].isWholeDay = workingDay.IsWholeDay;
            }
            workingDay = workingDays.Where(x => x.IsSaturday).FirstOrDefault();
            if (workingDay != null)
            {
                employeeWorkingDays[5] = new HoursDays();
                employeeWorkingDays[5].value = ((Double)(workingDay.TimeTo_InMinutes - workingDay.TimeFrom_InMinutes)) / 60;
                employeeWorkingDays[5].isWholeDay = workingDay.IsWholeDay;
            }
            workingDay = workingDays.Where(x => x.IsSunday).FirstOrDefault();
            if (workingDay != null)
            {
                employeeWorkingDays[6] = new HoursDays();
                employeeWorkingDays[6].value = ((Double)(workingDay.TimeTo_InMinutes - workingDay.TimeFrom_InMinutes)) / 60;
                employeeWorkingDays[6].isWholeDay = workingDay.IsWholeDay;
            }
            var isNegative = false;
            double hours;
            if (durationInHours < 0)
            {
                hours = -durationInHours;
                isNegative = true;
            }
            else
                hours = durationInHours;
            var dayCounter = 0;

            while (hours > 0)
            {
                if (employeeWorkingDays[dayCounter] != null)
                {
                    if (employeeWorkingDays[dayCounter].isWholeDay)
                        retVal += 1;
                    else
                        retVal += 0.5;
                    hours -= employeeWorkingDays[dayCounter].value;
                }
                dayCounter++;
                if (dayCounter == 7)
                    dayCounter = 0;
            }
            if (isNegative)
                return -retVal;
            else
                return retVal;
        }


 
    }

    public class LRCheckResult
    {
        public LeaveRequestCheckStatus checkStatus { get; set; }
        public bool isDefinedAllowedDays { get; set; }
        public List<DateTime> errorDaysInfo { get; set; }
        public Guid ifAlreadyExistsRequest_RequestID { get; set; }
    }

    public class OfficeHoursPerDay
    {
        public DayOfWeek dayOfWeek { get; set; }
        public double hours { get; set; }
        public bool isWholeDay { get; set; }
    }

    public class HoursDays
    {
        public double value { get; set; }
        public bool isWholeDay { get; set; }
    }

    public class LeaveRequestDurationResult
    {
        public double duration { get; set; }
        public bool inDays { get; set; }
    }
}