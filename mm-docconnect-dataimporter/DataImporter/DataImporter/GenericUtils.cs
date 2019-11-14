using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter
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

            return result;
        }

        public static string GetDoctorNameUppercaseOrdinals(dynamic doc)
        {
            var result = String.Format("{0} {1}", doc.First_Name, doc.Last_Name);
            if (!String.IsNullOrEmpty(doc.Title))
            {
                result = String.Format("{0} {1}", doc.Title, result);
            }

            return result;
        }

        public static string GetDoctorNamePascal(dynamic doc)
        {
            var result = String.Format("{0} {1}", doc.FirstName, doc.LastName);
            if (!String.IsNullOrEmpty(doc.Title))
            {
                result = String.Format("{0} {1}", doc.Title, result);
            }

            return result;
        }
    }
}
