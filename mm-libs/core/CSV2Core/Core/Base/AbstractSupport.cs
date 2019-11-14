using System;
using System.Data.Common;

using CSV2Core.Core.Interfaces;

namespace CSV2Core.Core.Base
{
    public abstract class AbstractSupport<T> : IBaseSupport<T> where T : IBaseClass
    {
        /// <summary>
        /// Method instantiates <code>DbConnection</code> used to communicate with database
        /// with the given connection string.
        /// </summary>
        /// <param name="connectionString">Connection string to establish connection to database.</param>
        /// <returns></returns>
        protected abstract DbConnection GetConnection(string connectionString); 

        #region Get Wrappers
        public T[] GetAllLike(T comparator, string connectionString)
        {
            return GetAllLike(comparator, null, null, connectionString);
        }

        public T[] GetAllLike(T comparator, System.Data.Common.DbConnection connection)
        {
            return GetAllLike(comparator, connection, null, null);
        }

        public T[] GetAllLike(T comparator, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction)
        {
            return GetAllLike(comparator, connection, transaction, null);
        }

        protected T[] GetAllLike(T comparator, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction, string connectionString)
        {
            // We cleanup only connection and transactions that we internally create within method
            bool cleanupConnection = connection == null;
            bool cleanupTransaction = transaction == null;

            T[] result = null;
            try
            {
                // If connection is not initialized before call, initialize it
                if (cleanupConnection)
                {
                    connection = GetConnection(connectionString);
                    connection.Open();
                }
                // If transaction is not opened before call, begin it
                if (cleanupTransaction)
                {
                    transaction = connection.BeginTransaction();
                }

                result = GetAllLikeImplementation(comparator, connection, transaction);

                // Commit the transaction
                if (cleanupTransaction)
                {
                    transaction.Commit();
                }
                // Close the connection if instantiated here
                if (cleanupConnection)
                {
                    connection.Close();
                }
            }
            catch (Exception exception)
            {
                // Try to rollback the transaction if needed
                try
                {
                    if (cleanupTransaction && transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                catch (Exception inException)
                {

                }
                // Try to close the connection if needed
                try
                {
                    if (cleanupConnection && connection != null)
                    {
                        connection.Close();
                    }
                }
                catch (Exception inException)
                {

                }
            }

            return result;
        }

        protected abstract T[] GetAllLikeImplementation(T comparator, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction);

        #endregion

        #region Update Wrappers
        public long UpdateAllLike(T comparator, T instance, string connectionString)
        {
            return UpdateAllLike(comparator, instance, null, null, connectionString);
        }

        public long UpdateAllLike(T comparator, T instance, System.Data.Common.DbConnection connection)
        {
            return UpdateAllLike(comparator, instance, connection, null, null);
        }

        public long UpdateAllLike(T comparator, T instance, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction)
        {
            return UpdateAllLike(comparator, instance, connection, transaction, null);
        }

        protected long UpdateAllLike(T comparator, T instance, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction, string connectionString)
        {
            // We cleanup only connection and transactions that we internally create within method
            bool cleanupConnection = connection == null;
            bool cleanupTransaction = transaction == null;

            long result = -1;
            try
            {
                // If connection is not initialized before call, initialize it
                if (cleanupConnection)
                {
                    connection = GetConnection(connectionString);
                    connection.Open();
                }
                // If transaction is not opened before call, begin it
                if (cleanupTransaction)
                {
                    transaction = connection.BeginTransaction();
                }

                result = UpdateAllLikeImplementation(comparator, instance, connection, transaction);

                // Commit the transaction
                if (cleanupTransaction)
                {
                    transaction.Commit();
                }
                // Close the connection if instantiated here
                if (cleanupConnection)
                {
                    connection.Close();
                }
            }
            catch (Exception exception)
            {
                // Try to rollback the transaction if needed
                try
                {
                    if (cleanupTransaction && transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                catch (Exception inException)
                {

                }
                // Try to close the connection if needed
                try
                {
                    if (cleanupConnection && connection != null)
                    {
                        connection.Close();
                    }
                }
                catch (Exception inException)
                {

                }
            }

            return result;
        }

        protected abstract long UpdateAllLikeImplementation(T comparator, T instance, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction);
        #endregion

        #region Remove Wrappers
        public long RemoveAllLike(T comparator, string connectionString)
        {
            return RemoveAllLike(comparator, null, null, connectionString);
        }

        public long RemoveAllLike(T comparator, System.Data.Common.DbConnection connection)
        {
            return RemoveAllLike(comparator, connection, null, null);
        }

        public long RemoveAllLike(T comparator, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction)
        {
            return RemoveAllLike(comparator, connection, transaction, null);
        }

        protected long RemoveAllLike(T comparator, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction, string connectionString)
        {
            // We cleanup only connection and transactions that we internally create within method
            bool cleanupConnection = connection == null;
            bool cleanupTransaction = transaction == null;

            long result = -1;
            try
            {
                // If connection is not initialized before call, initialize it
                if (cleanupConnection)
                {
                    connection = GetConnection(connectionString);
                    connection.Open();
                }
                // If transaction is not opened before call, begin it
                if (cleanupTransaction)
                {
                    transaction = connection.BeginTransaction();
                }

                result = RemoveAllLikeImplementation(comparator, connection, transaction);

                // Commit the transaction
                if (cleanupTransaction)
                {
                    transaction.Commit();
                }
                // Close the connection if instantiated here
                if (cleanupConnection)
                {
                    connection.Close();
                }
            }
            catch (Exception exception)
            {
                // Try to rollback the transaction if needed
                try
                {
                    if (cleanupTransaction && transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                catch (Exception inException)
                {

                }
                // Try to close the connection if needed
                try
                {
                    if (cleanupConnection && connection != null)
                    {
                        connection.Close();
                    }
                }
                catch (Exception inException)
                {

                }
            }

            return result;
        }

        protected abstract long RemoveAllLikeImplementation(T comparator, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction);

        #endregion

        #region Count Wrappers
        public long CountAllLike(T comparator, string connectionString)
        {
            return CountAllLike(comparator, null, null, connectionString);
        }

        public long CountAllLike(T comparator, System.Data.Common.DbConnection connection)
        {
            return CountAllLike(comparator, connection, null, null);
        }

        public long CountAllLike(T comparator, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction)
        {
            return CountAllLike(comparator, connection, transaction, null);
        }

        protected long CountAllLike(T comparator, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction, string connectionString)
        {
            // We cleanup only connection and transactions that we internally create within method
            bool cleanupConnection = connection == null;
            bool cleanupTransaction = transaction == null;

            long result = -1;
            try
            {
                // If connection is not initialized before call, initialize it
                if (cleanupConnection)
                {
                    connection = GetConnection(connectionString);
                    connection.Open();
                }
                // If transaction is not opened before call, begin it
                if (cleanupTransaction)
                {
                    transaction = connection.BeginTransaction();
                }

                result = CountAllLikeImplementation(comparator, connection, transaction);

                // Commit the transaction
                if (cleanupTransaction)
                {
                    transaction.Commit();
                }
                // Close the connection if instantiated here
                if (cleanupConnection)
                {
                    connection.Close();
                }
            }
            catch (Exception exception)
            {
                // Try to rollback the transaction if needed
                try
                {
                    if (cleanupTransaction && transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                catch (Exception inException)
                {

                }
                // Try to close the connection if needed
                try
                {
                    if (cleanupConnection && connection != null)
                    {
                        connection.Close();
                    }
                }
                catch (Exception inException)
                {

                }
            }

            return result;
        }

        protected abstract long CountAllLikeImplementation(T comparator, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction);

        #endregion

        #region Exists Wrappers
        public bool ExistsAllLike(T comparator, string connectionString)
        {
            return ExistsAllLike(comparator, null, null, connectionString);
        }

        public bool ExistsAllLike(T comparator, System.Data.Common.DbConnection connection)
        {
            return ExistsAllLike(comparator, connection, null, null);
        }

        public bool ExistsAllLike(T comparator, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction)
        {
            return ExistsAllLike(comparator, connection, transaction, null);
        }

        protected bool ExistsAllLike(T comparator, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction, string connectionString)
        {
            // We cleanup only connection and transactions that we internally create within method
            bool cleanupConnection = connection == null;
            bool cleanupTransaction = transaction == null;

            bool result = false;
            try
            {
                // If connection is not initialized before call, initialize it
                if (cleanupConnection)
                {
                    connection = GetConnection(connectionString);
                    connection.Open();
                }
                // If transaction is not opened before call, begin it
                if (cleanupTransaction)
                {
                    transaction = connection.BeginTransaction();
                }

                result = ExistsAllLikeImplementation(comparator, connection, transaction);

                // Commit the transaction
                if (cleanupTransaction)
                {
                    transaction.Commit();
                }
                // Close the connection if instantiated here
                if (cleanupConnection)
                {
                    connection.Close();
                }
            }
            catch (Exception exception)
            {
                // Try to rollback the transaction if needed
                try
                {
                    if (cleanupTransaction && transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                catch (Exception inException)
                {

                }
                // Try to close the connection if needed
                try
                {
                    if (cleanupConnection && connection != null)
                    {
                        connection.Close();
                    }
                }
                catch (Exception inException)
                {

                }
            }

            return result;
        }

        protected abstract bool ExistsAllLikeImplementation(T comparator, System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction);

        #endregion
    }
}
