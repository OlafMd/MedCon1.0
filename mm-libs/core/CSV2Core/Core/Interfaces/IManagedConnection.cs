using System.Data.Common;

namespace CSV2Core.Core.Interfaces
{
    //TODO: More meaningfull comments
    /// <summary>
    /// Represents a connection object
    /// </summary>
    public interface IManagedConnection
    {
        /// <summary>
        /// Sets the specified connection string or connection and transaction pair
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <param name="connection">The connection</param>
        /// <param name="transaction">The transaction</param>
        void set(string connectionString, DbConnection connection, DbTransaction transaction);
        /// <summary>
        /// Manages this instance.
        /// </summary>
        DbCommand manage(string query);

        /// <summary>
        /// Manages this instance.
        /// </summary>
        void manage();

        /// <summary>
        /// Commits this instance and manages this instance
        /// </summary>
        void commit();
        /// <summary>
        /// Reverts this the connection or transaction
        /// </summary>
        void rollback();

        DbConnection getConnection();
        DbTransaction getTransaction();
    }
}
