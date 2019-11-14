/* 
 * Generated on 10/1/2014 3:59:28 PM
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
using CL1_ORD_CUO;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL1_USR;

namespace CL3_CustomerOrder.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_AcceptOrder.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_AcceptOrder
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3CO_AO_1648 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            var confirmedStatus = ORM_ORD_CUO_CustomerOrder_Status.Query.Search(Connection, Transaction,
            new ORM_ORD_CUO_CustomerOrder_Status.Query
            {
                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(ECustomerOrderStatus.Confirmed),
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single().ORD_CUO_CustomerOrder_StatusID;

            var customerOrder = new ORM_ORD_CUO_CustomerOrder_Header();
            customerOrder.Load(Connection, Transaction, Parameter.CustomerOrderHeaderID);
            customerOrder.Current_CustomerOrderStatus_RefID = confirmedStatus;
            customerOrder.IsCustomerOrderFinalized = true;
            customerOrder.WasAutoApprovedUponReceipt = Parameter.IsAutomaticallyApprovedOnReceipt;

            ORM_USR_Account account = new ORM_USR_Account();
            account.Load(Connection, Transaction, securityTicket.AccountID);

            ORM_ORD_CUO_CustomerOrder_StatusHistory newStatusInHistory = new ORM_ORD_CUO_CustomerOrder_StatusHistory();
            newStatusInHistory.CustomerOrder_Header_RefID = customerOrder.ORD_CUO_CustomerOrder_HeaderID;
            newStatusInHistory.StatusHistoryComment = Parameter.Message;
            newStatusInHistory.Tenant_RefID = securityTicket.TenantID;
            newStatusInHistory.CustomerOrder_Status_RefID = confirmedStatus;
            newStatusInHistory.PerformedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID;
            newStatusInHistory.Save(Connection, Transaction);

            returnValue.Result = new FR_Guid(customerOrder.Save(Connection, Transaction), customerOrder.ORD_CUO_CustomerOrder_HeaderID).Result;

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3CO_AO_1648 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3CO_AO_1648 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CO_AO_1648 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CO_AO_1648 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_AcceptOrder",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3CO_AO_1648 for attribute P_L3CO_AO_1648
		[DataContract]
		public class P_L3CO_AO_1648 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 
			[DataMember]
			public String Message { get; set; } 
			[DataMember]
			public Boolean IsAutomaticallyApprovedOnReceipt { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_AcceptOrder(,P_L3CO_AO_1648 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_AcceptOrder.Invoke(connectionString,P_L3CO_AO_1648 Parameter,securityTicket);
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
var parameter = new CL3_CustomerOrder.Atomic.Manipulation.P_L3CO_AO_1648();
parameter.CustomerOrderHeaderID = ...;
parameter.Message = ...;
parameter.IsAutomaticallyApprovedOnReceipt = ...;

*/
