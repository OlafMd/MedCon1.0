/* 
 * Generated on 06/18/15 10:03:07
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectUtils;
using CL1_BIL;

namespace MMDocConnectDBMethods.Case.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_Next_Bill_Position_Number.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_Next_Bill_Position_Number
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_CAS_GNBPN_1002 Execute(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_CAS_GNBPN_1002();
            var bill_position_number = "000000000000";

            var latest_bill_position = cls_Get_Latest_Bill_Position_Number.Invoke(Connection, Transaction, securityTicket).Result;

            if (latest_bill_position != null)
            {
                bill_position_number += string.IsNullOrEmpty(latest_bill_position.latest_bill_position_number) ? "1" : (int.Parse(latest_bill_position.latest_bill_position_number) + 1).ToString();
                bill_position_number = bill_position_number.Substring(bill_position_number.Length - 12, 12);
            }
            else
            {
                bill_position_number = "000000000001";
            }
            
            returnValue.Result = new CAS_GNBPN_1002();
            if (bill_position_number == "")
                throw new Exception("Something went wrong during bill position number generation");

            returnValue.Result.bill_position_number = bill_position_number;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_CAS_GNBPN_1002 Invoke(string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_GNBPN_1002 Invoke(DbConnection Connection, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_GNBPN_1002 Invoke(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_GNBPN_1002 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GNBPN_1002 functionReturn = new FR_CAS_GNBPN_1002();
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

                throw new Exception("Exception occured in method cls_Get_Next_Bill_Position_Number", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_GNBPN_1002 : FR_Base
    {
        public CAS_GNBPN_1002 Result { get; set; }

        public FR_CAS_GNBPN_1002() : base() { }

        public FR_CAS_GNBPN_1002(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass CAS_GNBPN_1002 for attribute CAS_GNBPN_1002
    [DataContract]
    public class CAS_GNBPN_1002
    {
        //Standard type parameters
        [DataMember]
        public String bill_position_number { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GNBPN_1002 cls_Get_Next_Bill_Position_Number(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GNBPN_1002 invocationResult = cls_Get_Next_Bill_Position_Number.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

