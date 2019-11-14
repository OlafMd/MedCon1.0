/* 
 * Generated on 6/19/2014 1:41:48 PM
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
using CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval;

namespace CL6_Backoffice_OrderHistory.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6OH_GCOoCORHwP_0822 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6OH_GCOoCORHwP_0822();

            #region Get CustomerOrder Headers not related to CustomerInteractions
            var resultOrdersByCustomer =
                cls_Get_CustomerOrderHeaders_with_Positions_notRelatedTo_CustomerInteractions.Invoke(Connection, Transaction, securityTicket).Result;
            #endregion

            #region Get CustomerOrder[Return] Headers related to CustomerInteractions
            var resultOrdersByCustomerRequest =
                cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions_relatedTo_CustomerInteractions.Invoke(Connection, Transaction, securityTicket).Result;
            #endregion

            returnValue.Result = new L6OH_GCOoCORHwP_0822();
            returnValue.Result.OrdersByCustomer = resultOrdersByCustomer.ToArray();
            returnValue.Result.OrdersByCustomerRequest = resultOrdersByCustomerRequest;
            returnValue.Status = FR_Status.Success;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6OH_GCOoCORHwP_0822 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6OH_GCOoCORHwP_0822 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6OH_GCOoCORHwP_0822 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6OH_GCOoCORHwP_0822 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6OH_GCOoCORHwP_0822 functionReturn = new FR_L6OH_GCOoCORHwP_0822();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6OH_GCOoCORHwP_0822 : FR_Base
	{
		public L6OH_GCOoCORHwP_0822 Result	{ get; set; }

		public FR_L6OH_GCOoCORHwP_0822() : base() {}

		public FR_L6OH_GCOoCORHwP_0822(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6OH_GCOoCORHwP_0822 for attribute L6OH_GCOoCORHwP_0822
		[DataContract]
		public class L6OH_GCOoCORHwP_0822 
		{
			//Standard type parameters
			[DataMember]
			public CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval.L5CO_GCOHwPnCI_0820[] OrdersByCustomer { get; set; } 
			[DataMember]
			public CL6_Backoffice_OrderHistory.Complex.Retrieval.L6OH_GCOoCORHwPrCI_1643 OrdersByCustomerRequest { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6OH_GCOoCORHwP_0822 cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6OH_GCOoCORHwP_0822 invocationResult = cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

