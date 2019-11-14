/* 
 * Generated on 11/6/2014 11:01:46
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

namespace CL5_APOBilling_Bill.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_OpenPositions_with_Articles_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OpenPositions_with_Articles_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BI_GOPwAfT_0943 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5BI_GOPwAfT_0943();
            //Put your code here

            #region get data
            var resultOpenShipmentOrders = cls_Get_OpenShipmentPositions_with_Articles_for_Tenant.Invoke(Connection, Transaction, securityTicket);

            var resultOpenReturnOrders = cls_Get_OpenOrderReturnPositions_with_Articles_for_Tenant.Invoke(Connection, Transaction, securityTicket);
            #endregion

            #region set results

            returnValue.Result = new L5BI_GOPwAfT_0943();
            returnValue.Result.OrderReturnPositions = resultOpenReturnOrders.Result;
            returnValue.Result.ShipmentPositions = resultOpenShipmentOrders.Result;
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
		public static FR_L5BI_GOPwAfT_0943 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BI_GOPwAfT_0943 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BI_GOPwAfT_0943 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BI_GOPwAfT_0943 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BI_GOPwAfT_0943 functionReturn = new FR_L5BI_GOPwAfT_0943();
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

				throw new Exception("Exception occured in method cls_Get_OpenPositions_with_Articles_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BI_GOPwAfT_0943 : FR_Base
	{
		public L5BI_GOPwAfT_0943 Result	{ get; set; }

		public FR_L5BI_GOPwAfT_0943() : base() {}

		public FR_L5BI_GOPwAfT_0943(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5BI_GOPwAfT_0943 for attribute L5BI_GOPwAfT_0943
		[DataContract]
		public class L5BI_GOPwAfT_0943 
		{
			//Standard type parameters
			[DataMember]
			public CL5_APOBilling_Bill.Complex.Retrieval.L5BL_GOORPwAfT_1427[] OrderReturnPositions { get; set; } 
			[DataMember]
			public CL5_APOBilling_Bill.Complex.Retrieval.L5BL_GOSPwAfT_1720[] ShipmentPositions { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BI_GOPwAfT_0943 cls_Get_OpenPositions_with_Articles_for_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BI_GOPwAfT_0943 invocationResult = cls_Get_OpenPositions_with_Articles_for_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

