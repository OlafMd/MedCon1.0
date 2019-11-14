using System;
using System.Globalization;
using Danulabs.Utils;
using System.Threading;

namespace DLWebFormsTemplates.Utils
{
    class DLDateTimeUtil : IDLDateTimeUtil
    {
        private CultureInfo culture = CultureInfo.InvariantCulture;

        public DLDateTimeUtil()
        {
            try
            {
                culture = Thread.CurrentThread.CurrentUICulture;

            }
            catch (Exception ex)
            {

            }
        }

        public String GetFormatedDateString(DateTime date)
        {
            return date.ToString(SessionGlobal.Instance.DateFormat);
        }

        public String GetFormatedDateString(object date)
        {
            if (date is DateTime)
                return GetFormatedDateString((DateTime)date);
            else
                throw new Exception("Object is not instance of DateTime!");
        }

        public String GetFormatedDateStringOrDefault(DateTime date, String defaultString = "")
        {
            if (date == new DateTime())
                return defaultString;

            return GetFormatedDateString(date);
        }

        public String GetFormatedDateStringOrEmpty(object date)
        {
            if (!(date is DateTime))
                throw new Exception("Object is not instance of DateTime!");

            return GetFormatedDateStringOrDefault((DateTime)date);
        }

        public DateTime GetDateTimeFromString(String dateString)
        {
            return DateTime.ParseExact(dateString, SessionGlobal.Instance.DateFormat, culture);
        }

        //TODO - implement culture dependent function
        public DateTime GetMonthYearFromString(String dateString)
        {
            DateTime dateToReturn = new DateTime();

            if (!String.IsNullOrEmpty(dateString))
            {
                var splitted = dateString.Split('.');
                var year = Convert.ToInt16(splitted[1]);
                var month = Convert.ToInt16(splitted[0]);
                dateToReturn = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            }

            return dateToReturn;
        }

        //TODO - implement culture dependent function
        public DateTime GetMonthYearWithTwoDigitFromString(String dateString)
        {
            DateTime dateToReturn = new DateTime();

            if (!String.IsNullOrEmpty(dateString))
            {
                var splitted = dateString.Split('.');
                var year = Convert.ToInt16(splitted[1]) + 2000;
                var month = Convert.ToInt16(splitted[0]);
                dateToReturn = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            }

            return dateToReturn;
        }

        //TODO - implement culture dependent function
        public String GetMonthYearString(DateTime date)
        {
            if (date != DateTime.MinValue)
            {
                var yearString = date.ToString("yy");
                var monthString = date.Month.ToString();

                if (monthString.Length == 1)
                {
                    monthString = "0" + monthString;
                }

                return monthString + "." + yearString;
            }

            return String.Empty;
        }

        public DateTime GetDateTimeFromStringOrDefault(String dateString)
        {
            try
            {
                return GetDateTimeFromString(dateString);
            }
            catch (Exception ex)
            {
                return new DateTime();
            }
        }

        public DateTime? GetDateTimeFromStringOrNull(String dateString)
        {
            try
            {
                return GetDateTimeFromString(dateString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String GetTimeString(DateTime date)
        {
            var hours = ("00" + date.Hour);
            hours = hours.Substring(hours.Length - 2);
            var minutes = ("00" + date.Minute);
            minutes = minutes.Substring(minutes.Length - 2);

            return hours + ":" + minutes;
        }
    }
}
