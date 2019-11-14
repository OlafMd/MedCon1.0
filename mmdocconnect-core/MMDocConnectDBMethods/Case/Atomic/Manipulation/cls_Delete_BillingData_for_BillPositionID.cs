/* 
 * Generated on 09/26/16 15:54:00
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
using CL1_HEC_BIL;
using CL1_HEC_CAS;
using CL1_BIL;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Delete_BillingData_for_BillPositionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Delete_BillingData_for_BillPositionID
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_DBDfHBPID_1549 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            var bill_position = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition.Query()
            {
                BIL_BillPositionID = Parameter.bill_position_id
            }).SingleOrDefault();

            if (bill_position == null)
            {
                throw new KeyNotFoundException(String.Format("Bill position not found for id: {0}", Parameter.bill_position_id));
            }

            bill_position.IsDeleted = true;
            bill_position.Modification_Timestamp = DateTime.Now;

            bill_position.Save(Connection, Transaction);

            var hec_bill_position = ORM_HEC_BIL_BillPosition.Query.Search(Connection, Transaction, new ORM_HEC_BIL_BillPosition.Query()
            {
                Ext_BIL_BillPosition_RefID = bill_position.BIL_BillPositionID
            }).SingleOrDefault();

            if (hec_bill_position == null)
            {
                throw new KeyNotFoundException(String.Format("Hec bill position not found for ref id: {0}", Parameter.bill_position_id));
            }

            hec_bill_position.IsDeleted = true;
            hec_bill_position.Modification_Timestamp = DateTime.Now;

            hec_bill_position.Save(Connection, Transaction);

            var hec_bill_position_bill_code = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(Connection, Transaction, new ORM_HEC_BIL_BillPosition_BillCode.Query()
            {
                BillPosition_RefID = hec_bill_position.HEC_BIL_BillPositionID
            }).SingleOrDefault();

            if (hec_bill_position_bill_code == null)
            {
                throw new KeyNotFoundException(String.Format("Hec bill position code not found for ref id: {0}", hec_bill_position.HEC_BIL_BillPositionID));
            }

            hec_bill_position_bill_code.IsDeleted = true;
            hec_bill_position_bill_code.Modification_Timestamp = DateTime.Now;

            hec_bill_position_bill_code.Save(Connection, Transaction);

            var hec_case_billcode = ORM_HEC_CAS_Case_BillCode.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_BillCode.Query()
            {
                HEC_BIL_BillPosition_BillCode_RefID = hec_bill_position_bill_code.HEC_BIL_BillPosition_BillCodeID
            }).SingleOrDefault();

            if (hec_case_billcode == null)
            {
                throw new KeyNotFoundException(String.Format("Hec case bill position code not found for ref id: {0}", hec_bill_position_bill_code.HEC_BIL_BillPosition_BillCodeID));
            }

            hec_case_billcode.IsDeleted = true;
            hec_case_billcode.Modification_Timestamp = DateTime.Now;

            hec_case_billcode.Save(Connection, Transaction);


            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_CAS_DBDfHBPID_1549 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_CAS_DBDfHBPID_1549 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_DBDfHBPID_1549 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_DBDfHBPID_1549 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guid functionReturn = new FR_Guid();
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

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

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

                throw new Exception("Exception occured in method Delete_BillingData_for_BillPositionID", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_DBDfHBPID_1549 for attribute P_CAS_DBDfHBPID_1549
    [DataContract]
    public class P_CAS_DBDfHBPID_1549
    {
        //Standard type parameters
        [DataMember]
        public Guid bill_position_id { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid Delete_BillingData_for_BillPositionID(,P_CAS_DBDfHBPID_1549 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = Delete_BillingData_for_BillPositionID.Invoke(connectionString,P_CAS_DBDfHBPID_1549 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_DBDfHBPID_1549();
parameter.hec_bill_position_id = ...;

*/
