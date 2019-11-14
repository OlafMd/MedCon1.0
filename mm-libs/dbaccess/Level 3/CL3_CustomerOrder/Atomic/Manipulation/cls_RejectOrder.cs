/* 
 * Generated on 12/18/2013 11:02:12 AM
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
using CSV2Core.Core;
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
    /// var result = cls_RejectOrder.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_RejectOrder
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3CO_RO_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            var orderedStatusID = ORM_ORD_CUO_CustomerOrder_Status.Query.Search(Connection, Transaction,
            new ORM_ORD_CUO_CustomerOrder_Status.Query
            {
                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(ECustomerOrderStatus.Rejected),
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault().ORD_CUO_CustomerOrder_StatusID;

            var customerOrderQuery = new ORM_ORD_CUO_CustomerOrder_Header.Query();
            customerOrderQuery.ORD_CUO_CustomerOrder_HeaderID = Parameter.CustomerOrderHeaderID;
            customerOrderQuery.Tenant_RefID = securityTicket.TenantID;
            var foundCustomerOrder = ORM_ORD_CUO_CustomerOrder_Header.Query.Search(Connection, Transaction, customerOrderQuery).SingleOrDefault();

            foundCustomerOrder.Current_CustomerOrderStatus_RefID = orderedStatusID;
            foundCustomerOrder.IsCustomerOrderFinalized = true;

            ORM_USR_Account account = new ORM_USR_Account();
            account.Load(Connection, Transaction, securityTicket.AccountID);

            ORM_ORD_CUO_CustomerOrder_StatusHistory newStatusInHistory = new ORM_ORD_CUO_CustomerOrder_StatusHistory();
            newStatusInHistory.CustomerOrder_Header_RefID = foundCustomerOrder.ORD_CUO_CustomerOrder_HeaderID;
            newStatusInHistory.StatusHistoryComment = Parameter.Message;
            newStatusInHistory.Tenant_RefID = securityTicket.TenantID;
            newStatusInHistory.CustomerOrder_Status_RefID = orderedStatusID;
            newStatusInHistory.PerformedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID;

            //saving new status in history and customer order header
            newStatusInHistory.Save(Connection, Transaction);
            returnValue.Result = new FR_Guid(foundCustomerOrder.Save(Connection, Transaction), foundCustomerOrder.ORD_CUO_CustomerOrder_HeaderID).Result;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3CO_RO_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3CO_RO_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CO_RO_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CO_RO_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_RejectOrder",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3CO_RO_1101 for attribute P_L3CO_RO_1101
		[DataContract]
		public class P_L3CO_RO_1101 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 
			[DataMember]
			public Boolean IsCustomerOrderFinalized { get; set; } 
			[DataMember]
			public String Message { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_RejectOrder(,P_L3CO_RO_1101 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_RejectOrder.Invoke(connectionString,P_L3CO_RO_1101 Parameter,securityTicket);
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
var parameter = new CL3_CustomerOrder.Atomic.Manipulation.P_L3CO_RO_1101();
parameter.CustomerOrderHeaderID = ...;
parameter.IsCustomerOrderFinalized = ...;
parameter.Message = ...;

*/
