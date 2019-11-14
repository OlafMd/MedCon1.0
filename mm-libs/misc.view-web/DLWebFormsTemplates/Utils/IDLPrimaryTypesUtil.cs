using System;

namespace DLWebFormsTemplates.Utils
{
    interface IDLPrimaryTypesUtil
    {
        double GetDoubleFromString(String doubleString);

        double GetDoubleFromStringOrDefault(String doubleString);

        String GetTwoDigitsPriceString(object data, String format = "0.00");
    }
}
