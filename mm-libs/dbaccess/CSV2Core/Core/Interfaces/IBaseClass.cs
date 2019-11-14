using System;
using System.Data.Common;

namespace CSV2Core.Core.Interfaces
{
    public interface IBaseClass
    {
        /// <summary>
        /// Method is used to clear all variables and set them to thier default value.
        /// </summary>
        void Clear();


        #region Save Wrappers
        /// <summary>
        /// Opens the connection and transaction, saves the entity and then closes the connection and commits the transaction.
        /// </summary>
        /// <example>
        /// ORM_TestClass test = new ORM_TestClass();
        /// test.Parameter1 = ...;
        /// test.Save(connectionString);
        /// </example>
        /// <exception cref="System.Exception">Throws exception if any exception occured during execution</exception>
        /// <param name="connectionString">Connection string to the database</param>
        /// <returns>Method return object of the class</returns>
        void Save(string connectionString);

        /// <summary>
        /// Uses the existing connection to open up a transaction, saves the entity and commits the open transaction
        /// </summary>
        /// <example>
        /// ORM_TestClass test = new ORM_TestClass();
        /// test.Parameter1 = ...;
        /// test.Save(databaseConnection); 
        /// Note: Database connection must be open
        /// </example>
        /// <param name="connection">Database Connection (must be open)</param>
        void Save(DbConnection connection);

        /// <summary>
        /// Uses the existing connection and transaction to save the entity
        /// </summary>
        /// <param name="connection">Database Connection (must be open)</param>
        /// <param name="transaction">Database Transaction (must be started)</param>
        void Save(DbConnection connection, DbTransaction transaction);

        #endregion

        #region Load Wrappers
        /// <summary>
        /// Opens the connection and transaction and loads the entity.
        /// </summary>
        /// <param name="connectionString">Connection string to establish connection to database.</param>
        /// <param name="identifier">Identifier of entity about to be loaded.</param>
        void Load(string connectionString, Guid identifier);

        /// <summary>
        /// Uses the existing connection to open up a transaction and loads the entity.
        /// </summary>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <param name="identifier">Identifier of entity about to be loaded.</param>
        void Load(DbConnection connection, Guid identifier);

        /// <summary>
        /// Uses the existing connection and transaction and loads the entity.
        /// </summary>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <param name="transaction">Database transaction used (must be started).</param>
        /// <param name="identifier">Identifier of entity about to be loaded.</param>
        void Load(DbConnection connection, DbTransaction transaction, Guid identifier);

        #endregion

        #region Remove Wrappers

        /// <summary>
        /// Opens the connection and transaction and removes the entity.
        /// </summary>
        /// <param name="connectionString">Connection string to establish connection to database.</param>
        /// <param name="identifier">Identifier of entity about to be removed.</param>
        void Remove(string connectionString);

        /// <summary>
        /// Uses the existing connection to open up a transaction and removes the entity.
        /// </summary>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <param name="identifier">Identifier of entity about to be removed.</param>
        void Remove(DbConnection connection);

        /// <summary>
        /// Uses the existing connection and transaction and removes the entity.
        /// </summary>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <param name="transaction">Database transaction used (must be started).</param>
        /// <param name="identifier">Identifier of entity about to be removed.</param>
        void Remove(DbConnection connection, DbTransaction transaction);

        #endregion

        #region Exist Wrappers
        /// <summary>
        /// Opens the connection and transaction and checks if an entity with the given identifier exists.
        /// </summary>
        /// <param name="connectionString">Connection string to establish connection to database.</param>
        /// <param name="identifier">Identifier of entity about to be checked for existence.</param>
        bool Exists(string connectionString, Guid identifier);

        /// <summary>
        /// Uses the existing connection to open up a transaction and cheks if an entity with the given
        /// identifier exists.
        /// </summary>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <param name="identifier">Identifier of entity about to be checked for existence.</param>
        bool Exists(DbConnection connection, Guid identifier);

        /// <summary>
        /// Uses the existing connection and transaction to check if an entity with the given identifier
        /// exists.
        /// </summary>
        /// <param name="connection">Database connection used (must be open).</param>
        /// <param name="transaction">Database transaction used (must be started).</param>
        /// <param name="identifier">Identifier of entity about to be checked for existence.</param>
        bool Exists(DbConnection connection, DbTransaction transaction, Guid identifier);
        #endregion
    }
}
