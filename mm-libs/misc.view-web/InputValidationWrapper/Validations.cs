using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace InputValidationWrapper
{
    class Validations
    {

        /// <summary>
        /// Checks if supplied value is a non-empty string.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns></returns>
        public static bool Mandatory(string value)
        {
            return !String.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Checks if supplied value is an integer.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True if empty or integer. False otherwise.</returns>
        public static bool IsInteger(string value)
        {
            if (value == "") return true;
            Int32 intValue = new Int32();
            return Int32.TryParse(value, out intValue);
        }

        /// <summary>
        /// Checks if supplied value is a double.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True if empty or double. False otherwise.</returns>
        public static bool IsDouble(string value)
        {
            if (value == "") return true;
            Double doubleValue = new Double();
            return Double.TryParse(value, out doubleValue);
        }

        /// <summary>
        /// Checks if supplied value is a positive number.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True if empty or positive number. False otherwise.</returns>
        public static bool IsPositive(string value)
        {
            if (value == "") return true;
            Double doubleValue = new Double();
            if (Double.TryParse(value, out doubleValue))
            {
                return doubleValue >= 0;
            }
            else return false;
        }

        /// <summary>
        /// Checks if supplied value is a negative number.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True if empty or negative number. False otherwise.</returns>
        public static bool IsNegative(string value)
        {
            if (value == "") return true;
            Double doubleValue = new Double();
            if (Double.TryParse(value, out doubleValue))
            {
                return doubleValue < 0;
            }
            else return false;
        }

        /// <summary>
        /// Checks if supplied value is a double with specified number of decimal digits.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="decimals">Number of decimal digits to match</param>
        /// <returns>True if empty or decimal double with specified number of decimal digits. False otherwise.</returns>
        public static bool Decimals(string value, int decimals)
        {
            if (value == "") return true;
            Double doubleValue = new Double();
            if (Double.TryParse(value, out doubleValue))
            {
                string separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                if (value.Contains(separator))
                {
                    string[] tail = value.Split(separator.ToArray());
                    if (tail.Length == 2 && tail[1].Length == decimals) return true;
                }
            }

            return false;

        }

        /// <summary>
        /// Checks if supplied value is a number within the specified range.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="minIclusive">Lower boundary of the range. Inclusive</param>
        /// <param name="maxExclusive">Upper boundary of the range. Exclusive</param>
        /// <returns>True if empty or number within range. False otherwise.</returns>
        public static bool IsInRange(string value, double minIclusive, double maxExclusive)
        {
            if (value == "") return true;
            Double doubleValue = new Double();
            if (Double.TryParse(value, out doubleValue))
            {
                return (doubleValue >= minIclusive && doubleValue < maxExclusive);
            }
            else return false;
        }

        /// <summary>
        /// Checks if supplied value is a number outside the specified range.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="minIclusive">Lower boundary of the range. Inclusive</param>
        /// <param name="maxExclusive">Upper boundary of the range. Exclusive</param>
        /// <returns>True if empty or number ouside of range. False otherwise.</returns>
        public static bool IsNotInRange(string value, double minIclusive, double maxExclusive)
        {
            if (value == "") return true;
            Double doubleValue = new Double();
            if (Double.TryParse(value, out doubleValue))
            {
                return (doubleValue <= minIclusive || doubleValue > maxExclusive);
            }
            else return false;
        }

        /// <summary>
        /// Checks if supplied value is a valid date of the specified format in the specified culture.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="dateFormat">Date format. If not specified, the short date format of the current culture will be taken.</param>
        /// <param name="culture">Culture string (e. g. "en-US", "en"). If not specified, the current culture will be taken.</param>
        /// <returns>True if empty or valid date. False otherwise.</returns>
        public static bool IsDate(string value, string dateFormat = null, string culture = null)
        {
            if (value == "") return true;
            if (String.IsNullOrEmpty(dateFormat))
            {
                dateFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
            }
            CultureInfo cultureInfo;
            if (String.IsNullOrEmpty(culture))
            {
                cultureInfo = Thread.CurrentThread.CurrentCulture;
            }
            else
            {
                cultureInfo = new CultureInfo(culture);
            }
            DateTime dateValue = new DateTime();
            if (DateTime.TryParseExact(value, new string[] { dateFormat }, cultureInfo, DateTimeStyles.None, out dateValue))
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Checks if supplied value is a valid date of the specified format in the specified culture, withing the specified range.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="dateFormat">Date format. If not specified, the short date format of the current culture will be taken.</param>
        /// <param name="culture">Culture string (e. g. "en-US", "en"). If not specified, the current culture will be taken.</param>
        /// <param name="minInclusive">Lower boundary of the range. Inclusive.</param>
        /// <param name="maxExclusive">Upper boundary of the range. Exclusive.</param>
        /// <returns>True if empty or valid date within range. False otherwise.</returns>
        public static bool IsDateInRange(string value, DateTime minInclusive, DateTime maxExclusive, string dateFormat = null, string culture = null)
        {
            if (value == "") return true;
            if (String.IsNullOrEmpty(dateFormat))
            {
                dateFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
            }
            CultureInfo cultureInfo;
            if (String.IsNullOrEmpty(culture))
            {
                cultureInfo = Thread.CurrentThread.CurrentCulture;
            }
            else
            {
                cultureInfo = new CultureInfo(culture);
            }
            DateTime dateValue = new DateTime();
            if (DateTime.TryParseExact(value, new string[] { dateFormat }, cultureInfo, DateTimeStyles.None, out dateValue))
            {
                return (dateValue >= minInclusive && dateValue < maxExclusive);
            }
            else return false;
        }

        /// <summary>
        /// Checks if supplied value is a valid date of the specified format in the specified culture, outside of the specified range.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="dateFormat">Date format. If not specified, the short date format of the current culture will be taken.</param>
        /// <param name="culture">Culture string (e. g. "en-US", "en"). If not specified, the current culture will be taken.</param>
        /// <param name="minInclusive">Lower boundary of the range. Inclusive.</param>
        /// <param name="maxExclusive">Upper boundary of the range. Exclusive.</param>
        /// <returns>True if empty or valid date outside of range. False otherwise.</returns>
        public static bool IsDateNotInRange(string value, DateTime minInclusive, DateTime maxExclusive, string dateFormat, string culture)
        {
            if (value == "") return true;
            if (String.IsNullOrEmpty(dateFormat))
            {
                dateFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
            }
            CultureInfo cultureInfo;
            if (String.IsNullOrEmpty(culture))
            {
                cultureInfo = Thread.CurrentThread.CurrentCulture;
            }
            else
            {
                cultureInfo = new CultureInfo(culture);
            }
            DateTime dateValue = new DateTime();
            if (DateTime.TryParseExact(value, new string[] { dateFormat }, cultureInfo, DateTimeStyles.None, out dateValue))
            {
                return (dateValue <= minInclusive || dateValue > maxExclusive);
            }
            else return false;
        }

        /// <summary>
        /// Checks if supplied value is a valid email address.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True if empty or valid email address. False otherwise.</returns>
        public static bool IsValidEmail(string value)
        {
            if (value == "") return true;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(value);
            return match.Success;

        }

        /// <summary>
        /// Checks if the selected index of a dropdown list equals the required one.
        /// </summary>
        /// <param name="index">Index to check</param>
        /// <param name="requiredIndex">Index to match</param>
        /// <returns></returns>
        public static bool IsSelectedIndex(int index, int requiredIndex)
        {
            return index == requiredIndex;
        }


    }
}
