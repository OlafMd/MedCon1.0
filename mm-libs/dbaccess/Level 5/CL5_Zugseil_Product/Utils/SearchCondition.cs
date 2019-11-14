using System;
using System.Linq;

namespace CL5_Zugseil_Product.Utils
{

    public enum ProductField { NAME, CODE }

    public class SearchCondition
    {
        public string query { get; set; }
        public ProductField field { get; set; }

        public static string GetFiledName(ProductField field)
        {
            switch (field)
            {
                case ProductField.CODE:
                    return "code";
                case ProductField.NAME:
                    return "name";
                default:
                    throw new NotImplementedException();
            }
        }

        public static string GetConditionForSearchText(String searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return null;

            var retVal = searchText;

            if (!searchText.Contains("*"))
                retVal = String.Format("*{0}*", searchText);

            return retVal;
        }
    }
  
}
