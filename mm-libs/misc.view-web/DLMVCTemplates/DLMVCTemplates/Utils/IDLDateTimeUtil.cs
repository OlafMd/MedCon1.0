using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMVCTemplates.Utils
{
    public interface IDLDateTimeUtil
    {
        String GetFormatedDateString(DateTime date);

        String GetFormatedDateString(object date);

        String GetFormatedDateStringOrDefault(DateTime date, String defaultString = "");

        String GetFormatedDateStringOrEmpty(object date);

        DateTime GetDateTimeFromString(String dateString);

        DateTime GetMonthYearFromString(String dateString);

        DateTime GetMonthYearWithTwoDigitFromString(String dateString);

        String GetMonthYearString(DateTime date);

        DateTime GetDateTimeFromStringOrDefault(String dateString);

        DateTime? GetDateTimeFromStringOrNull(String dateString);

        String GetTimeString(DateTime date);
    }
}
