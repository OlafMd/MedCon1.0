/* 
 * Generated on 10/17/2013 1:51:47 PM
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
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL5_APOAdmin_ShipmentType.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_LOG_SHP_Shipment_Type.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_LOG_SHP_Shipment_Type
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5ST_SST_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Type();
			 if (Parameter.LOG_SHP_Shipment_TypeID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.LOG_SHP_Shipment_TypeID);
			    if (result.Status != FR_Status.Success || item.LOG_SHP_Shipment_TypeID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.LOG_SHP_Shipment_TypeID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.LOG_SHP_Shipment_TypeID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.GlobalPropertyMatchingID = Parameter.GlobalPropertyMatchingID;
			item.ShipmentType_Name = Parameter.ShipmentType_Name;
			item.ShipmentType_Description = Parameter.ShipmentType_Description;
			item.IsCustomerPickup = Parameter.IsCustomerPickup;
			item.IsPartialPickingPermitted = Parameter.IsPartialPickingPermitted;
			item.IsFixedPricePerShipment = Parameter.IsFixedPricePerShipment;
			item.IfFixedPricePerShipment_Price_RefID = Parameter.IfFixedPricePerShipment_Price_RefID;


			return new FR_Guid(item.Save(Connection, Transaction),item.LOG_SHP_Shipment_TypeID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5ST_SST_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5ST_SST_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ST_SST_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ST_SST_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_LOG_SHP_Shipment_Type",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5ST_SST_1347 for attribute P_L5ST_SST_1347
		[DataContract]
		public class P_L5ST_SST_1347 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_TypeID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict ShipmentType_Name { get; set; } 
			[DataMember]
			public Dict ShipmentType_Description { get; set; } 
			[DataMember]
			public Boolean IsCustomerPickup { get; set; } 
			[DataMember]
			public Boolean IsPartialPickingPermitted { get; set; } 
			[DataMember]
			public Boolean IsFixedPricePerShipment { get; set; } 
			[DataMember]
			public Guid IfFixedPricePerShipment_Price_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_LOG_SHP_Shipment_Type(,P_L5ST_SST_1347 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_LOG_SHP_Shipment_Type.Invoke(connectionString,P_L5ST_SST_1347 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_ShipmentType.Atomic.Manipulation.P_L5ST_SST_1347();
parameter.LOG_SHP_Shipment_TypeID = ...;
parameter.GlobalPropertyMatchingID = ...;
parameter.ShipmentType_Name = ...;
parameter.ShipmentType_Description = ...;
parameter.IsCustomerPickup = ...;
parameter.IsPartialPickingPermitted = ...;
parameter.IsFixedPricePerShipment = ...;
parameter.IfFixedPricePerShipment_Price_RefID = ...;
parameter.IsDeleted = ...;

*/
