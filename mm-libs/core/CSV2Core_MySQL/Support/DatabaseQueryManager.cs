using System;

namespace CSV2Core_MySQL.Support
{
    public static class DatabaseQueryManager
    {
        public static string GetCollationTable(string tableName)
        {
            return GetQuery(tableName, "AlterCollation");
        }

        public static string GetDeleteField(string tableName)
        {
            return GetQuery(tableName, "AlterDeleteField");
        }

        public static string GetTimestampField(string tableName)
        {
            return GetQuery(tableName, "AlterCreationTimestampField");
        }

        public static string GetTenantField(string tableName)
        {
            return GetQuery(tableName, "AlterTenantField");
        }

        public static string GetDictionaryTable(string tableName)
        {
            if (!tableName.ToLower().EndsWith("_de"))
            {
                tableName +="_DE";
            }

            return GetQuery(tableName, "CreateDictionaryTable");
        }

        private static string GetQuery(string tableName, string queryName)
        {
            string resource = String.Format("CSV2Core_MySQL.Support.SQL.{0}.sql", queryName);
            string query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resource)).ReadToEnd();
            return query.Replace("$$TABLENAME$$", tableName);
        }
    }
}
