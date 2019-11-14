/* 
 * Generated on 12/18/2014 2:17:39 PM
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

namespace CL3_Logistic.Complex.Manipulation
{
	/// <summary>
    /// SaveShipmentTypeforLogisticProvider
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_SaveShipmentTypeforLogisticProvider.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_SaveShipmentTypeforLogisticProvider
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3L_SSTfLP_1404 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            ORM_LOG_LogisticsProvider logisticProvider1 = new ORM_LOG_LogisticsProvider();
            logisticProvider1.Load(Connection, Transaction, Parameter.LogisticProviderID);

            ORM_CMN_BPT_AvailableShipmentType.Query queryShipmentTypes = new ORM_CMN_BPT_AvailableShipmentType.Query();
            queryShipmentTypes.CMN_BPT_BusinessParticipant_RefID = logisticProvider1.Ext_CMN_BPT_BusinessParticipant_RefID;
            queryShipmentTypes.LOG_SHP_Shipment_Type_RefID = Parameter.ShipmentTypeID;
            queryShipmentTypes.Tenant_RefID = securityTicket.TenantID;
            queryShipmentTypes.IsDeleted = false;

            var shipmentTypeExists = ORM_CMN_BPT_AvailableShipmentType.Query.Exists(Connection, Transaction, queryShipmentTypes);

            if (shipmentTypeExists)
            {
                if (Parameter.IsPrimaryShipmentType)
                {
                    ORM_CMN_BPT_AvailableShipmentType.Query queryST = new ORM_CMN_BPT_AvailableShipmentType.Query();
                    queryST.CMN_BPT_BusinessParticipant_RefID = logisticProvider1.Ext_CMN_BPT_BusinessParticipant_RefID;
                    queryST.IsPrimaryShipmentType = true;
                    queryST.Tenant_RefID = securityTicket.TenantID;

                    ORM_CMN_BPT_AvailableShipmentType.Query querySTvalue = new ORM_CMN_BPT_AvailableShipmentType.Query();
                    querySTvalue.IsPrimaryShipmentType = false;

                    ORM_CMN_BPT_AvailableShipmentType.Query.Update(Connection, Transaction, queryST, querySTvalue);
                }

                var availableShipmentType = ORM_CMN_BPT_AvailableShipmentType.Query.Search(Connection, Transaction, queryShipmentTypes);
                var availableShipmentTypeID = availableShipmentType.Select(x => x.CMN_BPT_AvailableShipmentTypeID).FirstOrDefault();

                ORM_CMN_BPT_AvailableShipmentType shipmentType = new ORM_CMN_BPT_AvailableShipmentType();
                shipmentType.Load(Connection, Transaction, availableShipmentTypeID);

                shipmentType.IsPrimaryShipmentType = Parameter.IsPrimaryShipmentType;
                shipmentType.Save(Connection, Transaction);

                returnValue.Result = availableShipmentTypeID;
            }
            else
            {

                if (Parameter.IsPrimaryShipmentType)
                {
                    ORM_CMN_BPT_AvailableShipmentType.Query queryST = new ORM_CMN_BPT_AvailableShipmentType.Query();
                    queryST.CMN_BPT_BusinessParticipant_RefID = logisticProvider1.Ext_CMN_BPT_BusinessParticipant_RefID;
                    queryST.IsPrimaryShipmentType = true;
                    queryST.Tenant_RefID = securityTicket.TenantID;

                    ORM_CMN_BPT_AvailableShipmentType.Query querySTvalue = new ORM_CMN_BPT_AvailableShipmentType.Query();
                    querySTvalue.IsPrimaryShipmentType = false;

                    ORM_CMN_BPT_AvailableShipmentType.Query.Update(Connection, Transaction, queryST, querySTvalue);
                }

                ORM_LOG_LogisticsProvider logisticProvider = new ORM_LOG_LogisticsProvider();
                logisticProvider.Load(Connection,Transaction,Parameter.LogisticProviderID);

                ORM_CMN_BPT_AvailableShipmentType newShipmentType = new ORM_CMN_BPT_AvailableShipmentType();
                newShipmentType.CMN_BPT_AvailableShipmentTypeID = Guid.NewGuid();
                newShipmentType.CMN_BPT_BusinessParticipant_RefID = logisticProvider.Ext_CMN_BPT_BusinessParticipant_RefID;
                newShipmentType.LOG_SHP_Shipment_Type_RefID = Parameter.ShipmentTypeID;
                newShipmentType.IsPrimaryShipmentType = Parameter.IsPrimaryShipmentType;
                newShipmentType.Tenant_RefID = securityTicket.TenantID;
                newShipmentType.Save(Connection, Transaction);

                returnValue.Result = newShipmentType.CMN_BPT_AvailableShipmentTypeID;
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3L_SSTfLP_1404 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3L_SSTfLP_1404 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3L_SSTfLP_1404 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3L_SSTfLP_1404 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_SaveShipmentTypeforLogisticProvider",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3L_SSTfLP_1404 for attribute P_L3L_SSTfLP_1404
		[DataContract]
		public class P_L3L_SSTfLP_1404 
		{
			//Standard type parameters
			[DataMember]
			public Guid LogisticProviderID { get; set; } 
			[DataMember]
			public Guid ShipmentTypeID { get; set; } 
			[DataMember]
			public bool IsPrimaryShipmentType { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_SaveShipmentTypeforLogisticProvider(,P_L3L_SSTfLP_1404 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_SaveShipmentTypeforLogisticProvider.Invoke(connectionString,P_L3L_SSTfLP_1404 Parameter,securityTicket);
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
var parameter = new CL3_Logistic.Complex.Manipulation.P_L3L_SSTfLP_1404();
parameter.LogisticProviderID = ...;
parameter.ShipmentTypeID = ...;
parameter.IsPrimaryShipmentType = ...;

*/
