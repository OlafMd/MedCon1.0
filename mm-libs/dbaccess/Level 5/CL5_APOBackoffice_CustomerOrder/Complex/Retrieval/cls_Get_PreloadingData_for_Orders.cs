/* 
 * Generated on 12/16/2013 2:31:52 PM
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

namespace CL5_APOBackoffice_CustomerOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PreloadingData_for_Orders.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PreloadingData_for_Orders
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CO_GPDfO_1246 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5CO_GPDfO_1246();
            returnValue.Result = new L5CO_GPDfO_1246();
			//Put your code here
             
            
            List<Guid> orderHeadersForTenant = new List<Guid>();
            List<L5CO_GCOWAD_1330> listOfOrdersWithDetails = new List<L5CO_GCOWAD_1330>();
            var orderHeadersQuery = new ORM_ORD_CUO_CustomerOrder_Header.Query();
            orderHeadersQuery.Tenant_RefID = securityTicket.TenantID;
            orderHeadersQuery.IsCustomerOrderFinalized = false;
            var foundOrderHeaders = ORM_ORD_CUO_CustomerOrder_Header.Query.Search(Connection, Transaction, orderHeadersQuery);

            foreach (var orderHeader in foundOrderHeaders)
            {
                var orderWithDetails = new L5CO_GCOWAD_1330();
                var orderWithDetailsQuery = new P_L5CO_GCOWAD_1330();
                orderWithDetailsQuery.OrderHeaderID = orderHeader.ORD_CUO_CustomerOrder_HeaderID;
                orderWithDetailsQuery.PositionsDetailsFetched = false;
                orderWithDetails = cls_Get_CustomerOrder_With_AllDetails.Invoke(Connection, Transaction, orderWithDetailsQuery, securityTicket).Result;

                listOfOrdersWithDetails.Add(orderWithDetails);
            }

            returnValue.Result.CustomerOrdersWithDetails = listOfOrdersWithDetails.ToArray();
            
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CO_GPDfO_1246 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CO_GPDfO_1246 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CO_GPDfO_1246 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CO_GPDfO_1246 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CO_GPDfO_1246 functionReturn = new FR_L5CO_GPDfO_1246();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_PreloadingData_for_Orders",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CO_GPDfO_1246 : FR_Base
	{
		public L5CO_GPDfO_1246 Result	{ get; set; }

		public FR_L5CO_GPDfO_1246() : base() {}

		public FR_L5CO_GPDfO_1246(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5CO_GPDfO_1246 for attribute L5CO_GPDfO_1246
		[DataContract]
		public class L5CO_GPDfO_1246 
		{
			//Standard type parameters
			[DataMember]
			public L5CO_GCOWAD_1330[] CustomerOrdersWithDetails { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CO_GPDfO_1246 cls_Get_PreloadingData_for_Orders(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CO_GPDfO_1246 invocationResult = cls_Get_PreloadingData_for_Orders.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

