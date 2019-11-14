using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL3_Events.Atomic.Retrieval;
using VacationPlannerCore.CustomClasses;
using System.Globalization;

namespace CLE_L5_PlannicoMobile_Events.Complex.Retrieval
{
    public static class cls_Get_Events_for_Timespan_Data_extensions
    {
        public static L5LR_EV_TSD_1047 mapDBEventToObject(this L3EV_GSEFT_1647 e, DateTime start, DateTime end)
        {
            L5LR_EV_TSD_1047 rv = new L5LR_EV_TSD_1047();
            
            if (!e.IsRepetitive)
            {
                if (e.intersectsRange(start,end))
                {
                    rv = e.cloneEvent();
                }
                else
                {
                    return null;
                }
            }
            else if (e.IsDaily)
            {
                if (e.R_CronExpression.StartsWith("daily"))
                {
                    rv = e.mapDailyEvent(start, end);
                }
                else
                {
                    rv = e.mapDailyEventWeekdayReocurrance(start, end);
                }
            }
            else if (e.IsWeekly)
            {
                rv = e.mapWeeklyRecurrence(start, end);
            }
            else if (e.IsMonthly)
            {
                if (e.monthlyIsFixed)
                {
                    rv = e.mapMonthlyFixedRecurrence2(start, end);
                }
                else
                {
                    rv = e.mapMonthlyRelativeRecurrence(start, end);
                }
            }
            else if (e.IsYearly)
            {
                if (e.yearlyIsFixed)
                {
                    rv = e.mapYearlyFixedRecurrence(start, end);
                }
                else
                {
                    rv = e.mapYearlyRelativeRecurrence(start, end);
                }
            }
            
            return rv;
        }
        public static List<L5LR_EV_TSD_1047> mapDBEventsToObjects(this List<L3EV_GSEFT_1647> events, DateTime start, DateTime end)
        {
            List<L5LR_EV_TSD_1047> rv = new List<L5LR_EV_TSD_1047>();
            foreach (var e in events)
            {
                var mappedEvent = e.mapDBEventToObject(start, end);
                if (mappedEvent != null)
                {
                    if (mappedEvent.IsRepetitive)
                    {
                        if (mappedEvent.repetitions.Count() > 0)
                        {
                            rv.Add(mappedEvent);
                        }                        
                    }
                    else
                    {
                        rv.Add(mappedEvent);
                    }                    
                }
            }
            return rv;
        }

        #region rules mapping methods
        private static L5LR_EV_TSD_1047 mapDailyEvent(this L3EV_GSEFT_1647 e, DateTime start, DateTime end)
        {
            DateTimeRange givenTimespan = new DateTimeRange(start, end);
            
            L5LR_EV_TSD_1047 rv = e.cloneEvent();
            int daysBetweenTwoEvents = int.Parse(e.R_CronExpression.Split(';')[1]);
            var nextRecurrence = e.StartTime;
            int recurrence = 0;
            List<DateTimeRange> ranges = new List<DateTimeRange>();
            while (true)
            {
                if (nextRecurrence > end)
                {
                    break;
                }
                if (nextRecurrence.Year > 2100)
                    break;
                if (e.repetitionRangesHasEndType_DateTime && nextRecurrence.Date > e.repetitionRangesEnd_ByDate.Date)
                {
                    break;
                }
                else if (e.repetitionRangesHasEndType_Occurrence)
                {
                    recurrence++;
                    if (e.repetitionRangesEnd_AfterSpecifiedOccurrences < recurrence)
                    {
                        break;
                    }
                }
                else if (e.repetitionRangesHasEndType_NoEndDate && nextRecurrence.Year > end.Year + 1)
                {
                    break;
                }
                DateTimeRange range = new DateTimeRange()
                {
                    Start = nextRecurrence,
                    End = nextRecurrence.AddDays(TimeSpan.FromTicks(e.EndTime.Ticks - e.StartTime.Ticks).TotalDays)
                };
                if (givenTimespan.Intersects(range))
                {
                    ranges.Add(range);
                }                
                nextRecurrence = nextRecurrence.AddDays(daysBetweenTwoEvents);
            }
            rv.repetitions = ranges.ToArray();
            return rv;
        }
        private static L5LR_EV_TSD_1047 mapDailyEventWeekdayReocurrance(this L3EV_GSEFT_1647 Event, DateTime start, DateTime end)
        {
            DateTimeRange givenTimespan = new DateTimeRange(start, end);
            L5LR_EV_TSD_1047 rv = Event.cloneEvent();
            List<DateTimeRange> ranges = new List<DateTimeRange>();
            var validDates = new List<DateTimeRange>();
            var nextRecurrence = Event.StartTime;
            validDates = new List<DateTimeRange>();
            var recurrence = 0;
            while (true)
            {
                if (nextRecurrence > end)
                {
                    break;
                }
                if (nextRecurrence.Year > 2100)
                    break;
                if (Event.repetitionRangesHasEndType_DateTime && nextRecurrence.Date > Event.repetitionRangesEnd_ByDate.Date)
                {
                    break;
                }
                else if (Event.repetitionRangesHasEndType_Occurrence)
                {
                    recurrence++;
                    if (Event.repetitionRangesEnd_AfterSpecifiedOccurrences < recurrence)
                    {
                        break;
                    }
                }
                else if (Event.repetitionRangesHasEndType_NoEndDate && nextRecurrence.Year > end.Year + 1)
                {
                    break;
                }
                DateTimeRange range = new DateTimeRange()
                {
                    Start = nextRecurrence,
                    End = nextRecurrence.AddDays(TimeSpan.FromTicks(Event.EndTime.Ticks - Event.StartTime.Ticks).TotalDays)
                };
                if (givenTimespan.Intersects(range))
                {
                    ranges.Add(range);
                }                
                nextRecurrence = nextRecurrence.AddDays(1);
                while (nextRecurrence.DayOfWeek == DayOfWeek.Saturday || nextRecurrence.DayOfWeek == DayOfWeek.Sunday)
                {
                    nextRecurrence = nextRecurrence.AddDays(1);
                }
                rv.repetitions = ranges.ToArray();
            }
            return rv;
        }
        private static L5LR_EV_TSD_1047 mapWeeklyRecurrence(this L3EV_GSEFT_1647 Event, DateTime start, DateTime end)
        {
            DateTimeRange givenTimespan = new DateTimeRange(start, end);
            L5LR_EV_TSD_1047 rv = Event.cloneEvent();
            var validDates = new List<DateTimeRange>();
            var nextRecurrence = Event.StartTime;
            var cronData = Event.R_CronExpression.Split(';');
            var nmbrOfWeeks = int.Parse(cronData[1]);
            var days = cronData[2].Split(',');
            var recurrence = 1;
            var daysInCron = new List<DayOfWeek>();
            for (var i = 0; i < 7; i++)
            {
                if (i == days.Length)
                    break;
                var day = days[i];
                if (day == "MON")
                {
                    daysInCron.Add(DayOfWeek.Monday);
                }
                else if (day == "TUE")
                {
                    daysInCron.Add(DayOfWeek.Tuesday);

                }
                else if (day == "WED")
                {
                    daysInCron.Add(DayOfWeek.Wednesday);

                }
                else if (day == "THU")
                {
                    daysInCron.Add(DayOfWeek.Thursday);
                }
                else if (day == "FRI")
                {
                    daysInCron.Add(DayOfWeek.Friday);
                }
                else if (day == "SAT")
                {
                    daysInCron.Add(DayOfWeek.Saturday);
                }
                else if (day == "SUN")
                {
                    daysInCron.Add(DayOfWeek.Sunday);
                }
            }
            daysInCron = daysInCron.OrderBy(i => i.ToString()).ToList();
            var firstDayInEvent = Event.StartTime.DayOfWeek;
            var lastDayOfWeek = daysInCron.Max();

            var EventDateOcurrences = new List<DateTime>();

            foreach (var dayOfWeek in daysInCron)
            {
                while (true)
                {
                    if (nextRecurrence.Year > 2100)
                        break;
                    if (nextRecurrence.DayOfWeek == dayOfWeek)
                    {
                        EventDateOcurrences.Add(nextRecurrence);
                        break;
                    }
                    else
                    {
                        nextRecurrence = nextRecurrence.AddDays(1);
                        if (EventDateOcurrences.Where(i => i.DayOfWeek == nextRecurrence.DayOfWeek).ToArray().Length != 0)
                        {
                            break;
                        }
                    }
                }
            }
            var isBrake = false;
            while (true)
            {
                foreach (var currentRecurrence in EventDateOcurrences)
                {
                    if (Event.repetitionRangesHasEndType_DateTime && currentRecurrence.Date > Event.repetitionRangesEnd_ByDate.Date)
                    {
                        isBrake = true; break;
                    }
                    else if (Event.repetitionRangesHasEndType_Occurrence)
                    {
                        recurrence++;
                        if (Event.repetitionRangesEnd_AfterSpecifiedOccurrences * nmbrOfWeeks < recurrence)
                        {
                            isBrake = true; break;
                        }
                    }
                    else if (Event.repetitionRangesHasEndType_NoEndDate && currentRecurrence.Year > end.Year + 1)
                    {
                        isBrake = true; break;
                    }

                    var tempRange = new DateTimeRange();
                    tempRange.Start = currentRecurrence;
                    tempRange.End = currentRecurrence.AddDays(TimeSpan.FromTicks(Event.EndTime.Ticks - Event.StartTime.Ticks).TotalDays);
                    if (givenTimespan.Intersects(tempRange))
                    {
                        validDates.Add(tempRange);
                    }
                    recurrence++;
                }
                for (var i = 0; i < EventDateOcurrences.Count; i++)
                {
                    EventDateOcurrences[i] = EventDateOcurrences[i].AddDays(7 * nmbrOfWeeks);
                }
                if (isBrake)
                {
                    break;
                }
            }

            rv.repetitions = validDates.ToArray();
            return rv;
        }

        private static L5LR_EV_TSD_1047 mapMonthlyFixedRecurrence2(this L3EV_GSEFT_1647 Event, DateTime start, DateTime end) 
        {
            DateTimeRange givenTimespan = new DateTimeRange(start, end);
            int recurrence = 0;
            String[] cronData = Event.R_CronExpression.Split(' ');
            int startDayInMonth = int.Parse(cronData[3]);
            int every = int.Parse(cronData[4].Split('/')[1]);

            L5LR_EV_TSD_1047 rv = Event.cloneEvent();
            List<DateTimeRange> repetitions = new List<DateTimeRange>();
            DateTime currentRecurrence = Event.StartTime;
            int number_of_months = 1;
            long eventDuration = (Event.EndTime - Event.StartTime).Ticks;

            while (true)
            {
                try
                {
                    currentRecurrence = Event.StartTime.AddMonths(every * number_of_months);
                    number_of_months++;
                    currentRecurrence = new DateTime(currentRecurrence.Year, currentRecurrence.Month, startDayInMonth, currentRecurrence.Hour, currentRecurrence.Minute, currentRecurrence.Second);
                }
                catch (Exception) {//invalid date
                    continue;
                }

                if (Event.repetitionRangesHasEndType_DateTime && currentRecurrence.Date > Event.repetitionRangesEnd_ByDate.Date)
                {
                    break;
                }
                else if (Event.repetitionRangesHasEndType_Occurrence)
                {
                    recurrence++;
                    if (Event.repetitionRangesEnd_AfterSpecifiedOccurrences < recurrence)
                    {
                        break;
                    }
                }
                else if (Event.repetitionRangesHasEndType_NoEndDate && currentRecurrence.Year > end.Year + 1)
                {
                    break;
                }
                else if (currentRecurrence > end)
                {
                    break;
                }
                var tempRange = new DateTimeRange
                {
                    Start = currentRecurrence,
                    End = new DateTime(currentRecurrence.AddTicks(eventDuration).Ticks)
                };
                if (givenTimespan.Intersects(tempRange))
                {
                    repetitions.Add(tempRange);
                }
            }
            rv.repetitions = repetitions.ToArray();
            return rv;
        }

        private static L5LR_EV_TSD_1047 mapMonthlyFixedRecurrence(this L3EV_GSEFT_1647 Event, DateTime start, DateTime end)
        {
            DateTimeRange givenTimespan = new DateTimeRange(start, end);
            L5LR_EV_TSD_1047 rv = Event.cloneEvent();
            var nextRecurrence = Event.StartTime;
            var validDates = new List<DateTimeRange>();
            var recurrence = 0;
            var cronData = Event.R_CronExpression.Split(' ');

            var startDayInMonth = int.Parse(cronData[3]);
            var every = int.Parse(cronData[4].Split('/')[1]);
            var everyYearCount = every / 12;

            while (true)
            {
                if (nextRecurrence.Year > 2100)
                    break;
                

                var tempRange = new DateTimeRange();
                tempRange.Start = nextRecurrence;
                tempRange.End = nextRecurrence.AddDays(TimeSpan.FromTicks(Event.EndTime.Ticks - Event.StartTime.Ticks).TotalDays);
                if (tempRange.Intersects(givenTimespan))
                {
                    validDates.Add(tempRange);
                }                

                if (nextRecurrence.Month + every % 12 <= 12)
                {
                    try
                    {
                        nextRecurrence = new DateTime(nextRecurrence.Year + everyYearCount, nextRecurrence.Month + every % 12, startDayInMonth);
                    }
                    catch (Exception e)
                    {
                        var x = every + 1;
                        var formats = new string[4];
                        formats[0] = "MM/dd/yyyy";
                        formats[1] = "MM/d/yyyy";
                        formats[2] = "M/d/yyyy";
                        formats[3] = "M/dd/yyyy";
                        var currentDate = nextRecurrence;
                        while (!DateTime.TryParseExact(currentDate.Month + x % 12 + "/" + startDayInMonth + "/" + (currentDate.Year + everyYearCount), formats, new CultureInfo("en"), DateTimeStyles.None, out nextRecurrence))
                        {
                            if (currentDate.Month + x == 12)
                            {
                                currentDate = new DateTime(currentDate.Year + 1, 1, startDayInMonth);
                                x = 0;
                            }
                            x++;
                        }
                    }
                }
                else
                {
                    var currentDate = nextRecurrence;
                    int x = 0;
                    var formats = new string[4];
                    formats[0] = "MM/dd/yyyy";
                    formats[1] = "MM/d/yyyy";
                    formats[2] = "M/d/yyyy";
                    formats[3] = "M/dd/yyyy";
                    while (!DateTime.TryParseExact(currentDate.Month + x % 12 - 12 + "/" + startDayInMonth + "/" + (currentDate.Year + everyYearCount), formats, new CultureInfo("en"), DateTimeStyles.None, out nextRecurrence))
                    {
                        x += every;
                        if (currentDate.Month + x > 12)
                        {
                            int month = (currentDate.Month + x) % every;
                            if (startDayInMonth == 31)
                            {
                                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                                    currentDate = new DateTime(currentDate.Year + 1, month, startDayInMonth);
                                else
                                {
                                    bool isInvalidMonth = true;
                                    int y = 1;
                                    while (isInvalidMonth)
                                    {
                                        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                                        {
                                            currentDate = new DateTime(currentDate.Year + y, month, startDayInMonth);
                                            isInvalidMonth = false;
                                        }
                                        if (month + every > 12)
                                            y++;
                                        month = (month + every) % 12;
                                    }
                                }
                            }
                            else if (startDayInMonth == 30)
                            {
                                if (month != 2)
                                    currentDate = new DateTime(currentDate.Year + 1, month, startDayInMonth);
                                else
                                {
                                    bool isInvalidMonth = true;
                                    int y = 1;
                                    while (isInvalidMonth)
                                    {
                                        if (month != 2)
                                        {
                                            currentDate = new DateTime(currentDate.Year + y, month, startDayInMonth);
                                            isInvalidMonth = false;
                                        }
                                        if (month + every > 12)
                                            y++;
                                        month = (month + every) % 12;
                                    }
                                }
                            }
                            else if (startDayInMonth == 29)
                            {
                                if (month == 2 && (currentDate.Year + 1) / 4 == 0)
                                    currentDate = new DateTime(currentDate.Year + 1, month, startDayInMonth);
                                else
                                {
                                    bool isInvalidMonth = true;
                                    int y = 1;
                                    while (isInvalidMonth)
                                    {
                                        if (month == 2 && (currentDate.Year + y) / 4 == 0)
                                        {
                                            currentDate = new DateTime(currentDate.Year + y, month, startDayInMonth);
                                            isInvalidMonth = false;
                                        }
                                        if (month + every > 12)
                                            y++;
                                        month = (month + every) % 12;
                                    }
                                }
                            }

                        }
                        nextRecurrence = currentDate;
                        break;
                    }
                }
            }
            rv.repetitions = validDates.ToArray();
            return rv;
        }
        private static L5LR_EV_TSD_1047 mapMonthlyRelativeRecurrence(this L3EV_GSEFT_1647 Event, DateTime start, DateTime end)
        {
            DateTimeRange givenTimespan = new DateTimeRange(start, end);
            L5LR_EV_TSD_1047 rv = Event.cloneEvent();
            var nextRecurrence = Event.StartTime;
            var validDates = new List<DateTimeRange>();
            var recurrence = 0;
            var cronData = Event.R_CronExpression.Split(' ');

            var every = int.Parse(cronData[4].Split('/')[1]);
            var evertTemp = every;
            var everyYearCount = evertTemp / 12;

            var relativePart = cronData[5];
            var DayOfWeekPart = relativePart.Split('#')[0];
            var week = int.Parse(relativePart.Split('#')[1]);

            var dayOfWeek = DayOfWeek.Monday;

            if (DayOfWeekPart == "MON")
            {
                dayOfWeek = DayOfWeek.Monday;
            }
            else if (DayOfWeekPart == "TUE")
            {
                dayOfWeek = DayOfWeek.Tuesday;

            }
            else if (DayOfWeekPart == "WED")
            {
                dayOfWeek = DayOfWeek.Wednesday; ;

            }
            else if (DayOfWeekPart == "THU")
            {
                dayOfWeek = DayOfWeek.Thursday;
            }
            else if (DayOfWeekPart == "FRI")
            {
                dayOfWeek = DayOfWeek.Friday;
            }
            else if (DayOfWeekPart == "SAT")
            {
                dayOfWeek = DayOfWeek.Saturday;
            }
            else if (DayOfWeekPart == "SUN")
            {
                dayOfWeek = DayOfWeek.Sunday;
            }

            while (true)
            {
                if (nextRecurrence.Year > 2100)
                    break;
                if (Event.repetitionRangesHasEndType_DateTime && nextRecurrence.Date > Event.repetitionRangesEnd_ByDate.Date)
                {
                    break;
                }
                else if (Event.repetitionRangesHasEndType_Occurrence)
                {
                    recurrence++;
                    if (Event.repetitionRangesEnd_AfterSpecifiedOccurrences < recurrence)
                    {
                        break;
                    }
                }
                else if (Event.repetitionRangesHasEndType_NoEndDate && nextRecurrence.Year > end.Year + 1)
                {
                    break;
                }
                var tempRange = new DateTimeRange();
                tempRange.Start = nextRecurrence;
                tempRange.End = nextRecurrence.AddDays(TimeSpan.FromTicks(Event.EndTime.Ticks - Event.StartTime.Ticks).TotalDays);
                if (givenTimespan.Intersects(tempRange))
                {
                    validDates.Add(tempRange);
                }                

                DateTime tempDate;
                if (nextRecurrence.Month + evertTemp % 12 <= 12)
                {
                    tempDate = new DateTime(nextRecurrence.Year + everyYearCount, nextRecurrence.Month + evertTemp % 12, 1);
                }
                else
                {
                    tempDate = new DateTime(nextRecurrence.Year + everyYearCount + 1, nextRecurrence.Month + evertTemp % 12 - 12, 1);
                }

                var weekNumber = 1;
                while (tempDate.DayOfWeek != dayOfWeek)
                {
                    tempDate = tempDate.AddDays(1);
                }
                while (weekNumber != week)
                {
                    tempDate = tempDate.AddDays(7);
                    weekNumber++;
                    if (tempDate.Month != nextRecurrence.Month + evertTemp % 12)
                    {
                        evertTemp += every;
                        everyYearCount = evertTemp / 12;

                        if (nextRecurrence.Month + evertTemp % 12 <= 12)
                        {
                            tempDate = new DateTime(nextRecurrence.Year + everyYearCount, nextRecurrence.Month + evertTemp % 12, 1);
                        }
                        else
                        {
                            tempDate = new DateTime(nextRecurrence.Year + everyYearCount + 1, nextRecurrence.Month + evertTemp % 12 - 12, 1);
                        }

                        while (tempDate.DayOfWeek != dayOfWeek)
                        {
                            tempDate = tempDate.AddDays(1);
                        }
                        weekNumber = 1;
                    }
                }
                nextRecurrence = tempDate;
            }
            rv.repetitions = validDates.ToArray();
            return rv ;
        }
        private static L5LR_EV_TSD_1047 mapYearlyFixedRecurrence(this L3EV_GSEFT_1647 Event, DateTime start, DateTime end)
        {
            DateTimeRange givenTimespan = new DateTimeRange();
            L5LR_EV_TSD_1047 rv = Event.cloneEvent();
            var validDates = new List<DateTimeRange>();
            var nextRecurrence = Event.StartTime;
            var cronData = Event.R_CronExpression.Split(' ');
            var day = int.Parse(cronData[3]);
            var month = int.Parse(cronData[4]);
            var recurrence = 0;
            while (true)
            {
                if (nextRecurrence.Year > 2100)
                    break;
                if (Event.repetitionRangesHasEndType_DateTime && nextRecurrence.Date > Event.repetitionRangesEnd_ByDate.Date)
                {
                    break;
                }
                else if (Event.repetitionRangesHasEndType_Occurrence)
                {
                    recurrence++;
                    if (Event.repetitionRangesEnd_AfterSpecifiedOccurrences < recurrence)
                    {
                        break;
                    }
                }
                else if (Event.repetitionRangesHasEndType_NoEndDate && nextRecurrence.Year > end.Year + 1)
                {
                    break;
                }
                var tempRange = new DateTimeRange();
                tempRange.Start = nextRecurrence;
                tempRange.End = nextRecurrence.AddDays(TimeSpan.FromTicks(Event.EndTime.Ticks - Event.StartTime.Ticks).TotalDays);
                if (givenTimespan.Intersects(tempRange))
                {
                    validDates.Add(tempRange);
                }                
                if (nextRecurrence.Month == 2 && nextRecurrence.Day == 29)
                {
                    nextRecurrence = new DateTime(nextRecurrence.Year + 4, month, day);
                }
                else
                {
                    nextRecurrence = new DateTime(nextRecurrence.Year + 1, month, day);
                }

            }
            rv.repetitions = validDates.ToArray();
            return rv;
        }
        private static L5LR_EV_TSD_1047 mapYearlyRelativeRecurrence(this L3EV_GSEFT_1647 Event, DateTime start, DateTime end)
        {
            DateTimeRange givenTimespan = new DateTimeRange(start, end);
            L5LR_EV_TSD_1047 rv = Event.cloneEvent();
            var validDates = new List<DateTimeRange>();
            var nextRecurrence = Event.StartTime;
            var cronData = Event.R_CronExpression.Split(' ');
            var relativePart = cronData[5];
            var DayOfWeekPart = relativePart.Split('#')[0];
            var dayOfWeek = DayOfWeek.Monday;
            var week = int.Parse(relativePart.Split('#')[1]);
            var month = int.Parse(cronData[4]);
            var recurrence = 0;
            if (DayOfWeekPart == "MON")
            {
                dayOfWeek = DayOfWeek.Monday;
            }
            else if (DayOfWeekPart == "TUE")
            {
                dayOfWeek = DayOfWeek.Tuesday;

            }
            else if (DayOfWeekPart == "WED")
            {
                dayOfWeek = DayOfWeek.Wednesday; ;

            }
            else if (DayOfWeekPart == "THU")
            {
                dayOfWeek = DayOfWeek.Thursday;
            }
            else if (DayOfWeekPart == "FRI")
            {
                dayOfWeek = DayOfWeek.Friday;
            }
            else if (DayOfWeekPart == "SAT")
            {
                dayOfWeek = DayOfWeek.Saturday;
            }
            else if (DayOfWeekPart == "SUN")
            {
                dayOfWeek = DayOfWeek.Sunday;
            }
            while (true)
            {
                if (nextRecurrence.Year > 2100)
                    break;
                if (Event.repetitionRangesHasEndType_DateTime && nextRecurrence.Date > Event.repetitionRangesEnd_ByDate.Date)
                {
                    break;
                }
                else if (Event.repetitionRangesHasEndType_Occurrence)
                {
                    recurrence++;
                    if (Event.repetitionRangesEnd_AfterSpecifiedOccurrences < recurrence)
                    {
                        break;
                    }
                }
                else if (Event.repetitionRangesHasEndType_NoEndDate && nextRecurrence.Year > end.Year + 1)
                {
                    break;
                }
                var tempRange = new DateTimeRange();
                tempRange.Start = nextRecurrence;
                tempRange.End = nextRecurrence.AddDays(TimeSpan.FromTicks(Event.EndTime.Ticks - Event.StartTime.Ticks).TotalDays);
                if (givenTimespan.Intersects(tempRange))
                {
                    validDates.Add(tempRange);
                }                
                var tempDate = new DateTime(nextRecurrence.Year + 1, month, 1);
                var weekNumber = 1;
                while (tempDate.DayOfWeek != dayOfWeek)
                {
                    tempDate = tempDate.AddDays(1);
                }
                while (weekNumber != week)
                {
                    tempDate = tempDate.AddDays(7);
                    weekNumber++;
                    if (tempDate.Month != month)
                    {
                        tempDate = new DateTime(tempDate.Year + 1, month, 1);
                        while (tempDate.DayOfWeek != dayOfWeek)
                        {
                            tempDate = tempDate.AddDays(1);
                        }
                        weekNumber = 1;
                    }
                }
                nextRecurrence = tempDate;
            }
            rv.repetitions = validDates.ToArray();
            return rv;
        }
        #endregion rules mapping methods
        
        public static bool intersectsRange(this L3EV_GSEFT_1647 e, DateTime start, DateTime end)
        {
            return ((e.StartTime >= start && e.EndTime <= end) ||
                                              (e.StartTime <= start && e.EndTime >= start) ||
                                              (e.StartTime <= end && e.EndTime >= end) ||
                                              (e.StartTime <= start && e.EndTime >= end));
                
        }

        public static L5LR_EV_TSD_1047 cloneEvent(this L3EV_GSEFT_1647 e)
        {
            return new L5LR_EV_TSD_1047
            {
                
                CalendarInstance_RefID = e.CalendarInstance_RefID,
                CMN_CAL_EventID = e.CMN_CAL_EventID,
                EndTime = e.EndTime,
                EventType_ColorCode_Alpha = e.EventType_ColorCode_Alpha,
                EventType_ColorCode_Background = e.EventType_ColorCode_Background,
                EventType_ColorCode_Foreground = e.EventType_ColorCode_Foreground,
                EventType_IsHalfWorkingDay = e.EventType_IsHalfWorkingDay,
                EventType_IsNonWorkingDay = e.EventType_IsNonWorkingDay,
                EventType_IsShowingNotification = e.IsShowingNotification,
                EventType_PriorityOrdinal = e.EventType_PriorityOrdinal,
                InternalEventTypeID = e.InternalEventTypeID,
                IsDaily = e.IsDaily,
                IsRepetitive = e.IsRepetitive,
                IsWeekly = e.IsWeekly,
                IsYearly = e.IsYearly,
                IsMonthly = e.IsMonthly,
                monthlyIfFixed_DayOfMonth = e.monthlyIfFixed_DayOfMonth,
                monthlyIsFixed = e.monthlyIsFixed,
                monthlyRepetition_EveryNumberOfMonths = e.monthlyRepetition_EveryNumberOfMonths,
                R_CronExpression = e.R_CronExpression,
                relativeIsFriday = e.relativeIsFriday,
                relativeIsMonday = e.relativeIsMonday,
                relativeIsSaturday = e.relativeIsSaturday,
                relativeIsSunday = e.relativeIsSunday,
                relativeIsThursday = e.relativeIsThursday,
                relativeIsTuesday = e.relativeIsTuesday,
                relativeIsWednesday = e.relativeIsWednesday,
                relativeIsWeekDay = e.relativeIsWeekDay,
                relativeIsWeekendDay = e.relativeIsWeekendDay,
                relativeOrdinal = e.relativeOrdinal,
                
                repetitionRangesCMN_CAL_Repetition_RangeID = e.repetitionRangesCMN_CAL_Repetition_RangeID,
                StartTime = e.StartTime,
                StructureEvent_Name = e.StructureEvent_Name,
                weeklyHasRepeatingOn_Fridays = e.weeklyHasRepeatingOn_Fridays,
                weeklyHasRepeatingOn_Mondays = e.weeklyHasRepeatingOn_Mondays,
                weeklyHasRepeatingOn_Saturdays = e.weeklyHasRepeatingOn_Saturdays,
                weeklyHasRepeatingOn_Sundays = e.weeklyHasRepeatingOn_Sundays,
                weeklyHasRepeatingOn_Thursdays = e.weeklyHasRepeatingOn_Thursdays,
                weeklyHasRepeatingOn_Tuesdays = e.weeklyHasRepeatingOn_Tuesdays,
                weeklyHasRepeatingOn_Wednesdays = e.weeklyHasRepeatingOn_Wednesdays,
                weeklyRepetition_EveryNumberOfWeeks = e.weeklyRepetition_EveryNumberOfWeeks,
                yearlyIfFixed_DayOfMonth = e.yearlyIfFixed_DayOfMonth,
                yearlyIsFixed = e.yearlyIsFixed,
                yearlyRelativeIsFriday = e.yearlyRelativeIsFriday,
                yearlyRelativeIsMonday = e.yearlyRelativeIsMonday,
                yearlyRelativeIsSaturday = e.yearlyRelativeIsSaturday,
                yearlyRelativeIsSunday = e.yearlyRelativeIsSunday,
                yearlyRelativeIsThursday = e.yearlyRelativeIsThursday,
                yearlyRelativeIsTuesday = e.yearlyRelativeIsTuesday,
                yearlyRelativeIsWednesday = e.yearlyRelativeIsWednesday,
                yearlyRelativeIsWeekDay = e.yearlyRelativeIsWeekDay,
                yearlyRelativeIsWeekendDay = e.yearlyRelativeIsWeekendDay,
                yearlyRelativeOrdinal = e.yearlyRelativeOrdinal,
                yearlyRepetition_Month = e.yearlyRepetition_Month,
                repetitions = new DateTimeRange[0],
                forbiddenLeaveTypes = e.forbidenLeaveTypes

            };
        }
    }
}
