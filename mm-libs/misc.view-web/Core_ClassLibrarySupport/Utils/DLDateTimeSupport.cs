using System;

namespace Core_ClassLibrarySupport.DanuTask
{
    public class DLDateTimeSupport
    {
        private static Double WORKINGTIME_START = 9;
        private static Double WORKINGHOURS_PER_DAY = 8;
        private static Double WORKINGHOURS_PER_WEEK = 40;

        public static String Convert_DoubleHours_to_HourMinutes2(Double hours)
        {
            String result = "";

            TimeSpan ts = TimeSpan.FromHours(hours);
            if (ts.Hours != 0)
            {
                result += (ts.Days*24 + ts.Hours) + " hrs, ";
                result += ts.Minutes + " min";
            }
            else if (ts.Minutes != 0)
            {
                result += ts.Minutes + "min";
            }
            else
            {
                result = "-";
            }

            return result;
        }

        public static String ConvertDateToString(DateTime dateTime,String format)
        {
            return dateTime.ToString(format);
        }

        public static long CalculateWorkingMinutes(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                return 0;

            return Convert.ToInt64(endDate.Subtract(startDate).TotalMinutes);

        }

        public static DateTime GetFirstWorkDateTime()
        {
            DateTime currentTime = DateTime.Now;
            DateTime returnValue = DateTime.Now;

            if (currentTime.Hour < WORKINGTIME_START || currentTime.Hour > (WORKINGTIME_START + WORKINGHOURS_PER_DAY))
            {
                returnValue = currentTime.Date.AddDays(1);
                returnValue = returnValue.AddHours(WORKINGTIME_START);

                if (returnValue.DayOfWeek == DayOfWeek.Saturday)
                {
                    returnValue.AddDays(2);

                }
                else if (returnValue.DayOfWeek == DayOfWeek.Sunday)
                {
                    returnValue.AddDays(1);
                }
            }
            return returnValue;
        }

        public static DateTime AddWorkingMinutesToDate(DateTime date, long minutes)
        {
            Double hours = minutes / 60;

            DateTime returnDate = date;

            Double todayWorkingHours = date.Hour - WORKINGTIME_START;
            hours += todayWorkingHours;
            returnDate = returnDate.AddHours(-todayWorkingHours);

            Double completeWeeksToAdd = Math.Floor(hours / WORKINGHOURS_PER_WEEK);
            Double remainingHours = hours % WORKINGHOURS_PER_WEEK;
            returnDate = returnDate.AddDays(completeWeeksToAdd * 7);

            Double completeDaysToAdd = Math.Floor(remainingHours / WORKINGHOURS_PER_DAY);
            remainingHours = remainingHours % WORKINGHOURS_PER_DAY;
            while (completeDaysToAdd > 0)
            {
                returnDate = returnDate.AddDays(1);
                if (returnDate.DayOfWeek != DayOfWeek.Saturday && returnDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    completeDaysToAdd--;
                }
            }

            returnDate = returnDate.AddHours(remainingHours);

            return returnDate;
        }

        public static DateTime SubstractWorkingMinutesFromDate(DateTime date, long minutes)
        {
            Double hours = minutes / 60;

            DateTime returnDate = date;

            if (returnDate.DayOfWeek != DayOfWeek.Saturday && returnDate.DayOfWeek != DayOfWeek.Sunday)
            {

                int weekend_duration = DayOfWeek.Friday - returnDate.DayOfWeek;
                returnDate = returnDate.AddDays(weekend_duration);

                returnDate = returnDate.Date;
                returnDate = returnDate.AddHours(WORKINGTIME_START + WORKINGHOURS_PER_DAY);
            }
            else if (returnDate.Hour > (WORKINGTIME_START + WORKINGHOURS_PER_DAY))
            {
                returnDate = returnDate.Date;
                returnDate = returnDate.AddHours(WORKINGTIME_START + WORKINGHOURS_PER_DAY);
            }
            else if (returnDate.Hour < WORKINGTIME_START)
            {

                if (returnDate.DayOfWeek != DayOfWeek.Monday)
                {
                    returnDate = returnDate.Date.AddDays(-1);
                    returnDate = returnDate.AddHours(WORKINGTIME_START + WORKINGHOURS_PER_DAY);
                }
                else
                {
                    returnDate = returnDate.Date.AddDays(-3);
                    returnDate = returnDate.AddHours(WORKINGTIME_START + WORKINGHOURS_PER_DAY);

                }

            }

            Double completeWeeksToSubstract = Math.Floor(hours / WORKINGHOURS_PER_WEEK);
            returnDate = returnDate.AddDays(-completeWeeksToSubstract * 7);
            hours -= (completeWeeksToSubstract * WORKINGHOURS_PER_WEEK);

            Double completeDaysToSubstract = Math.Floor(hours / WORKINGHOURS_PER_DAY);
            hours -= (completeDaysToSubstract * WORKINGHOURS_PER_DAY);

            while (completeDaysToSubstract > 0)
            {
                returnDate = returnDate.AddDays(-1);
                if (returnDate.DayOfWeek != DayOfWeek.Saturday && returnDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    completeDaysToSubstract--;
                }
            }

            if (returnDate.Hour - hours < WORKINGTIME_START)
            {
                var temp = (returnDate.Hour - WORKINGTIME_START);
                hours -= temp;

                if (returnDate.DayOfWeek != DayOfWeek.Monday)
                {
                    returnDate = returnDate.Date.AddDays(-1);
                    returnDate = returnDate.Date.AddHours(WORKINGTIME_START + WORKINGHOURS_PER_DAY);
                    returnDate = returnDate.Date.AddHours(-temp);
                }
                else
                {
                    returnDate = returnDate.Date.AddDays(-3);
                    returnDate = returnDate.Date.AddHours(WORKINGTIME_START + WORKINGHOURS_PER_DAY);
                    returnDate = returnDate.Date.AddHours(-temp);

                }
            }
            else
            {
                returnDate.AddHours(-hours);

            }


            return returnDate;
        }
   
    }
}
