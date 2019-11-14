/* 
 * Generated on 2/15/2015 5:21:14 PM
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
using CL1_CMN_BPT;
using CL1_LOG_SHP;

namespace CL3_Logistic.Atomic.Manipulation
{
	/// <summary>
    /// Delete_ShipmentType_for_ShipmentTypeID
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_ShipmentType_for_ShipmentTypeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_ShipmentType_for_ShipmentTypeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L3L_DSTfSTID_1719 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();
			//Put your code here

            var shipmentTypeID = Parameter.ShipmentTypeID;

            if (shipmentTypeID == Guid.Empty)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.ErrorMessage = "ShipmentTypeID cannot be Guid empty!";
                return returnValue;
            }

            
            ORM_LOG_SHP_Shipment_Type.Query shipmentType = new ORM_LOG_SHP_Shipment_Type.Query();
            shipmentType.LOG_SHP_Shipment_TypeID = shipmentTypeID;
            shipmentType.Tenant_RefID = securityTicket.TenantID;
            shipmentType.IsDeleted = false;

            //delete shipment type
            ORM_LOG_SHP_Shipment_Type.Query.SoftDelete(Connection,Transaction,shipmentType);


            ORM_CMN_BPT_AvailableShipmentType.Query availableShipmentType = new ORM_CMN_BPT_AvailableShipmentType.Query();
            availableShipmentType.LOG_SHP_Shipment_Type_RefID = shipmentTypeID;
            availableShipmentType.Tenant_RefID = securityTicket.TenantID;
            availableShipmentType.IsDeleted = false;

            //delete available shipment type
            ORM_CMN_BPT_AvailableShipmentType.Query.SoftDelete(Connection, Transaction, availableShipmentType);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L3L_DSTfSTID_1719 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L3L_DSTfSTID_1719 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L3L_DSTfSTID_1719 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3L_DSTfSTID_1719 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_Delete_ShipmentType_for_ShipmentTypeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3L_DSTfSTID_1719 for attribute P_L3L_DSTfSTID_1719
		[DataContract]
		public class P_L3L_DSTfSTID_1719 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentTypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Delete_ShipmentType_for_ShipmentTypeID(,P_L3L_DSTfSTID_1719 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Delete_ShipmentType_for_ShipmentTypeID.Invoke(connectionString,P_L3L_DSTfSTID_1719 Parameter,securityTicket);
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
var parameter = new CL3_Logistic.Atomic.Manipulation.P_L3L_DSTfSTID_1719();
parameter.ShipmentTypeID = ...;

*/
