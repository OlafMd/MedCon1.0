/* 
 * Generated on 18.1.2015 20:57:55
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
using CL6_MRMS_Backoffice.Utils;
using CL1_MRS_RUN;

namespace CL6_MRMS_Backoffice.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Publish_Reading_Session.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Publish_Reading_Session
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Base Execute(DbConnection Connection, DbTransaction Transaction, P_L6MRMS_PRS_1946 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            Random _rng = new Random((int)DateTime.Now.Ticks);
            string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //0123456789abcdefghijklmnopqrstuvwxyz";
            int loopCountMax = 100;
            int loopCounter = 0;

            #region UserCode
            var returnValue = new FR_Base();

            var status = ORM_MRS_RUN_MeasurementRun_Status.Query.Search(Connection, Transaction, new ORM_MRS_RUN_MeasurementRun_Status.Query()
            {
                GlobalPropertyMatchingID = Parameter.GlobalPropertyMatchingId,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            var run = ORM_MRS_RUN_MeasurementRun.Query.Search(Connection, Transaction, new ORM_MRS_RUN_MeasurementRun.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                MRS_RUN_MeasurementRunID = Parameter.ReadingSessionId
            }).Single();

            run.CurrentStatus_RefID = status.MRS_RUN_MeasurementRun_StatusID;
            run.Save(Connection, Transaction);

            var account = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                USR_AccountID = securityTicket.AccountID
            }).Single();


            var runHistory = new ORM_MRS_RUN_MeasurementRun_StatusHistory()
            {
                Tenant_RefID = securityTicket.TenantID,
                MRS_RUN_MeasurementRun_StatusHistoryID = Guid.NewGuid(),
                MeasurementRun_Status_RefID = status.MRS_RUN_MeasurementRun_StatusID,
                TriggeredBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID,
                MeasurementRun_RefID = run.MRS_RUN_MeasurementRunID,
                Comment = string.Empty
            };
            runHistory.Save(Connection, Transaction);

            var runRoutes = ORM_MRS_RUN_MeasurementRun_Route.Query.Search(Connection, Transaction, new ORM_MRS_RUN_MeasurementRun_Route.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                MeasurementRun_RefID = run.MRS_RUN_MeasurementRunID,
                IsDeleted = false
            }).ToArray();

            var distinctReaderBP = runRoutes.Select(s => s.BoundTo_Account_RefID).Distinct();

            foreach(var readerBP in distinctReaderBP)
            {
                bool uniqueFlag = false;
                string codeValue;

                do
                {
                    loopCounter++;
                    if (loopCounter > loopCountMax)
                        return null;

                    char[] buffer = new char[6];
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        buffer[i] = _chars[_rng.Next(_chars.Length)];
                    }
                    codeValue = new string(buffer);
                    codeValue = codeValue.ToLower();

                    var codes = ORM_MRS_RUN_MeasurementRun_AccountDownloadCode.Query.Search(
                        Connection, 
                        Transaction, 
                        new ORM_MRS_RUN_MeasurementRun_AccountDownloadCode.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            DownloadCode = codeValue
                        });
                    if (codes.Count == 0)
                        uniqueFlag = true;
                } while (!uniqueFlag);

                var runCode = new ORM_MRS_RUN_MeasurementRun_AccountDownloadCode()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    Account_RefID = readerBP,
                    MRS_RUN_MeasurementRun_AccountDownloadCodeID = Guid.NewGuid(),
                    ValidFrom = DateTime.Now,
                    ValidThrough = DateTime.MaxValue,
                    MeasurementRun_RefID = run.MRS_RUN_MeasurementRunID,
                    DownloadCode = codeValue
                };
                runCode.Save(Connection, Transaction);
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Base Invoke(string ConnectionString, P_L6MRMS_PRS_1946 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, P_L6MRMS_PRS_1946 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, P_L6MRMS_PRS_1946 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L6MRMS_PRS_1946 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Publish_Reading_Session", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L6MRMS_PRS_1946 for attribute P_L6MRMS_PRS_1946
    [DataContract]
    public class P_L6MRMS_PRS_1946
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
FR_Base cls_Publish_Reading_Session(,P_L6MRMS_PRS_1946 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Publish_Reading_Session.Invoke(connectionString,P_L6MRMS_PRS_1946 Parameter,securityTicket);
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
var parameter = new CL6_MRMS_Backoffice.Complex.Manipulation.P_L6MRMS_PRS_1946();
parameter.ReadingSessionId = ...;
parameter.GlobalPropertyMatchingId = ...;

*/
