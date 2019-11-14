using System;
using BOp.CatalogAPI.data;
using DLUtils_Common.Calculations;

namespace CL3_ABDA.Utils
{
    public class ExpiryPeriodUtil : ExpiryPeriodBasicUtil
    {
        public const int DAYS_IN_MONTH = 30;

        public static long GetExpiryPeriodInSeconds(ExpiryInformation expiryInfo) 
        {
            double multiplier = 1;

            switch (expiryInfo.TimeUnit) { 
                case ExpiryInformation.TimeUnitType.Second:
                    multiplier = 1;
                    break;
                case ExpiryInformation.TimeUnitType.Minute:
                    multiplier = 60;
                    break;
                case ExpiryInformation.TimeUnitType.Hour:
                    multiplier = 3600;
                    break;
                case ExpiryInformation.TimeUnitType.Day:
                    multiplier = 86400;
                    break;
                case ExpiryInformation.TimeUnitType.Week:
                    multiplier = 604800;
                    break;
                case ExpiryInformation.TimeUnitType.Month:
                    multiplier = 86400 * DAYS_IN_MONTH;
                    break;
                case ExpiryInformation.TimeUnitType.Year:
                    multiplier = 86400 * DAYS_IN_MONTH * 12;
                    break;
                default:
                    multiplier = 0;
                    break;
            }

            if (expiryInfo.TimeValue != null)
                return Convert.ToInt64(expiryInfo.TimeValue * multiplier);
            else
                return 0;
        }

        public static ExpiryInformation GetExpiryInformationFromSeconds(long expirySeconds)
        {
            BOp.CatalogAPI.data.ExpiryInformation.TimeUnitType unitType = BOp.CatalogAPI.data.ExpiryInformation.TimeUnitType.Second;

            double divisor = 1;

            if (expirySeconds > 60){
                divisor = 60;
                unitType = BOp.CatalogAPI.data.ExpiryInformation.TimeUnitType.Minute; 
            }
            if(expirySeconds > 3600){
                divisor = 3600;
                unitType = BOp.CatalogAPI.data.ExpiryInformation.TimeUnitType.Hour;
            }
            if(expirySeconds > 86400){
                divisor = 86400;
                unitType = BOp.CatalogAPI.data.ExpiryInformation.TimeUnitType.Day;
            }
            if(expirySeconds > 604800){
                divisor = 604800;
                unitType = BOp.CatalogAPI.data.ExpiryInformation.TimeUnitType.Week;
            }
            if(expirySeconds >  86400 * DAYS_IN_MONTH){
                divisor = 86400 * DAYS_IN_MONTH;
                unitType = BOp.CatalogAPI.data.ExpiryInformation.TimeUnitType.Month;
            }
            if(expirySeconds >  86400 * DAYS_IN_MONTH * 12){
                divisor = 86400 * DAYS_IN_MONTH * 12;
                unitType = BOp.CatalogAPI.data.ExpiryInformation.TimeUnitType.Year;
            }

            var expiryInfo = new ExpiryInformation()
            {
                TimeValue = expirySeconds / divisor,
                TimeUnit = unitType
            };

            return expiryInfo;
        }

    }
}
