using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Data.Common;

namespace CSV2Core_MySQL.Support
{
    public class SQLClassFilter
    {
        private static readonly string[] filteredFields = { "isdeleted", "creation_timestamp", "status_isdirty", "status_isalreadysaved" };


         /// <example>
        /// Class instance = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance[Class]();
        /// instance.Parameter1 = NevValue; 
        /// instance.Parameter2 = ...
        /// bool isExists = CSV2Core_MySQL.Support.SQLClassFilter.Exists(Connection, Transaction, instance);
        /// </example>
        /// <param name="connection">Connection parameter</param>
        /// <param name="transaction">Transaction parameter</param>
        /// <param name="wrapper">InstanceWrapper for which to delete</param>
        /// <returns></returns>
        public static bool Exists(DbConnection connection, DbTransaction transaction, object instance)
        {
            return Exists(connection, transaction, InstanceFilterWrapper.Wrap(instance));
        }


        /// <example>
        /// Class instance = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance[Class]();
        /// instance.Parameter1 = NevValue; 
        /// instance.Parameter2 = ...
        /// InstanceFilterWrapper wrapper = InstanceFilterWrapper.Wrap(instance,[optinal override params]);
        /// bool isExists = CSV2Core_MySQL.Support.SQLClassFilter.Exists(Connection, Transaction, wrapper);
        /// </example>
        /// <param name="connection">Connection parameter</param>
        /// <param name="transaction">Transaction parameter</param>
        /// <param name="wrapper">InstanceWrapper for which to delete</param>
        /// <returns></returns>
        public static bool Exists(DbConnection connection, DbTransaction transaction, InstanceFilterWrapper wrapper)
        {
            try
            {
                var initializationSnapshot = GetFieldSnapshot(GetDefaultInstance(wrapper.Instance.GetType()));
                var currentSnapshot = GetFieldSnapshot(wrapper.Instance);
                var diff = Diff(initializationSnapshot, currentSnapshot, wrapper.OverrideFields);

                if (wrapper == null || diff.Count == 0)
                {
                    return false;
                }


                diff.Add("IsDeleted", false);

                string whereClause = CreateWhereClause(diff);
                string tableName = GetTableName(wrapper.Instance);


                string query = String.Format("SELECT EXISTS(SELECT 1 FROM {0} WHERE {1}) as Existance", tableName, whereClause);

                DbCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.Transaction = transaction;

                foreach (var key in diff.Keys)
                {
                    CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, key, diff[key]);
                }

                var reader = command.ExecuteReader();
                reader.Read();
                int resultCount = reader.GetInt32(reader.GetOrdinal("Existance"));
                reader.Close();

                return resultCount == 1;
            }
            catch (Exception ex)
            {
                CSV2Core.Logging.DLSystemLog.add(ex);
                return false;
            }
        }




        /// <example>
        /// Class instance = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance[Class]();
        /// instance.Parameter1 = NevValue; 
        /// instance.Parameter2 = ...
        /// InstanceFilterWrapper wrapper = InstanceFilterWrapper.Wrap(instance,[optinal override params]);
        /// int count = CSV2Core_MySQL.Support.SQLClassFilter.Count(Connection, Transaction, wrapper);
        /// </example>
        /// <param name="connection">Connection parameter</param>
        /// <param name="transaction">Transaction parameter</param>
        /// <param name="wrapper">InstanceWrapper for which to delete</param>
        /// <returns></returns>
        public static int Count(DbConnection connection, DbTransaction transaction, InstanceFilterWrapper wrapper)
        {
            try
            {
                var initializationSnapshot = GetFieldSnapshot(GetDefaultInstance(wrapper.Instance.GetType()));
                var currentSnapshot = GetFieldSnapshot(wrapper.Instance);
                var diff = Diff(initializationSnapshot, currentSnapshot, wrapper.OverrideFields);

                if (wrapper == null || diff.Count == 0)
                {
                    return 0;
                }

                string whereClause = CreateWhereClause(diff);
                string tableName = GetTableName(wrapper.Instance);

                string query = String.Format("SELECT COUNT(*) as Count FROM {0} WHERE {1}", tableName, whereClause);

                DbCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.Transaction = transaction;

                foreach (var key in diff.Keys)
                {
                    CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, key, diff[key]);
                }

                var reader = command.ExecuteReader();
                reader.Read();
                int resultCount = reader.GetInt32(0);
                reader.Close();
                return resultCount;
            }
            catch (Exception ex)
            {
                //CSV2Core.Logging.DLSystemLog.add(ex);
                return 0;
            }
        }

        /// <example>
        /// Class whereInstance = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance[Class]();
        /// whereInstance.Parameter1 = NevValue; 
        /// whereInstance.Parameter2 = ...
        /// int result = CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstance);
        /// </example>
        /// <param name="connection">Connection parameter</param>
        /// <param name="transaction">Transaction parameter</param>
        /// <param name="instance">Instance for which to delete</param>
        /// <returns></returns>
        public static int Delete(DbConnection connection, DbTransaction transaction, object instance)
        {
            return Delete(connection, transaction, InstanceFilterWrapper.Wrap(instance));
        }

        /// <example>
        /// Class whereInstance = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance[Class]();
        /// whereInstance.Parameter1 = NevValue; 
        /// whereInstance.Parameter2 = ...
        /// InstanceFilterWrapper wrapper = InstanceFilterWrapper.Wrap(whereInstance,[optinal override params]);
        /// int result = CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, wrapper);
        /// </example>
        /// <param name="connection">Connection parameter</param>
        /// <param name="transaction">Transaction parameter</param>
        /// <param name="wrapper">Instance for which to delete</param>
        /// <returns></returns>
        public static int Delete(DbConnection connection, DbTransaction transaction, InstanceFilterWrapper wrapper)
        {
            try
            {
                var initializationSnapshot = GetFieldSnapshot(GetDefaultInstance(wrapper.Instance.GetType()));
                var currentSnapshot = GetFieldSnapshot(wrapper.Instance);
                var diff = Diff(initializationSnapshot, currentSnapshot, wrapper.OverrideFields);

                if (wrapper == null || diff.Count == 0)
                {
                    return -1;
                }


                diff.Add("IsDeleted", false);

                string whereClause = CreateWhereClause(diff);
                string tableName = GetTableName(wrapper.Instance);


                string query = String.Format("UPDATE {0} SET IsDeleted = 1 WHERE {1}", tableName, whereClause);

                DbCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.Transaction = transaction;

                foreach (var key in diff.Keys)
                {
                    CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, key, diff[key]);
                }


                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //CSV2Core.Logging.DLSystemLog.add(ex);
                return -1;
            }
        }

        /// <summary>
        /// Update table values using instance as update source and comparator to find which instaces to update
        /// </summary>
        /// <param name="connection">Connection Parameter</param>
        /// <param name="transaction">Transaction Parameter</param>
        /// <param name="instance">Instance to update with</param>
        /// <param name="comparator">Instance for which we will create the where clause </param>
        /// <returns></returns>
        public static int UpdateValue(DbConnection connection, DbTransaction transaction, object instance, object comparator)
        {
            InstanceFilterWrapper instanceWrapper = InstanceFilterWrapper.Wrap(instance);
            InstanceFilterWrapper comparatorWrapper = InstanceFilterWrapper.Wrap(comparator);
            return UpdateValue(connection, transaction, instanceWrapper, comparatorWrapper);
        }



        /// <summary>
        /// Update specific ORM class with specific values
        /// </summary>
        /// <example>
        /// Class instance = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance[Class]();
        /// instance.Parameter1 = NevValue; 
        /// InstanceFilterWrapper instanceWrap = InstanceFilterWrapper.Wrap(instance,[optinal override params]);
        /// int result = CSV2Core_MySQL.Support.SQLClassFilter.UpdateValue(Connection, Transaction, instanceWrap, comparatorWrap);
        /// </example>
        /// <param name="connection">Connection parameter</param>
        /// <param name="transaction">Transaction parameter</param>
        /// <param name="instance">Instance to update with</param>
        /// <param name="comparator">Instance for which we will create the where clause </param>
        /// <returns></returns>
        public static int UpdateValue(DbConnection connection, DbTransaction transaction, InstanceFilterWrapper instance, InstanceFilterWrapper comparator)
        {
            try
            {
                var initializationSnapshot = GetFieldSnapshot(GetDefaultInstance(comparator.Instance.GetType()));
                var currentWhereSnapshot = GetFieldSnapshot(comparator.Instance);
                var diffWhere = Diff(initializationSnapshot, currentWhereSnapshot, comparator.OverrideFields);

                if (comparator == null || diffWhere.Count == 0)
                {
                    return -1;
                }

                diffWhere.Add("IsDeleted", false);

                string whereClause = CreateWhereClause(diffWhere,"P");
                string tableName = GetTableName(comparator.Instance);

                var currentUpdateSnapshot = GetFieldSnapshot(instance.Instance);
                var diffUpdate = Diff(initializationSnapshot, currentUpdateSnapshot, instance.OverrideFields);

                if (instance == null || diffUpdate.Count == 0)
                {
                    return -1;
                }

                string updateClause = CreateUpdateClause(diffUpdate);

                string query = String.Format("UPDATE {0} SET {1} WHERE {2}", tableName, updateClause, whereClause);

                DbCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.Transaction = transaction;

                foreach (var key in diffUpdate.Keys)
                {
                    CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,key, diffUpdate[key]);
                }

                foreach (var key in diffWhere.Keys)
                {
                    CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "P" + key, diffWhere[key]);
                }


                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //CSV2Core.Logging.DLSystemLog.add(ex);
                return -1;
            }
        }

        private static string CreateUpdateClause(Dictionary<string, object> snapshot, String prefix = "")
        {
            List<string> clauses = new List<string>();
            foreach (var key in snapshot.Keys)
            {
                clauses.Add(String.Format("{0} = @{1}{0}", key, prefix));
            }

            return String.Join(" , ", clauses);
        }

        private static string CreateWhereClause(Dictionary<string, object> snapshot,String prefix="")
        {
            List<string> clauses = new List<string>();
            foreach (var key in snapshot.Keys)
            {
                clauses.Add(String.Format("{0} = @{1}{0}", key,prefix));
            }

            return String.Join(" AND ", clauses);
        }


        private static Dictionary<string, object> Diff(Dictionary<string, object> snapshot, Dictionary<string, object> current, string[] overrideFields = null)
        {
            Dictionary<string, object> diff = new Dictionary<string, object>();
            foreach (string snapshotkey in snapshot.Keys)
            {

                object snapshotValue = snapshot[snapshotkey];
                object currentValue = current[snapshotkey];

                if (overrideFields!=null && overrideFields.Contains(snapshotkey))
                {
                    diff.Add(snapshotkey, currentValue);
                    continue;
                }

                if (!AreValuesEqual(snapshotValue, currentValue))
                {
                    if (!(currentValue is Guid) || ((Guid)currentValue) != Guid.Empty)
                    {
                        if (!(currentValue is CSV2Core_MySQL.Dictionaries.MultiTable.Dict))
                        {
                            diff.Add(snapshotkey, currentValue);
                        }
                    }
                }

            }
            return diff;
        }



        private static Dictionary<string, object> GetFieldSnapshot(object instance)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            var props = instance.GetType().GetProperties().Where(x => !filteredFields.Contains(x.Name.ToLower()));
            foreach (PropertyInfo prop in props)
            {
                dict.Add(prop.Name, prop.GetValue(instance, null));
            }

            return dict;
        }


        private static string GetTableName(object instance)
        {
            return instance.GetType().GetField("TableName").GetValue(null) as String;
        }

        public static T GetDefaultInstance<T>()
        {
            T instance = (T)GetDefaultInstance(typeof(T));


            var props = instance.GetType().GetProperties().Where(
                x => x.GetValue(instance, null) != null 
                && x.GetValue(instance, null).GetType() == typeof(Guid));
            foreach (PropertyInfo prop in props)
            {
                prop.SetValue(instance, Guid.Empty, null);
            }

            return instance;
        }


        private static object GetPropertyValue(string name, object instance)
        {

            var barProperty = instance.GetType().GetProperty(name);

            return barProperty.GetValue(instance, null);

        }



        public static object GetDefaultInstance(Type instanceType)
        {
            ConstructorInfo constructor = instanceType.GetConstructor(Type.EmptyTypes);
            var instance = constructor.Invoke(null);

            return instance;
        }



        /// <summary>
        /// Compares two values and returns if they are the same.
        /// </summary>
        /// <param name="valueA">The first value to compare.</param>
        /// <param name="valueB">The second value to compare.</param>
        /// <returns><c>true</c> if both values match, otherwise <c>false</c>.</returns>
        private static bool AreValuesEqual(object valueA, object valueB)
        {
            bool result;
            IComparable selfValueComparer;

            selfValueComparer = valueA as IComparable;

            if (valueA == null && valueB != null || valueA != null && valueB == null)
                result = false; // one of the values is null
            else if (selfValueComparer != null && selfValueComparer.CompareTo(valueB) != 0)
                result = false; // the comparison using IComparable failed
            else if (!object.Equals(valueA, valueB))
                result = false; // the comparison using Equals failed
            else
                result = true; // match

            return result;
        }
    }

    /// <summary>
    /// Special class wrapper to be used in the filter comparators
    /// </summary>
    public class InstanceFilterWrapper
    {
        private InstanceFilterWrapper()
        {

        }

        /// <summary>
        /// Creates a filter wrapper 
        /// </summary>
        /// <param name="instance">Instance (inherits base class)</param>
        /// <param name="overrideFields"></param>
        /// <returns>InstanceFilterWrapper instance for usage in filtering</returns>
        public static InstanceFilterWrapper Wrap(object instance, params string[] overrideFields)
        {
            return new InstanceFilterWrapper
            {
                Instance = instance,
                OverrideFields = overrideFields
            };
        }


        public object Instance { get; set; }
        public string[] OverrideFields { get; set; }
    }
}
