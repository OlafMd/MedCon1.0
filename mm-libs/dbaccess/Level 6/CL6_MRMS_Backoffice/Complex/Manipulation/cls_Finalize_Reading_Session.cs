/* 
 * Generated on 18.1.2015 20:57:46
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
using CL1_MRS_MPT;
using CL1_USR;
using CL1_MRS_RUN;

namespace CL6_MRMS_Backoffice.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Finalize_Reading_Session.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Finalize_Reading_Session
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Base Execute(DbConnection Connection, DbTransaction Transaction, P_L6MRMS_FRS_1944 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Base();

            ORM_USR_Account userAccount = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
            {
                USR_AccountID = securityTicket.AccountID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).FirstOrDefault();

            if (userAccount == null)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.ErrorMessage = String.Format("FinalizeReadingSession Fault: User account with id {0} not found.", securityTicket.AccountID.ToString());
                return returnValue;
            }

            ORM_MRS_RUN_MeasurementRun measurementRun = ORM_MRS_RUN_MeasurementRun.Query.Search(Connection, Transaction, new ORM_MRS_RUN_MeasurementRun.Query()
            {
                MRS_RUN_MeasurementRunID = Parameter.ReadingSessionId,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).FirstOrDefault();

            if (measurementRun == null)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.ErrorMessage = String.Format("FinalizeReadingSession Fault: Measurement run with id {0} not found.", measurementRun.MRS_RUN_MeasurementRunID.ToString());
                return returnValue;
            }

            // Find status with global property matching id

            ORM_MRS_RUN_MeasurementRun_Status measurementRunStatus = ORM_MRS_RUN_MeasurementRun_Status.Query.Search(Connection, Transaction, new ORM_MRS_RUN_MeasurementRun_Status.Query()
            {
                GlobalPropertyMatchingID = Parameter.GlobalPropertyMatchingId,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).FirstOrDefault();

            if (measurementRunStatus == null)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.ErrorMessage = String.Format("FinalizeReadingSession Fault: Measurement run status with gpmid {0} not found.", Parameter.GlobalPropertyMatchingId);
                return returnValue;
            }

            // Create new status history
            ORM_MRS_RUN_MeasurementRun_StatusHistory measurementRunStatusHistory = new ORM_MRS_RUN_MeasurementRun_StatusHistory();
            measurementRunStatusHistory.Comment = "";
            measurementRunStatusHistory.Creation_Timestamp = DateTime.Now;
            measurementRunStatusHistory.IsDeleted = false;
            measurementRunStatusHistory.MeasurementRun_RefID = measurementRun.MRS_RUN_MeasurementRunID;
            measurementRunStatusHistory.MeasurementRun_Status_RefID = measurementRunStatus.MRS_RUN_MeasurementRun_StatusID;
            measurementRunStatusHistory.Modification_Timestamp = DateTime.Now;
            measurementRunStatusHistory.MRS_RUN_MeasurementRun_StatusHistoryID = Guid.NewGuid();
            measurementRunStatusHistory.Tenant_RefID = securityTicket.TenantID;
            measurementRunStatusHistory.TriggeredBy_BusinessParticipant_RefID = userAccount.BusinessParticipant_RefID;
            measurementRunStatusHistory.Save(Connection, Transaction);

            // Update measurement run status
            measurementRun.CurrentStatus_RefID = measurementRunStatus.MRS_RUN_MeasurementRun_StatusID;
            measurementRun.Save(Connection, Transaction);

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Base Invoke(string ConnectionString, P_L6MRMS_FRS_1944 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, P_L6MRMS_FRS_1944 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, P_L6MRMS_FRS_1944 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L6MRMS_FRS_1944 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Base functionReturn = new FR_Base();
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

                throw new Exception("Exception occured in method cls_Finalize_Reading_Session", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L6MRMS_FRS_1944 for attribute P_L6MRMS_FRS_1944
    [DataContract]
    public class P_L6MRMS_FRS_1944
    {
        //Standard type parameters
        [DataMember]
        public Guid ReadingSessionId { get; set; }
        [DataMember]
        public string GlobalPropertyMatchingId { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Finalize_Reading_Session(,P_L6MRMS_FRS_1944 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Finalize_Reading_Session.Invoke(connectionString,P_L6MRMS_FRS_1944 Parameter,securityTicket);
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
var parameter = new CL6_MRMS_Backoffice.Complex.Manipulation.P_L6MRMS_FRS_1944();
parameter.ReadingSessionId = ...;
parameter.GlobalPropertyMatchingId = ...;

*/
