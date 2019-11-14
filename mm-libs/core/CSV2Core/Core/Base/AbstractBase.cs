using System;
using System.Collections.Generic;
using System.Data.Common;

namespace CSV2Core.Core.Base
{
    /// <summary>
    /// Abstract implementation of the base class
    /// </summary>
    public abstract class AbstractBase : CSV2Core.Core.Interfaces.IBaseClass
    {
        public Dictionary<string, object> ChangedProperties { get; set; }

        //Standard parameters
        protected bool Status_IsAlreadySaved { get; set; }
        protected bool Status_IsDirty { get; set; }

        /// <summary>
        /// Implemented in the subclass
        /// </summary>
        public abstract void Clear();

        protected void clearAbstract()
        {
            ChangedProperties.Clear();
            Status_IsAlreadySaved = false;
            Status_IsDirty = false;
        }

        public void PropertyChange(string name, object value)
        {
            if (ChangedProperties.ContainsKey(name) == true)
            {
                ChangedProperties[name] = value;
            }
            else
            {
                ChangedProperties.Add(name, value);
            }
        }

        /// <summary>
        /// Method instantiates <code>DbConnection</code> used to communicate with database
        /// with the given connection string.
        /// </summary>
        /// <param name="connectionString">Connection string to establish connection to database.</param>
        /// <returns></returns>
        protected abstract DbConnection GetConnection(string connectionString); 

        #region Save Method Wrappers

        public void Save(string connectionString)
        {
            Save(null, null, connectionString);
        }

        public void Save(System.Data.Common.DbConnection connection)
        {
            Save(connection, null, null);
        }

        public void Save(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction)
        {
            Save(connection, transaction, null);
        }

        /// <summary>
        /// Method for generator override
        /// </summary>
        /// <param name="connection">Available database connection</param>
        /// <param name="transaction">Available database transaction</param>
        /// <param name="connectionString">Avaliable connection string</param>
        /// <returns></returns>
        protected void Save(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction, string connectionString)
        {
            //MySqlContextExecutionWrapper wrapper = new MySqlContextExecutionWrapper();
            //wrapper.Initialize(ref connection, ref transaction, connectionString);
            //SaveImplementation(connection, transaction);
            //wrapper.Cleanup(ref connection, ref transaction, connectionString);
        }

        protected abstract void SaveImplementation(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction);

        #endregion

        #region Load Method Wrappers

        public void Load(string connectionString, Guid identifier)
        {
            Load(null, null, identifier, connectionString);
        }

        public void Load(System.Data.Common.DbConnection connection, Guid identifier)
        {
            Load(connection, null, identifier, null);
        }

        public void Load(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction, Guid identifier)
        {
            Load(connection, transaction, identifier, null);
        }

        protected void Load(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction, Guid identifier, string connectionString)
        {
            //MySqlContextExecutionWrapper wrapper = new MySqlContextExecutionWrapper();
            //wrapper.Initialize(ref connection, ref transaction, connectionString);
            //LoadImplementation(connection, transaction, identifier);
            //wrapper.Cleanup(ref connection, ref transaction, connectionString);
        }

        protected abstract void LoadImplementation(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction, Guid identifier);

        #endregion

        #region Remove Method Wrappers

        public void Remove(string connectionString)
        {
            Remove(null, null, connectionString);
        }

        public void Remove(System.Data.Common.DbConnection connection)
        {
            Remove(connection, null, null);
        }

        public void Remove(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction)
        {
            Remove(connection, transaction, null);
        }

        protected void Remove(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction, string connectionString)
        {
            //MySqlContextExecutionWrapper wrapper = new MySqlContextExecutionWrapper();
            //wrapper.Initialize(ref connection, ref transaction, connectionString);
            //RemoveImplementation(connection, transaction);
            //wrapper.Cleanup(ref connection, ref transaction, connectionString);
        }

        protected abstract void RemoveImplementation(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction);

        #endregion

        #region Exists Method Wrapper

        public bool Exists(string connectionString, Guid identifier)
        {
            return Exists(null, null, identifier, connectionString);
        }

        public bool Exists(System.Data.Common.DbConnection connection, Guid identifier)
        {
            return Exists(connection, null, identifier, null);
        }

        public bool Exists(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction, Guid identifier)
        {
            return Exists(connection, transaction, identifier, null);
        }

        public bool Exists(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction, Guid identifier, string connectionString)
        {
            //MySqlContextExecutionWrapper wrapper = new MySqlContextExecutionWrapper();
            //wrapper.Initialize(ref connection, ref transaction, connectionString);
            //bool result = ExistsImplementation(connection, transaction, identifier);
            //wrapper.Cleanup(ref connection, ref transaction, connectionString);

            //return result;
            return false;
        }

        protected abstract bool ExistsImplementation(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction, Guid identifier);

        #endregion
    }
}
