/* 
 * Generated on 12/18/2014 3:25:46 PM
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

namespace CL5_Zugseil_Logistic.Complex.Manipulation
{
	/// <summary>
    /// Delete_Logistic_Provider_and_Assigned_Shipment_Types
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_Logistic_Provider_and_Assigned_Shipment_Types.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_Logistic_Provider_and_Assigned_Shipment_Types
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5ZL_DLPaAST_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();
			//Put your code here

            ORM_LOG_LogisticsProvider logisticProvider = new ORM_LOG_LogisticsProvider();
            logisticProvider.Load(Connection, Transaction, Parameter.LogisticProviderID);

            ORM_CMN_BPT_AvailableShipmentType.Query availableShipmentTypeQuery = new ORM_CMN_BPT_AvailableShipmentType.Query();
            availableShipmentTypeQuery.CMN_BPT_BusinessParticipant_RefID = logisticProvider.Ext_CMN_BPT_BusinessParticipant_RefID;
            availableShipmentTypeQuery.Tenant_RefID = securityTicket.TenantID;
            availableShipmentTypeQuery.IsDeleted = false;

            // delete all shipment types for this logistic provider
            var numberOfDeletedTypes = ORM_CMN_BPT_AvailableShipmentType.Query.SoftDelete(Connection, Transaction, availableShipmentTypeQuery);

            // delete that logistic provider
            logisticProvider.IsDeleted = true;
            logisticProvider.Save(Connection, Transaction);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5ZL_DLPaAST_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5ZL_DLPaAST_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ZL_DLPaAST_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ZL_DLPaAST_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_Logistic_Provider_and_Assigned_Shipment_Types",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5ZL_DLPaAST_1523 for attribute P_L5ZL_DLPaAST_1523
		[DataContract]
		public class P_L5ZL_DLPaAST_1523 
		{
			//Standard type parameters
			[DataMember]
			public Guid LogisticProviderID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Delete_Logistic_Provider_and_Assigned_Shipment_Types(,P_L5ZL_DLPaAST_1523 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Delete_Logistic_Provider_and_Assigned_Shipment_Types.Invoke(connectionString,P_L5ZL_DLPaAST_1523 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Logistic.Complex.Manipulation.P_L5ZL_DLPaAST_1523();
parameter.LogisticProviderID = ...;

*/
