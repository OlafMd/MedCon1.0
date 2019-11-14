using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocApp
{
    public static class GenericUtils
    {
        public static string GetDoctorName(dynamic doc)
        {
            var result = String.Format("{0} {1}", doc.first_name, doc.last_name);
            if (!String.IsNullOrEmpty(doc.title))
            {
                result = String.Format("{0} {1}", doc.title, result);
            }

            return result.Trim();
        }

        public static string GetDoctorNamePrefixPascal(dynamic doc)
        {
            var result = String.Format("{0} {1}", doc.DoctorFirstName, doc.DoctorLastName);
            if (!String.IsNullOrEmpty(doc.DoctorTitle))
            {
                result = String.Format("{0} {1}", doc.DoctorTitle, result);
            }

            return result.Trim();
        }

        public static string GetDoctorNameUppercaseOrdinals(dynamic doc)
        {
            var result = String.Format("{0} {1}", doc.First_Name, doc.Last_Name);
            if (!String.IsNullOrEmpty(doc.Title))
            {
                result = String.Format("{0} {1}", doc.Title, result);
            }

            return result.Trim();
        }
        
        public static string RemoveUmlauts(string name)
        {
            return name.Replace("Ü", "Ue").Replace("ü", "ue").Replace("ä", "ae").Replace("Ä", "Ae").Replace("Ö", "Oe").Replace("ö", "oe");
        }

        public static string GetDiagnoseName(dynamic diagnose_details)
        {
            return String.Format("{0} ({1}: {2})", diagnose_details.diagnose_name, diagnose_details.catalog_display_name, diagnose_details.diagnose_icd_10);
        }

        public static string GetDiagnoseNamePascal(dynamic diagnose_details)
        {
            return String.Format("{0} ({1}: {2})", diagnose_details.DiagnoseName, diagnose_details.Catalog_DisplayName, diagnose_details.DiagnoseCode);
        }

        public static void CloneObject<T>(T source, T destination)
        {
            var properties = typeof(T).GetProperties();
            foreach (var prop in properties)
            {
                prop.SetValue(destination, prop.GetValue(source));
            }
        }

        public static DateTime GetDate(string date)
        {
            var culture = new CultureInfo("de", true);
            return DateTime.ParseExact(date, "dd.MM.yyyy", culture);
        }
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
