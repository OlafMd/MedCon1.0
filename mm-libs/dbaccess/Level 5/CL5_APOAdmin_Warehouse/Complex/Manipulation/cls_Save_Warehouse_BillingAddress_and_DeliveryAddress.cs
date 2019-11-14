/* 
 * Generated on 4/17/2014 5:04:28 PM
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
using CL2_Warehouse.Complex.Manipulation;
using CL2_Address.Atomic.Manipulation;

namespace CL5_APOAdmin_Warehouse.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Warehouse_BillingAddress_and_DeliveryAddress.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Warehouse_BillingAddress_and_DeliveryAddress
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5WH_SWHBAaDA_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            //  Create delivery address for warehouse
            Guid deliveryAddressID = Guid.Empty;
            if (Parameter.SaveDeliveryAddressParam.City_Name != null && Parameter.SaveDeliveryAddressParam.City_Name != String.Empty)
            {
                deliveryAddressID = cls_Save_Address.Invoke(Connection, Transaction, Parameter.SaveDeliveryAddressParam, securityTicket).Result;
                Parameter.SaveWarehouseParam.DeliveryAddress_RefID = deliveryAddressID;
            }            
            
            //  Create warehouse
            var savedWarehouseID = cls_Save_Warehouse.Invoke(Connection, Transaction, Parameter.SaveWarehouseParam, securityTicket).Result;
		    returnValue.Result = savedWarehouseID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5WH_SWHBAaDA_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5WH_SWHBAaDA_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WH_SWHBAaDA_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WH_SWHBAaDA_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Warehouse_BillingAddress_and_DeliveryAddress",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5WH_SWHBAaDA_1355 for attribute P_L5WH_SWHBAaDA_1355
		[DataContract]
		public class P_L5WH_SWHBAaDA_1355 
		{
			//Standard type parameters
			[DataMember]
			public P_L2WH_SWH_1339 SaveWarehouseParam { get; set; } 
			[DataMember]
			public P_L2AD_SA_1755 SaveDeliveryAddressParam { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Warehouse_BillingAddress_and_DeliveryAddress(,P_L5WH_SWHBAaDA_1355 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Warehouse_BillingAddress_and_DeliveryAddress.Invoke(connectionString,P_L5WH_SWHBAaDA_1355 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Warehouse.Complex.Manipulation.P_L5WH_SWHBAaDA_1355();
parameter.SaveWarehouseParam = ...;
parameter.SaveDeliveryAddressParam = ...;

*/
