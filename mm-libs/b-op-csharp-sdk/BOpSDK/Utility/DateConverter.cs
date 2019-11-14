using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Utility
{
    public class DateConverter
    {
        public static String SIMPLE_DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private static string FULL_DATE_FORMAT = "yyyy-MM-dd HH:mm:ss.fff \"CET\"";

        public static DateTime SimpleStringToDate(string dateFormatedString)
        {
            DateTime.Parse(dateFormatedString);
            return DateTime.Now;
        }

        public static DateTime StringToDate(string dateFormatedString)
        {
            DateTime.Parse(dateFormatedString);
            return DateTime.Now;
        }
        public static string DateToString(DateTime date)
        {
            return date.ToString(FULL_DATE_FORMAT);
        }
    }
}
