using System;
using System.Collections.Generic;
using System.Data.Common;

namespace CSV2Core_MySQL
{
    public abstract class BaseFilterQuery<T>
    {

        protected string CreateSelectQuery(string tableName)
        {
            return String.Format("SELECT * FROM {0} WHERE {1}", tableName, CreateWhereStatement());
        }

        protected string CreateExistsQuery(string tableName)
        {
            return String.Format("SELECT EXISTS(SELECT 1 FROM {0} WHERE {1}) as Existance", tableName, CreateWhereStatement());
        }

        protected string CreateUpdateQuery(string tableName, string setStatement)
        {
            return String.Format("UPDATE {0} SET {1} WHERE {2}", tableName, setStatement, CreateWhereStatement());
        }

        protected string CreateSoftDeleteQuery(string tableName, bool deleteStatus)
        {
            return String.Format("UPDATE {0} SET IsDeleted = {1} WHERE {2}", tableName, (deleteStatus?1:0), CreateWhereStatement());
        }

        public string CreateSetStatement()
        {
            List<string> setStatements = new List<string>();
            foreach (System.Reflection.PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                object value = propertyInfo.GetValue(this, null);
                if (value != null)
                {
                    setStatements.Add(String.Format("{0} = @New_{1}", propertyInfo.Name, propertyInfo.Name));
                }
            }
            return string.Join(" , ",setStatements);;
        }
            
        private string CreateWhereStatement()
        {
            List<string> whereStatements = new List<string>();
            foreach (System.Reflection.PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                object value = propertyInfo.GetValue(this, null);
                if (value != null)
                {
                    whereStatements.Add(String.Format("{0} = @{1}", propertyInfo.Name, propertyInfo.Name));
                }
            }
            return string.Join(" AND ", whereStatements); ;
        }


        protected void SetParameters(DbCommand command)
        {
            foreach (System.Reflection.PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                object value = propertyInfo.GetValue(this, null);
                if (value != null)
                {
                    CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, propertyInfo.Name, value);
                }
            }
        }

        protected void SetUpdateValues(DbCommand command)
        {
            foreach (System.Reflection.PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                object value = propertyInfo.GetValue(this, null);
                if (value != null)
                {
                    CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "New_"+propertyInfo.Name, value);
                }
            }
        }

    }
}
