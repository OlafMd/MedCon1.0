using System;
using System.Data.Common;
using MySql.Data.MySqlClient;
using CSV2Core.SessionSecurity;
//Stefan Martinov <stefan.martinov@danulabs.com>
//Danulabs 2012
namespace CSV2Core_MySQL.Support
{
    //CSV2Core_MySQL.Support.DBSQLSupport
    public class DBSQLSupport
    {
        /// <summary>
        /// InStatementRegion: table.field IN $$INSTATEMENT$$
        /// </summary>
        /// <param name="command"></param>
        /// <param name="field"></param>
        /// <param name="Parameters"></param>
        public static void AppendINStatement(DbCommand command, string InStatementRegion, Guid[] Parameters, string paramName = null)
        {
            if (paramName == null)
            {
                paramName = InStatementRegion.Trim('$');
            }

            string InStatement = CSV2Core.Support.SQLSupport.GenerateInStatement(Parameters, paramName);
            command.CommandText = command.CommandText.Replace(InStatementRegion, InStatement);
            for (int i = 0; i < Parameters.Length; i++)
            {
                DBSQLSupport.SetParameter(command, paramName + (i), Parameters[i]);
            }
        }

        public static void AppendINStatement(DbCommand command, string InStatementRegion, string[] Parameters, string paramName = null)
        {
            if (paramName == null)
            {
                paramName = InStatementRegion.Trim('$');
            }

            string InStatement = CSV2Core.Support.SQLSupport.GenerateInStatement(Parameters, paramName);
            command.CommandText = command.CommandText.Replace(InStatementRegion, InStatement);
            for (int i = 0; i < Parameters.Length; i++)
            {
                DBSQLSupport.SetParameter(command, paramName + (i), Parameters[i]);
            }
        }

        #region Connection Based
        public static DbConnection CreateConnection(String Connection)
        {
            return new MySqlConnection(Connection);
        }
        #endregion

        #region Parameter Manipulation
        /// <summary>
        /// General function for setting the parameters
        /// </summary>
        /// <param name="command">The created database command</param>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The value of the parameter</param>
        public static void SetParameter(DbCommand command, string name, object value)
        {

            var sqlCommand = (MySqlCommand)command;
            Type parameterType = (value == null ? null : value.GetType());
            //Set standard parameters            
            if (value is Guid)
            {
                DBSQLSupport.Guid_SetParameter(sqlCommand, name, (Guid)value);
            }
            else if (value is SessionSecurityTicket)
            {
                DBSQLSupport.Ticket_SetParameter(sqlCommand, name, value as SessionSecurityTicket);
            }
            else
            {
                DBSQLSupport.Standard_SetParameter(sqlCommand, name, value);
            }
        }

        protected static void Ticket_SetParameter(MySqlCommand command, string name, SessionSecurityTicket value)
        {
            if (value == null) return;

            Guid_SetParameter(command, "TenantID", value.TenantID);
            Guid_SetParameter(command, "AccountID", value.AccountID);
        }

        //Special Guid SetParameter
        protected static void Guid_SetParameter(MySqlCommand command, string name, Guid value)
        {
            command.Parameters.AddWithValue(name, value.ToByteArray());
        }

        protected static void Standard_SetParameter(MySqlCommand command, string name, object value)
        {
            if (value is string)
            {
                command.Parameters.AddWithValue(name, value);
            }
            else
            {
                command.Parameters.AddWithValue(name, value);
            }

        }

        #endregion
    }
}
