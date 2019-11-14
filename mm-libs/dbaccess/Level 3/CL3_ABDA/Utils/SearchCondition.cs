using System;
using System.Linq;

namespace CL3_ABDA.Utils
{

    public enum ProductField { NAME_TOKEN, NAME, DOSAGE_FORM, CODE, UNIT, SUBSTANCE, DISTRIBUTION_STATUS, PRODUCER, IS_PART_OF_DEFAULT_STOCK }

    public class SearchCondition
    {
        public string query { get; set; }
        public ProductField field { get; set; }

        public static string GetQueryForField(SearchCondition[] conditions, ProductField field)
        {
            var retVal = "";
            if (conditions != null)
            {
                var gf = conditions.FirstOrDefault(q => q != null && q.field == field);
                if (gf != null)
                {
                    if (!gf.query.Contains("*"))
                        retVal += "*" + gf.query + "*";
                    else
                        retVal += gf.query;
                }
            }
            return retVal;
        }

        public static string GetPrefixForField(SearchCondition[] conditions, ProductField field)
        {
            if (conditions != null)
            {
                var gf = conditions.FirstOrDefault(q => q != null && q.field == field);
                if (gf != null)
                {
                    return gf.query;
                }
            }
            return string.Empty;
        }

        public static string GetFiledName(ProductField field)
        {
            switch (field)
            {
                case ProductField.CODE:
                    return "code";
                case ProductField.NAME_TOKEN:
                    return "name.token";
                case ProductField.NAME:
                    return "name";
                case ProductField.DOSAGE_FORM:
                    return "healthcare.dosageForm";
                case ProductField.DISTRIBUTION_STATUS:
                    return "healthcare.distributionStatus";
                case ProductField.UNIT:
                    return "packaging.unit";
                case ProductField.SUBSTANCE:
                    return "healthcare.components.substances.name";
                case ProductField.PRODUCER:
                    return "producer";
                default:
                    throw new NotImplementedException();
            }
        }

        public static string GetConditionForSearchText(String searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText) )
                return null;

            var retVal = searchText;

            if (!searchText.Contains("*"))
                retVal = String.Format("*{0}*",searchText);

            return retVal;
        }
    }
  
}
