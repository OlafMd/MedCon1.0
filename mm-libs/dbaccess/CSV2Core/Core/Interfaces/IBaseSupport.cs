using System.Data.Common;

namespace CSV2Core.Core.Interfaces
{
    /// <summary>
    /// This generic interface declares method wrappers that provide basic operations over entities.
    /// </summary>
    /// <typeparam name="T">Generic parameter type must implement <code>IBaseClass</code> interface.</typeparam>
    public interface IBaseSupport<T> where T: IBaseClass
    {
        #region Get Wrappers
        /// <summary>
        /// Method uses connection string to open the connection and start transaction to database. It then retreives
        /// all entities that satisfy the given comparator, and returns them.
        /// </summary>
        /// <param name="comparator">Comparator that entities must satisfy.</param>
        /// <param name="connectionString">Connection string to establish connection to database.</param>
        /// <returns>A static array containing all the entities that satisfy the given comparator.</returns>
        T[] GetAllLike(T comparator, string connectionString);

        /// <summary>
        /// Method uses existing connection to database to start a transaction. It then retreives 
        /// all entities that satisfy the given comparator, and returns them.
        /// </summary>
        /// <param name="comparator">Comparator that entities must satisfy.</param>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <returns>A static array containing all the entities that satisfy the given comparator.</returns>
        T[] GetAllLike(T comparator, DbConnection connection);

        /// <summary>
        /// Method uses existing connection and transaction to retreive all entities that satisfy the given
        /// comparator, and returns them.
        /// </summary>
        /// <param name="comparator">Comparator that entities must satisfy.</param>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <param name="transaction">Database transaction used (must be started).</param>
        /// <returns>A static array containing all the entities that satisfy the given comparator.</returns>
        T[] GetAllLike(T comparator, DbConnection connection, DbTransaction transaction);
        #endregion

        #region Update Wrappers
        /// <summary>
        /// Method uses connection string to open the connection and start transaction to database. It then updates
        /// all entities that satisfy the given comparator and returns the number of entities updated.
        /// </summary>
        /// <param name="comparator">Comparator that entities must satisfy.</param>
        /// <param name="instance">Instance containing new data values that entities should contain after update.</param>
        /// <param name="connectionString">Connection string to establish connection to database.</param>
        /// <returns>Number of entities updated.</returns>
        long UpdateAllLike(T comparator, T instance, string connectionString);

        /// <summary>
        /// Method uses existing connection to database to start a transaction. It then updates 
        /// all entities that satisfy the given comparator and returns the number of entities updated.
        /// </summary>
        /// <param name="comparator">Comparator that entities must satisfy.</param>
        /// <param name="instance">Instance containing new data values that entities should contain after update.</param>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <returns>Number of entities updated.</returns>
        long UpdateAllLike(T comparator, T instance, DbConnection connection);

        /// <summary>
        /// Method uses existing connection and transaction to update all entities that satisfy the given 
        /// comparator, and returns the number of entities updated.
        /// </summary>
        /// <param name="comparator">Comparator that entities must satisfy.</param>
        /// <param name="instance">Instance containing new data values that entities should contain after update.</param>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <param name="transaction">Database transaction used (must be started).</param>
        /// <returns>Number of entities updated.</returns>
        long UpdateAllLike(T comparator, T instance, DbConnection connection, DbTransaction transaction);
        #endregion

        #region Remove Wrappers
        /// <summary>
        /// Method uses connection string to open the connection and start transaction to database. It then removes
        /// all entities that satisfy the given comparator and returns the number of entities removed.
        /// </summary>
        /// <param name="comparator">Comparator that entities must satisfy.</param>
        /// <param name="connectionString">Connection string to establish connection to database.</param>
        /// <returns>Number of entities removed.</returns>
        long RemoveAllLike(T comparator, string connectionString);

        /// <summary>
        /// Method uses existing connection to database to start a transaction. It then removes
        /// all entities that satisfy the given comparator and returns the number of entities removed.
        /// </summary>
        /// <param name="comparator">Comparator that entities must satisfy.</param>
        /// <param name="connection">Database connection used (must be used).</param>
        /// <returns>Number of entities removed.</returns>
        long RemoveAllLike(T comparator, DbConnection connection);

        /// <summary>
        /// Method uses existing connection and transaction to remove all entities that satisfy the given
        /// comparator, and returns the number of entities removed.
        /// </summary>
        /// <param name="comparator">Comparator that entities must satisfy.</param>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <param name="transaction">Database transaction used (must be started).</param>
        /// <returns>Number of entities removed.</returns>
        long RemoveAllLike(T comparator, DbConnection connection, DbTransaction transaction);
        #endregion

        #region Count Wrappers
        /// <summary>
        /// Method uses connection string to open the connection and start transaction to database. It then counts
        /// all entities that satisfy the given comparator and returns the number of them.
        /// </summary>
        /// <param name="comparator">Comparator that entities must satisfy.</param>
        /// <param name="connectionString">Connection string to establish connection to database.</param>
        /// <returns>Number of entities that satisfy the given comparator.</returns>
        long CountAllLike(T comparator, string connectionString);

        /// <summary>
        /// Method uses existing connection to database to start a transaction. It then counts
        /// all entities that satisfy the given comparator and returns the number of them.
        /// </summary>
        /// <param name="comparator">Comparator that entities must satisfy.</param>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <returns>Number of entities that satisfy the given comparator.</returns>
        long CountAllLike(T comparator, DbConnection connection);

        /// <summary>
        /// Method uses existing connection and transaction to count all entities that satisfy
        /// the given comparator and returns the number of them.
        /// </summary>
        /// <param name="comparator">Comparator that entities must satisfy.</param>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <param name="transaction">Database transaction used (must be started).</param>
        /// <returns>Number of entities that satisfy the given comparator.</returns>
        long CountAllLike(T comparator, DbConnection connection, DbTransaction transaction);
        #endregion

        #region Exists Wrappers
        /// <summary>
        /// Method uses connection string to open the connection and start transaction to database. It then checks
        /// if an entity exists that satisfy the given comparator.
        /// </summary>
        /// <param name="comparator">Comparator that entity must satisfy.</param>
        /// <param name="connectionString">Connection string to establish connection to database.</param>
        /// <returns><code>true</code> if an entity exists that satisfies the given comparator; <code>false</code> otherwise.</returns>
        bool ExistsAllLike(T comparator, string connectionString);

        /// <summary>
        /// Method uses existing connection to database to start a transaction. It then checks 
        /// if an entity exists that satisfy the given comparator.
        /// </summary>
        /// <param name="comparator">Comparator that entity must satisfy.</param>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <returns><code></code> if an entity exists that satisfies the given comparator; <code>false</code> otherwise.</returns>
        bool ExistsAllLike(T comparator, DbConnection connection);

        /// <summary>
        /// Method uses existing connection and transaction to check if an entity exists that satisfy the given
        /// comparator.
        /// </summary>
        /// <param name="comparator">Comparator that entity must satisfy.</param>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <param name="transaction">Database transaction used (must be started).</param>
        /// <returns><code>true</code> if an entity exists that satisfies the given comparator; <code>false</code> otherwise.</returns>
        bool ExistsAllLike(T comparator, DbConnection connection, DbTransaction transaction);
        #endregion
    }
}
