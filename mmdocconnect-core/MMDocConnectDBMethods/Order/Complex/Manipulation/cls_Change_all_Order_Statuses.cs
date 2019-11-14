/* 
 * Generated on 3/14/2017 10:53:16 AM
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
using MMDocConnectDBMethods.Order.Atomic.Retrieval;
using CL1_ORD_PRC;

namespace MMDocConnectDBMethods.Order.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Change_all_Order_Statuses.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Change_all_Order_Statuses
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_OR_CAOS_1424 Execute(DbConnection Connection, DbTransaction Transaction, P_OR_CAOS_1424 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_OR_CAOS_1424();
            returnValue.Result = new OR_CAOS_1424();
            //Put your code here
            var statuses = new List<string>();
            statuses.Add(Parameter.Status_From.ToString());

            var ordersForChange = cls_Get_all_Orders_with_Status.Invoke(Connection, Transaction, new P_OR_GOwS_1428() { Status = statuses.ToArray() }, securityTicket).Result;

            #region Create Orders Report
            if (Parameter.Status_To_Str == "MO2")
            {
                returnValue.Result.ReportURL = cls_Create_Orders_Report.Invoke(Connection, Transaction, new P_OR_COR_1437 { GroupByPharmacy = true, Statuses = new int[] { 1, 6 } }, securityTicket).Result;

                //Check with Nemanja what this code shoud to do, it is same as code in cls_Change_Order_Status and it was in cls_Create_Orders_Report
                #region change status
                var statusDeleted = 6;
                var ordersForChangeDeleted = cls_Get_all_Orders_with_Status.Invoke(Connection, Transaction, new P_OR_GOwS_1428() { Status = new string[] { statusDeleted.ToString() } }, securityTicket).Result;

                foreach (var order in ordersForChangeDeleted)
                {
                    var procurmentHeader = ORM_ORD_PRC_ProcurementOrder_Header.Query.Search(Connection, Transaction, new ORM_ORD_PRC_ProcurementOrder_Header.Query()
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                        ORD_PRC_ProcurementOrder_HeaderID = order.OrderID
                    }).Single();

                    var newOrderStatus = new ORM_ORD_PRC_ProcurementOrder_Status();
                    newOrderStatus.Tenant_RefID = securityTicket.TenantID;
                    newOrderStatus.Status_Code = 7;

                    newOrderStatus.Save(Connection, Transaction);

                    var newOrderStatusHistory = new ORM_ORD_PRC_ProcurementOrder_StatusHistory();
                    newOrderStatusHistory.Tenant_RefID = securityTicket.TenantID;
                    newOrderStatusHistory.ProcurementOrder_Status_RefID = newOrderStatus.ORD_PRC_ProcurementOrder_StatusID;
                    newOrderStatusHistory.IsStatus_RejectedBySupplier = true;
                    newOrderStatusHistory.ProcurementOrder_Header_RefID = procurmentHeader.ORD_PRC_ProcurementOrder_HeaderID;

                    newOrderStatusHistory.Save(Connection, Transaction);

                    procurmentHeader.Current_ProcurementOrderStatus_RefID = newOrderStatus.ORD_PRC_ProcurementOrder_StatusID;
                    procurmentHeader.Save(Connection, Transaction);
                }
                #endregion
            }
            #endregion

            if (ordersForChange.Any())
            {
                P_OR_COS_0840 param = new P_OR_COS_0840()
                {
                    ParameterArray = ordersForChange.Select(order =>
                    {
                        P_OR_COS_0840a parameter = new P_OR_COS_0840a();
                        parameter.CaseID = order.CaseID;
                        parameter.Order_ID = order.OrderID;
                        parameter.Status_To = Parameter.Status_To;
                        parameter.Status_To_Str = Parameter.Status_To_Str;

                        return parameter;
                    }).ToArray()
                };

                var data = cls_Change_Order_Status.Invoke(Connection, Transaction, param, securityTicket);
            }

            returnValue.Result.Orders = ordersForChange;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_OR_CAOS_1424 Invoke(string ConnectionString, P_OR_CAOS_1424 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_OR_CAOS_1424 Invoke(DbConnection Connection, P_OR_CAOS_1424 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_OR_CAOS_1424 Invoke(DbConnection Connection, DbTransaction Transaction, P_OR_CAOS_1424 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_OR_CAOS_1424 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_OR_CAOS_1424 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_OR_CAOS_1424 functionReturn = new FR_OR_CAOS_1424();
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

                throw new Exception("Exception occured in method cls_Change_all_Order_Statuses", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_OR_CAOS_1424 : FR_Base
    {
        public OR_CAOS_1424 Result { get; set; }

        public FR_OR_CAOS_1424() : base() { }

        public FR_OR_CAOS_1424(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_OR_CAOS_1424 for attribute P_OR_CAOS_1424
    [DataContract]
    public class P_OR_CAOS_1424
    {
        //Standard type parameters
        [DataMember]
        public int Status_From { get; set; }
        [DataMember]
        public int Status_To { get; set; }
        [DataMember]
        public String Status_To_Str { get; set; }

    }
    #endregion
    #region SClass OR_CAOS_1424 for attribute OR_CAOS_1424
    [DataContract]
    public class OR_CAOS_1424
    {
        //Standard type parameters
        [DataMember]
        public OR_GOwS_1428[] Orders { get; set; }
        [DataMember]
        public String ReportURL { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_OR_CAOS_1424 cls_Change_all_Order_Statuses(,P_OR_CAOS_1424 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_OR_CAOS_1424 invocationResult = cls_Change_all_Order_Statuses.Invoke(connectionString,P_OR_CAOS_1424 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Order.Complex.Manipulation.P_OR_CAOS_1424();
parameter.Status_From = ...;
parameter.Status_To = ...;
parameter.Status_To_Str = ...;

*/
