/* 
 * Generated on 1/22/2013 12:15:23 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL1_TMS_PRO;

namespace CL2_Feature.Complex.Retrieval
{
    [Serializable]
    public class cls_Get_NewFeatureIdentifier
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L3FE_GNFI_1213 Execute(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_L3FE_GNFI_1213();
            returnValue.Result = new L3FE_GNFI_1213();

            ORM_TMS_PRO_Feature.Query query = new ORM_TMS_PRO_Feature.Query();
            query.Tenant_RefID = securityTicket.TenantID;
            var count = ORM_TMS_PRO_Feature.Query.Search(Connection, Transaction, query).Count() + 1;

            String identifier = "000000" + count.ToString();

            identifier = identifier.Substring(identifier.Length - 6);

            returnValue.Result.Identifier = identifier;

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L3FE_GNFI_1213 Invoke(string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L3FE_GNFI_1213 Invoke(DbConnection Connection, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L3FE_GNFI_1213 Invoke(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L3FE_GNFI_1213 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L3FE_GNFI_1213 functionReturn = new FR_L3FE_GNFI_1213();
            try
            {

                if (cleanupConnection == true)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction == true)
                {
                    Transaction = Connection.BeginTransaction();
                }

                functionReturn = Execute(Connection, Transaction, securityTicket);


                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction == true)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection == true)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction == true && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection == true && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw ex;
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L3FE_GNFI_1213 : FR_Base
    {
        public L3FE_GNFI_1213 Result { get; set; }

        public FR_L3FE_GNFI_1213() : base() { }

        public FR_L3FE_GNFI_1213(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass L3FE_GNFI_1213 for attribute L3FE_GNFI_1213
    [Serializable]
    public class L3FE_GNFI_1213
    {
        //Standard type parameters
        public String Identifier;

    }
    #endregion

    #endregion
}
