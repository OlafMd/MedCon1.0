using System;

namespace DLWebFormsTemplates.Utils
{
    public interface IDLDateTimeUtil
    {
        String GetFormatedDateString(DateTime date);

        String GetFormatedDateString(object date);

        String GetFormatedDateStringOrDefault(DateTime date, String defaultString = "");

        String GetFormatedDateStringOrEmpty(object date);

        DateTime GetDateTimeFromString(String dateString);

        DateTime GetDateTimeFromStringOrDefault(String dateString);

        String GetTimeString(DateTime date);

    }
}
