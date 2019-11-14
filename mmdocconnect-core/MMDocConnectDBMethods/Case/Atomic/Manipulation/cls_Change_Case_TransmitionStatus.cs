/* 
 * Generated on 8/19/2015 9:19:40 AM
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
using CL1_BIL;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Change_Case_TransmitionStatus.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Change_Case_TransmitionStatus
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_CAS_CCTS_1001 Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CCTS_1001 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_CAS_CCTS_1001();
            returnValue.Result = new CAS_CCTS_1001();


            var StatusForCase = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
            {
                IsDeleted = false,
                IsActive = true,
                Tenant_RefID = securityTicket.TenantID,
                BIL_BillPosition_TransmitionStatusID = Parameter.BIL_BillPosition_TransmitionStatusID
            }).SingleOrDefault();
            if (!Parameter.AreCasesPaymentAndStatus)
            {
                if (StatusForCase != null)
                {
                    returnValue.Result.Old_Status_Modification_Timestamp = StatusForCase.Modification_Timestamp;

                    StatusForCase.Modification_Timestamp = DateTime.Now;
                    StatusForCase.IsActive = false;
                    StatusForCase.Save(Connection, Transaction);
                    returnValue.Result.New_Status_Modification_Timestamp = StatusForCase.Modification_Timestamp;

                    var NewStatusForCase = new ORM_BIL_BillPosition_TransmitionStatus();
                    NewStatusForCase.IsDeleted = false;
                    NewStatusForCase.Creation_Timestamp = DateTime.Now;
                    NewStatusForCase.Modification_Timestamp = DateTime.Now;
                    NewStatusForCase.Tenant_RefID = securityTicket.TenantID;
                    NewStatusForCase.IsActive = true;
                    NewStatusForCase.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                    NewStatusForCase.BillPosition_RefID = StatusForCase.BillPosition_RefID;
                    NewStatusForCase.TransmitionCode = Convert.ToInt32(Parameter.StatusTo);
                    NewStatusForCase.TransmittedOnDate = DateTime.Now;

                    NewStatusForCase.TransmitionStatusKey = StatusForCase.TransmitionStatusKey;
                    NewStatusForCase.Save(Connection, Transaction);
                    returnValue.Result.New_BIL_BillPosition_TransmitionStatusID = NewStatusForCase.BIL_BillPosition_TransmitionStatusID;
                }

            }



            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_CAS_CCTS_1001 Invoke(string ConnectionString, P_CAS_CCTS_1001 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_CCTS_1001 Invoke(DbConnection Connection, P_CAS_CCTS_1001 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_CCTS_1001 Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CCTS_1001 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_CCTS_1001 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CCTS_1001 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_CCTS_1001 functionReturn = new FR_CAS_CCTS_1001();
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

                throw new Exception("Exception occured in method cls_Change_Case_TransmitionStatus", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_CCTS_1001 : FR_Base
    {
        public CAS_CCTS_1001 Result { get; set; }

        public FR_CAS_CCTS_1001() : base() { }

        public FR_CAS_CCTS_1001(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_CAS_CCTS_1001 for attribute P_CAS_CCTS_1001
    [DataContract]
    public class P_CAS_CCTS_1001
    {
        //Standard type parameters
        [DataMember]
        public Guid BIL_BillPosition_TransmitionStatusID { get; set; }
        [DataMember]
        public int StatusTo { get; set; }
        [DataMember]
        public Boolean AreCasesPaymentAndStatus { get; set; }

    }
    #endregion
    #region SClass CAS_CCTS_1001 for attribute CAS_CCTS_1001
    [DataContract]
    public class CAS_CCTS_1001
    {
        //Standard type parameters
        [DataMember]
        public DateTime Old_Status_Modification_Timestamp { get; set; }
        [DataMember]
        public DateTime New_Status_Modification_Timestamp { get; set; }
        [DataMember]
        public Guid New_BIL_BillPosition_TransmitionStatusID { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_CCTS_1001 cls_Change_Case_TransmitionStatus(,P_CAS_CCTS_1001 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_CCTS_1001 invocationResult = cls_Change_Case_TransmitionStatus.Invoke(connectionString,P_CAS_CCTS_1001 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_CCTS_1001();
parameter.BIL_BillPosition_TransmitionStatusID = ...;
parameter.StatusTo = ...;
parameter.AreCasesPaymentAndStatus = ...;

*/
