using System;

namespace CL3_Articles.Utils
{
    public class LocalDBSearchCondition
    {
        public static string GetConditionForSearchText(String searchText)
        {
            if (searchText == null)
                return null;

            var retVal = searchText;

            if (!searchText.Contains("*"))
                retVal = String.Format("%{0}%", searchText);
            else
                retVal = searchText.Replace('*', '%');

            return retVal;
        }
    }
  
}
