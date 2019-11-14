/* 
 * Generated on 3/19/2014 1:22:15 PM
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

namespace CL2_InventoryCountingRun.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_InventoryJob_CountingRun.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_InventoryJob_CountingRun
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2IR_SCR_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

          var returnValue = new FR_Guid();

          var item = new CL1_LOG_WRH_INJ.ORM_LOG_WRH_INJ_InventoryJob_CountingRun();
          if (Parameter.LOG_WRH_INJ_InventoryJob_CountingRunID != Guid.Empty)
          {
                var result = item.Load(Connection, Transaction, Parameter.LOG_WRH_INJ_InventoryJob_CountingRunID);
                if (result.Status != FR_Status.Success || item.LOG_WRH_INJ_InventoryJob_CountingRunID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status =  FR_Status.Error_Internal;
                    return error;
                }
          }

          if(Parameter.IsDeleted == true){
              item.IsDeleted = true;
              return new FR_Guid(item.Save(Connection, Transaction),item.LOG_WRH_INJ_InventoryJob_CountingRunID);
          }

          //Creation specific parameters (Tenant, Account ... )
          if (Parameter.LOG_WRH_INJ_InventoryJob_CountingRunID == Guid.Empty)
          {
             item.Tenant_RefID = securityTicket.TenantID;
          }

          item.InventoryJob_Process_RefID = Parameter.InventoryJob_Process_RefID;
          item.ExecutingBusinessParticipant_RefID = Parameter.ExecutingBusinessParticipant_RefID;
          item.SequenceNumber = Parameter.SequenceNumber;
          if (Parameter.IsCounting_Started != null)
          {
              item.IsCounting_Started = Parameter.IsCounting_Started.Value;
          }
          if (Parameter.IsCounting_Completed != null)
          {
              item.IsCounting_Completed = Parameter.IsCounting_Completed.Value;
          }
          if (Parameter.IsCountingListPrinted  != null)
          {
              item.IsCountingListPrinted = Parameter.IsCountingListPrinted.Value;
          }
          if (Parameter.IsDifferenceFound != null)
          {
              item.IsDifferenceFound = Parameter.IsDifferenceFound.Value;
          }

          return new FR_Guid(item.Save(Connection, Transaction),item.LOG_WRH_INJ_InventoryJob_CountingRunID);
  
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString,P_L2IR_SCR_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString,Parameter,securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection,P_L2IR_SCR_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null,Parameter,securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2IR_SCR_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null,Parameter,securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2IR_SCR_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

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
                    if (cleanupTransaction == true && Transaction!=null)
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

                throw new Exception("Exception occured in method cls_Save_InventoryJob_CountingRun",ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
        #region SClass P_L2IR_SCR_1314 for attribute P_L2IR_SCR_1314
        [DataContract]
        public class P_L2IR_SCR_1314 
        {
            //Standard type parameters
            [DataMember]
            public Guid LOG_WRH_INJ_InventoryJob_CountingRunID { get; set; } 
            [DataMember]
            public Guid InventoryJob_Process_RefID { get; set; } 
            [DataMember]
            public Guid ExecutingBusinessParticipant_RefID { get; set; } 
            [DataMember]
            public int SequenceNumber { get; set; } 
            [DataMember]
            public Boolean? IsCounting_Started { get; set; } 
            [DataMember]
            public Boolean? IsCounting_Completed { get; set; } 
            [DataMember]
            public Boolean? IsCountingListPrinted { get; set; } 
            [DataMember]
            public Boolean? IsDifferenceFound { get; set; } 
            [DataMember]
            public Boolean IsDeleted { get; set; } 

        }
        #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_InventoryJob_CountingRun(,P_L2IR_SCR_1314 Parameter, string sessionToken = null)
{
    try
    {
        var securityTicket = Verify(sessionToken);
        FR_Guid invocationResult = cls_Save_InventoryJob_CountingRun.Invoke(connectionString,P_L2IR_SCR_1314 Parameter,securityTicket);
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
var parameter = new CL2_InventoryCountingRun.Atomic.Manipulation.P_L2IR_SCR_1314();
parameter.LOG_WRH_INJ_InventoryJob_CountingRunID = ...;
parameter.InventoryJob_Process_RefID = ...;
parameter.ExecutingBusinessParticipant_RefID = ...;
parameter.SequenceNumber = ...;
parameter.IsCounting_Started = ...;
parameter.IsCounting_Completed = ...;
parameter.IsCountingListPrinted = ...;
parameter.IsDifferenceFound = ...;
parameter.IsDeleted = ...;

*/
