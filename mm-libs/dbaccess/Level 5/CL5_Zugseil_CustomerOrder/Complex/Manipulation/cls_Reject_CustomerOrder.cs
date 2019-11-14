/* 
 * Generated on 3/5/2015 15:52:50
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
using DLCore_DBCommons.APODemand;
using DLCore_DBCommons.Utils;
using CL1_USR;

namespace CL5_Zugseil_CustomerOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Reject_CustomerOrder.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Reject_CustomerOrder
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CO_RCO_2302_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_RCO_2302[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5CO_RCO_2302_Array();
            List<L5CO_RCO_2302> rejectedOrders = new List<L5CO_RCO_2302>();
            foreach (var param in Parameter)
            {
                L5CO_RCO_2302 rejectedProcurementOrder = new L5CO_RCO_2302();
                var orderedStatusID = ORM_ORD_CUO_CustomerOrder_Status.Query.Search(Connection, Transaction,
              new ORM_ORD_CUO_CustomerOrder_Status.Query
              {
                  GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(ECustomerOrderStatus.Rejected),
                  Tenant_RefID = securityTicket.TenantID,
                  IsDeleted = false
              }).SingleOrDefault().ORD_CUO_CustomerOrder_StatusID;

                var customerOrderQuery = new ORM_ORD_CUO_CustomerOrder_Header.Query();
                customerOrderQuery.ORD_CUO_CustomerOrder_HeaderID = param.CustomerOrderHeaderID;
                customerOrderQuery.Tenant_RefID = securityTicket.TenantID;
                var foundCustomerOrder = ORM_ORD_CUO_CustomerOrder_Header.Query.Search(Connection, Transaction, customerOrderQuery).SingleOrDefault();

                foundCustomerOrder.Current_CustomerOrderStatus_RefID = orderedStatusID;
                foundCustomerOrder.IsCustomerOrderFinalized = true;
                foundCustomerOrder.Save(Connection,Transaction);
                ORM_USR_Account account = new ORM_USR_Account();
                account.Load(Connection, Transaction, securityTicket.AccountID);

                ORM_ORD_CUO_CustomerOrder_StatusHistory newStatusInHistory = new ORM_ORD_CUO_CustomerOrder_StatusHistory();
                newStatusInHistory.CustomerOrder_Header_RefID = foundCustomerOrder.ORD_CUO_CustomerOrder_HeaderID;
                newStatusInHistory.StatusHistoryComment = param.Message;
                newStatusInHistory.Tenant_RefID = securityTicket.TenantID;
                newStatusInHistory.CustomerOrder_Status_RefID = orderedStatusID;
                newStatusInHistory.PerformedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID;

                //saving new status in history and customer order header
                newStatusInHistory.Save(Connection, Transaction);
                rejectedProcurementOrder.ProcurementOrderITL = foundCustomerOrder.ProcurementOrderITL;
                rejectedProcurementOrder.ProcuringTenatID = foundCustomerOrder.OrderingCustomer_BusinessParticipant_RefID.ToString();
                rejectedProcurementOrder.Message = param.Message;
                rejectedOrders.Add(rejectedProcurementOrder);
            
            }
            returnValue.Result = rejectedOrders.ToArray();
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CO_RCO_2302_Array Invoke(string ConnectionString,P_L5CO_RCO_2302[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CO_RCO_2302_Array Invoke(DbConnection Connection,P_L5CO_RCO_2302[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CO_RCO_2302_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_RCO_2302[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CO_RCO_2302_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_RCO_2302[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CO_RCO_2302_Array functionReturn = new FR_L5CO_RCO_2302_Array();
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

				throw new Exception("Exception occured in method cls_Reject_CustomerOrder",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CO_RCO_2302_Array : FR_Base
	{
		public L5CO_RCO_2302[] Result	{ get; set; } 
		public FR_L5CO_RCO_2302_Array() : base() {}

		public FR_L5CO_RCO_2302_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CO_RCO_2302 for attribute P_L5CO_RCO_2302[]
		[DataContract]
		public class P_L5CO_RCO_2302 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 
			[DataMember]
			public String Message { get; set; } 

		}
		#endregion
		#region SClass L5CO_RCO_2302 for attribute L5CO_RCO_2302
		[DataContract]
		public class L5CO_RCO_2302 
		{
			//Standard type parameters
			[DataMember]
			public String ProcurementOrderITL { get; set; } 
			[DataMember]
			public String Message { get; set; } 
			[DataMember]
			public String ProcuringTenatID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CO_RCO_2302_Array cls_Reject_CustomerOrder(,P_L5CO_RCO_2302 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CO_RCO_2302_Array invocationResult = cls_Reject_CustomerOrder.Invoke(connectionString,P_L5CO_RCO_2302 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_CustomerOrder.Complex.Manipulation.P_L5CO_RCO_2302();
parameter.CustomerOrderHeaderID = ...;
parameter.Message = ...;

*/
