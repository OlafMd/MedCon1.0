/* 
 * Generated on 16-Dec-14 12:59:29 PM
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

namespace CLE_L2_ApplicationSubscription.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_TenantSubscription_for_Application.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_TenantSubscription_for_Application
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2AS_GTSfA_1256 Execute(DbConnection Connection,DbTransaction Transaction,P_L2AS_GTSfA_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2AS_GTSfA_1256();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CLE_L2_ApplicationSubscription.Atomic.Retrieval.SQL.cls_Get_TenantSubscription_for_Application.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ApplicationID", Parameter.ApplicationID);



			List<L2AS_GTSfA_1256> results = new List<L2AS_GTSfA_1256>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TenantSubscriptionID","Tenant_RefID","Application_RefID" });
				while(reader.Read())
				{
					L2AS_GTSfA_1256 resultItem = new L2AS_GTSfA_1256();
					//0:Parameter TenantSubscriptionID of type Guid
					resultItem.TenantSubscriptionID = reader.GetGuid(0);
					//1:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(1);
					//2:Parameter Application_RefID of type Guid
					resultItem.Application_RefID = reader.GetGuid(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_TenantSubscription_for_Application",ex);
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
		public static FR_L2AS_GTSfA_1256 Invoke(string ConnectionString,P_L2AS_GTSfA_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2AS_GTSfA_1256 Invoke(DbConnection Connection,P_L2AS_GTSfA_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2AS_GTSfA_1256 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2AS_GTSfA_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2AS_GTSfA_1256 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2AS_GTSfA_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2AS_GTSfA_1256 functionReturn = new FR_L2AS_GTSfA_1256();
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

				throw new Exception("Exception occured in method cls_Get_TenantSubscription_for_Application",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2AS_GTSfA_1256 : FR_Base
	{
		public L2AS_GTSfA_1256 Result	{ get; set; }

		public FR_L2AS_GTSfA_1256() : base() {}

		public FR_L2AS_GTSfA_1256(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2AS_GTSfA_1256 for attribute P_L2AS_GTSfA_1256
		[DataContract]
		public class P_L2AS_GTSfA_1256 
		{
			//Standard type parameters
			[DataMember]
			public Guid ApplicationID { get; set; } 

		}
		#endregion
		#region SClass L2AS_GTSfA_1256 for attribute L2AS_GTSfA_1256
		[DataContract]
		public class L2AS_GTSfA_1256 
		{
			//Standard type parameters
			[DataMember]
			public Guid TenantSubscriptionID { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Guid Application_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2AS_GTSfA_1256 cls_Get_TenantSubscription_for_Application(,P_L2AS_GTSfA_1256 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2AS_GTSfA_1256 invocationResult = cls_Get_TenantSubscription_for_Application.Invoke(connectionString,P_L2AS_GTSfA_1256 Parameter,securityTicket);
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
var parameter = new CLE_L2_ApplicationSubscription.Atomic.Retrieval.P_L2AS_GTSfA_1256();
parameter.ApplicationID = ...;

*/
