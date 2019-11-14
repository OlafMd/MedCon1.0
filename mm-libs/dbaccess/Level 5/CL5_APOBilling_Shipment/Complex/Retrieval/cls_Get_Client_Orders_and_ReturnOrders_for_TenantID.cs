/* 
 * Generated on 6/9/2014 3:25:09 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL5_APOBilling_Shipment.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL5_APOBilling_Shipment.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Client_Orders_and_ReturnOrders_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Client_Orders_and_ReturnOrders_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SH_GCOaROfT_1517 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SH_GCOaROfT_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5SH_GCOaROfT_1517();

            #region Determine Shipment 'Shipped' and 'Created' statuses
            var statusParam1 = new P_L5SH_GSSfGPMaT_1700 { GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EShipmentStatus.Shipped) };
            var frStatus1 = cls_Get_Shipment_Status_for_GlobalPropertyMatchingID_and_TenantID.Invoke(Connection, Transaction, statusParam1, securityTicket);
            Parameter.FilterCriteria.ShipmentStatusID_Shipped = frStatus1.Result.LOG_SHP_Shipment_StatusID;

            var statusParam2 = new P_L5SH_GSSfGPMaT_1700 { GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EShipmentStatus.Created) };
            var frStatus2 = cls_Get_Shipment_Status_for_GlobalPropertyMatchingID_and_TenantID.Invoke(Connection, Transaction, statusParam1, securityTicket);
            Parameter.FilterCriteria.ShipmentStatusID_Created = frStatus1.Result.LOG_SHP_Shipment_StatusID;
            #endregion

            #region Get Client Orders
            var resultClientOrders = cls_Get_Client_Orders_with_Details_for_TenantID.Invoke(Connection, Transaction, Parameter.FilterCriteria, securityTicket).Result;
            #endregion

            #region Get Client Return Orders
            var clientReturnOrderParameter = new P_L5SH_GCORPwDfT_1455() 
            {
                Customer = Parameter.FilterCriteria.Customer,
                OrderNumber = Parameter.FilterCriteria.OrderNumber,
                PeriodFrom = Parameter.FilterCriteria.PeriodFrom,
                PeriodTo = Parameter.FilterCriteria.PeriodTo
            };
            var resultClientReturnOrder = cls_Get_CustomerOrderReturnPositions_with_Details_forTenantID.Invoke(Connection, Transaction, clientReturnOrderParameter, securityTicket).Result;
            #endregion

            #region Set Result
            returnValue.Result = new L5SH_GCOaROfT_1517();
            returnValue.Result.ClientOrders = resultClientOrders;
            returnValue.Result.ClientReturnOrders = resultClientReturnOrder;
            returnValue.Status = FR_Status.Success;
            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SH_GCOaROfT_1517 Invoke(string ConnectionString,P_L5SH_GCOaROfT_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SH_GCOaROfT_1517 Invoke(DbConnection Connection,P_L5SH_GCOaROfT_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SH_GCOaROfT_1517 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SH_GCOaROfT_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SH_GCOaROfT_1517 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SH_GCOaROfT_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SH_GCOaROfT_1517 functionReturn = new FR_L5SH_GCOaROfT_1517();
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

				throw new Exception("Exception occured in method cls_Get_Client_Orders_and_ReturnOrders_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SH_GCOaROfT_1517 : FR_Base
	{
		public L5SH_GCOaROfT_1517 Result	{ get; set; }

		public FR_L5SH_GCOaROfT_1517() : base() {}

		public FR_L5SH_GCOaROfT_1517(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SH_GCOaROfT_1517 for attribute P_L5SH_GCOaROfT_1517
		[DataContract]
		public class P_L5SH_GCOaROfT_1517 
		{
			//Standard type parameters
			[DataMember]
			public CL5_APOBilling_Shipment.Atomic.Retrieval.P_L5SH_GCwDfT_1454 FilterCriteria { get; set; } 

		}
		#endregion
		#region SClass L5SH_GCOaROfT_1517 for attribute L5SH_GCOaROfT_1517
		[DataContract]
		public class L5SH_GCOaROfT_1517 
		{
			//Standard type parameters
			[DataMember]
			public CL5_APOBilling_Shipment.Atomic.Retrieval.L5SH_GCwDfT_1454[] ClientOrders { get; set; } 
			[DataMember]
			public CL5_APOBilling_Shipment.Atomic.Retrieval.L5SH_GCORPwDfT_1455[] ClientReturnOrders { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SH_GCOaROfT_1517 cls_Get_Client_Orders_and_ReturnOrders_for_TenantID(,P_L5SH_GCOaROfT_1517 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SH_GCOaROfT_1517 invocationResult = cls_Get_Client_Orders_and_ReturnOrders_for_TenantID.Invoke(connectionString,P_L5SH_GCOaROfT_1517 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Shipment.Complex.Retrieval.P_L5SH_GCOaROfT_1517();
parameter.FilterCriteria = ...;

*/
