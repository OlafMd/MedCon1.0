/* 
 * Generated on 09/05/2014 13:24:40
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
using CL1_LOG_WRH;

namespace CL2_Warehouse.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_LOG_WRH_Shelf_PredefinedProductLocation.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_LOG_WRH_Shelf_PredefinedProductLocation
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_Save_PredefinedProductLocations_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new ORM_LOG_WRH_Shelf_PredefinedProductLocation();
			if (Parameter.LOG_WRH_Shelf_PredefinedProductLocationID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.LOG_WRH_Shelf_PredefinedProductLocationID);
			    if (result.Status != FR_Status.Success || item.LOG_WRH_Shelf_PredefinedProductLocationID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.LOG_WRH_Shelf_PredefinedProductLocationID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.LOG_WRH_Shelf_PredefinedProductLocationID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.Shelf_RefID = Parameter.Shelf_RefID;
			item.Product_RefID = Parameter.Product_RefID;
			item.Product_Variant_RefID = Parameter.Product_Variant_RefID;
			item.Product_Release_RefID = Parameter.Product_Release_RefID;
			item.LocationPriority = Parameter.LocationPriority;


			return new FR_Guid(item.Save(Connection, Transaction),item.LOG_WRH_Shelf_PredefinedProductLocationID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_Save_PredefinedProductLocations_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_Save_PredefinedProductLocations_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_Save_PredefinedProductLocations_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_Save_PredefinedProductLocations_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_LOG_WRH_Shelf_PredefinedProductLocation",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_Save_PredefinedProductLocations_1320 for attribute P_Save_PredefinedProductLocations_1320
		[DataContract]
		public class P_Save_PredefinedProductLocations_1320 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_Shelf_PredefinedProductLocationID { get; set; } 
			[DataMember]
			public Guid Shelf_RefID { get; set; } 
			[DataMember]
			public Guid Product_RefID { get; set; } 
			[DataMember]
			public Guid Product_Variant_RefID { get; set; } 
			[DataMember]
			public Guid Product_Release_RefID { get; set; } 
			[DataMember]
			public int LocationPriority { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_LOG_WRH_Shelf_PredefinedProductLocation(,P_Save_PredefinedProductLocations_1320 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_LOG_WRH_Shelf_PredefinedProductLocation.Invoke(connectionString,P_Save_PredefinedProductLocations_1320 Parameter,securityTicket);
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
var parameter = new CL2_Warehouse.Atomic.Manipulation.P_Save_PredefinedProductLocations_1320();
parameter.LOG_WRH_Shelf_PredefinedProductLocationID = ...;
parameter.Shelf_RefID = ...;
parameter.Product_RefID = ...;
parameter.Product_Variant_RefID = ...;
parameter.Product_Release_RefID = ...;
parameter.LocationPriority = ...;
parameter.IsDeleted = ...;

*/
