/* 
 * Generated on 12/18/2014 11:19:06 AM
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
    /// SaveLogisticProvider
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_SaveLogisticProvider.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_SaveLogisticProvider
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3L_SLP_1114 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            // CREATE NEW
            if (Parameter.LogisticProviderID == Guid.Empty)  
            {
                ORM_CMN_BPT_BusinessParticipant bp = new ORM_CMN_BPT_BusinessParticipant();
                bp.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                bp.DisplayName = Parameter.Name;
                bp.IsCompany = true;
                bp.Tenant_RefID = securityTicket.TenantID;
                bp.Save(Connection, Transaction);

                ORM_LOG_LogisticsProvider logisticProvider = new ORM_LOG_LogisticsProvider();
                logisticProvider.LOG_LogisticsProviderID = Guid.NewGuid();
                logisticProvider.Ext_CMN_BPT_BusinessParticipant_RefID = bp.CMN_BPT_BusinessParticipantID;
                logisticProvider.IsProviding_TransportServices = Parameter.IsProvidingTransportServices;
                logisticProvider.IsTrackingAvailable = Parameter.IsTrackingAvailable;
                logisticProvider.Tenant_RefID = securityTicket.TenantID;
                logisticProvider.Save(Connection, Transaction);

                returnValue.Result = logisticProvider.LOG_LogisticsProviderID;
            }
            // UPDATE EXISTING
            else 
            {
                ORM_LOG_LogisticsProvider logisticProvider = new ORM_LOG_LogisticsProvider();
                logisticProvider.Load(Connection, Transaction, Parameter.LogisticProviderID);

                logisticProvider.IsProviding_TransportServices = Parameter.IsProvidingTransportServices;
                logisticProvider.IsTrackingAvailable = Parameter.IsTrackingAvailable;
                logisticProvider.Save(Connection, Transaction);

                ORM_CMN_BPT_BusinessParticipant bp = new ORM_CMN_BPT_BusinessParticipant();
                bp.Load(Connection, Transaction, logisticProvider.Ext_CMN_BPT_BusinessParticipant_RefID);

                bp.DisplayName = Parameter.Name;
                bp.Save(Connection, Transaction);

                returnValue.Result = Parameter.LogisticProviderID;
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3L_SLP_1114 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3L_SLP_1114 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3L_SLP_1114 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3L_SLP_1114 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_SaveLogisticProvider",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3L_SLP_1114 for attribute P_L3L_SLP_1114
		[DataContract]
		public class P_L3L_SLP_1114 
		{
			//Standard type parameters
			[DataMember]
			public Guid LogisticProviderID { get; set; } 
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public bool IsProvidingTransportServices { get; set; } 
			[DataMember]
			public bool IsTrackingAvailable { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_SaveLogisticProvider(,P_L3L_SLP_1114 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_SaveLogisticProvider.Invoke(connectionString,P_L3L_SLP_1114 Parameter,securityTicket);
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
var parameter = new CL3_Logistic.Complex.Manipulation.P_L3L_SLP_1114();
parameter.LogisticProviderID = ...;
parameter.Name = ...;
parameter.IsProvidingTransportServices = ...;
parameter.IsTrackingAvailable = ...;

*/
