/* 
 * Generated on 12/17/2014 4:32:17 PM
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

namespace CL2_Logistic.Atomic.Retrieval
{
	/// <summary>
    /// Get_Logistic_Provider_for_ProviderID_and_Tenant
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Logistic_Provider_for_ProviderID_and_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Logistic_Provider_for_ProviderID_and_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2L_GLPfPaT_1629 Execute(DbConnection Connection,DbTransaction Transaction,P_L2L_GLPfPaT_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2L_GLPfPaT_1629();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Logistic.Atomic.Retrieval.SQL.cls_Get_Logistic_Provider_for_ProviderID_and_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LogisticProviderID", Parameter.LogisticProviderID);



			List<L2L_GLPfPaT_1629> results = new List<L2L_GLPfPaT_1629>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_LogisticsProviderID","IsTrackingAvailable","IsProviding_TransportServices","CMN_BPT_BusinessParticipantID","DisplayName" });
				while(reader.Read())
				{
					L2L_GLPfPaT_1629 resultItem = new L2L_GLPfPaT_1629();
					//0:Parameter LOG_LogisticsProviderID of type Guid
					resultItem.LOG_LogisticsProviderID = reader.GetGuid(0);
					//1:Parameter IsTrackingAvailable of type bool
					resultItem.IsTrackingAvailable = reader.GetBoolean(1);
					//2:Parameter IsProviding_TransportServices of type bool
					resultItem.IsProviding_TransportServices = reader.GetBoolean(2);
					//3:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(3);
					//4:Parameter DisplayName of type string
					resultItem.DisplayName = reader.GetString(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Logistic_Provider_for_ProviderID_and_Tenant",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2L_GLPfPaT_1629 Invoke(string ConnectionString,P_L2L_GLPfPaT_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2L_GLPfPaT_1629 Invoke(DbConnection Connection,P_L2L_GLPfPaT_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2L_GLPfPaT_1629 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2L_GLPfPaT_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2L_GLPfPaT_1629 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2L_GLPfPaT_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2L_GLPfPaT_1629 functionReturn = new FR_L2L_GLPfPaT_1629();
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

				throw new Exception("Exception occured in method cls_Get_Logistic_Provider_for_ProviderID_and_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2L_GLPfPaT_1629 : FR_Base
	{
		public L2L_GLPfPaT_1629 Result	{ get; set; }

		public FR_L2L_GLPfPaT_1629() : base() {}

		public FR_L2L_GLPfPaT_1629(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2L_GLPfPaT_1629 for attribute P_L2L_GLPfPaT_1629
		[DataContract]
		public class P_L2L_GLPfPaT_1629 
		{
			//Standard type parameters
			[DataMember]
			public Guid LogisticProviderID { get; set; } 

		}
		#endregion
		#region SClass L2L_GLPfPaT_1629 for attribute L2L_GLPfPaT_1629
		[DataContract]
		public class L2L_GLPfPaT_1629 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_LogisticsProviderID { get; set; } 
			[DataMember]
			public bool IsTrackingAvailable { get; set; } 
			[DataMember]
			public bool IsProviding_TransportServices { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public string DisplayName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2L_GLPfPaT_1629 cls_Get_Logistic_Provider_for_ProviderID_and_Tenant(,P_L2L_GLPfPaT_1629 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2L_GLPfPaT_1629 invocationResult = cls_Get_Logistic_Provider_for_ProviderID_and_Tenant.Invoke(connectionString,P_L2L_GLPfPaT_1629 Parameter,securityTicket);
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
var parameter = new CL2_Logistic.Atomic.Retrieval.P_L2L_GLPfPaT_1629();
parameter.LogisticProviderID = ...;

*/
