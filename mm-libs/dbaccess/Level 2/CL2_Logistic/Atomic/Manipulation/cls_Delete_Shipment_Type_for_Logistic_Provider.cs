/* 
 * Generated on 12/22/2014 5:14:35 PM
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
using CL1_LOG;
using CL1_CMN_BPT;


namespace CL2_Logistic.Atomic.Manipulation
{
	/// <summary>
    /// Delete_Shipment_Type_for_Logistic_Provider
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_Shipment_Type_for_Logistic_Provider.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_Shipment_Type_for_Logistic_Provider
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L2L_DSTfLP_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();
			//Put your code here

            var logisticProvider = new ORM_LOG_LogisticsProvider();
            logisticProvider.Load(Connection, Transaction, Parameter.LogisticProviderID);

            ORM_CMN_BPT_AvailableShipmentType.Query shipmentType = new ORM_CMN_BPT_AvailableShipmentType.Query();
            shipmentType.CMN_BPT_AvailableShipmentTypeID = Parameter.ShipmentTypeID;
            shipmentType.CMN_BPT_BusinessParticipant_RefID = logisticProvider.Ext_CMN_BPT_BusinessParticipant_RefID;
            shipmentType.Tenant_RefID = securityTicket.TenantID;

            var result = ORM_CMN_BPT_AvailableShipmentType.Query.SoftDelete(Connection, Transaction, shipmentType);

            if (result == 1)
                returnValue.Status = FR_Status.Success;
            else
                returnValue.Status = FR_Status.Error_Internal;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L2L_DSTfLP_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L2L_DSTfLP_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L2L_DSTfLP_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2L_DSTfLP_1711 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_Shipment_Type_for_Logistic_Provider",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2L_DSTfLP_1711 for attribute P_L2L_DSTfLP_1711
		[DataContract]
		public class P_L2L_DSTfLP_1711 
		{
			//Standard type parameters
			[DataMember]
			public Guid LogisticProviderID { get; set; } 
			[DataMember]
			public Guid ShipmentTypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Delete_Shipment_Type_for_Logistic_Provider(,P_L2L_DSTfLP_1711 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Delete_Shipment_Type_for_Logistic_Provider.Invoke(connectionString,P_L2L_DSTfLP_1711 Parameter,securityTicket);
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
var parameter = new CL2_Logistic.Atomic.Manipulation.P_L2L_DSTfLP_1711();
parameter.LogisticProviderID = ...;
parameter.ShipmentTypeID = ...;

*/
