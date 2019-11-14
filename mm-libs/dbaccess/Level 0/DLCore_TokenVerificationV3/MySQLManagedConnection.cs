using System.Data.Common;

namespace CSV2Core_MySQL
{
    public class MySQLManagedConnection : CSV2Core.Core.Interfaces.IManagedConnection
    {
        private static int QUERY_TIMEOUT = 15;

        private string _connectionString;
        private DbConnection _connection;
        private DbTransaction _transaction;


        private bool _manageConnection;
        private bool _manageTransaction;

        public MySQLManagedConnection()
        {

        }

        public MySQLManagedConnection(string connectionString)
        {
            _manageConnection = true;
            _manageTransaction = true;
            _connectionString = connectionString;
        }

        public void set(string connectionString, DbConnection connection, DbTransaction transaction)
        {
            _connectionString = connectionString;
            _connection = connection;
            _transaction = transaction;


            if (_transaction != null)
            {
                _manageConnection = false;
                _manageTransaction = false;
            }
            else if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _manageConnection = false;
                _manageTransaction = true;
            }
            else
            {
                _manageConnection = true;
                _manageTransaction = true;
            }

        }

        public void manage()
        {
            if (_manageConnection == true)
            {
                _connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(_connectionString);
                _connection.Open();
            }

            if (_manageTransaction == true)
            {
                _transaction = _connection.BeginTransaction();
            }
        }

        public DbCommand manage(string query)
        {
            manage();

            DbCommand command = _connection.CreateCommand();
            command.Connection = _connection;
            command.Transaction = _transaction;
            command.CommandText = query;
            command.CommandTimeout = QUERY_TIMEOUT;

            return command;
        }

        private void handleConnectionAndTransaction()
        {
         
        }


        public void commit()
        {
            if (_manageTransaction == true)
            {
                _transaction.Commit();
            }
            if (_manageConnection == true)
            {
                _connection.Close();
            }
        }

        public void rollback()
        {
            if (_manageTransaction == true)
            {
                try
                {

                    _transaction.Rollback();

                }
                catch { }
            }

            if (_manageConnection == true)
            {
                try
                {
                    _connection.Close();
                }
                catch { }
            }

        }

        public DbConnection getConnection()
        {
            return _connection;
        }

        public DbTransaction getTransaction()
        {
            return _transaction;
        }
    }
}
