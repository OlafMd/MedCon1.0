using System;
using System.Globalization;
using System.Threading;

namespace DLWebFormsTemplates.Utils
{
    class DLPrimaryTypesUtil:IDLPrimaryTypesUtil
    {

        private CultureInfo culture = CultureInfo.InvariantCulture;

        public DLPrimaryTypesUtil()
        {
            try
            {
                culture = Thread.CurrentThread.CurrentUICulture;

            }
            catch (Exception ex)
            {
    
            }
        }

        public double GetDoubleFromString(String doubleString)
        {
            return Double.Parse(doubleString, culture);
        }

        public double GetDoubleFromStringOrDefault(String doubleString)
        {
            try
            {
                return Double.Parse(doubleString, culture);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public string GetStringFromDouble(double number)
        {
            return number.ToString(culture);
        }


        public String GetTwoDigitsPriceString(object data, String format = "0.00")
        {
            if (data is Decimal)
                return ((Decimal)data).ToString(format, culture);
            else if (data is Double)
                return ((Double)data).ToString(format, culture);
            else
                return (Double.Parse("0")).ToString(format, culture);
        }
    }
}
