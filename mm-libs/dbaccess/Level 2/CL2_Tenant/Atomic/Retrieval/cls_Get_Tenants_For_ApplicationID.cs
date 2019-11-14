/* 
 * Generated on 10/31/2013 3:18:28 PM
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

namespace CL2_Tenant.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Tenants_For_ApplicationID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Tenants_For_ApplicationID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2TN_GTFA_1353_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2TN_GTFA_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2TN_GTFA_1353_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Tenant.Atomic.Retrieval.SQL.cls_Get_Tenants_For_ApplicationID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ApplicationID", Parameter.ApplicationID);


			List<L2TN_GTFA_1353> results = new List<L2TN_GTFA_1353>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Tenant_RefID" });
				while(reader.Read())
				{
					L2TN_GTFA_1353 resultItem = new L2TN_GTFA_1353();
					//0:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2TN_GTFA_1353_Array Invoke(string ConnectionString,P_L2TN_GTFA_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2TN_GTFA_1353_Array Invoke(DbConnection Connection,P_L2TN_GTFA_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2TN_GTFA_1353_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2TN_GTFA_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2TN_GTFA_1353_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2TN_GTFA_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2TN_GTFA_1353_Array functionReturn = new FR_L2TN_GTFA_1353_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2TN_GTFA_1353_Array : FR_Base
	{
		public L2TN_GTFA_1353[] Result	{ get; set; } 
		public FR_L2TN_GTFA_1353_Array() : base() {}

		public FR_L2TN_GTFA_1353_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2TN_GTFA_1353 for attribute P_L2TN_GTFA_1353
		[DataContract]
		public class P_L2TN_GTFA_1353 
		{
			//Standard type parameters
			[DataMember]
			public Guid ApplicationID { get; set; } 

		}
		#endregion
		#region SClass L2TN_GTFA_1353 for attribute L2TN_GTFA_1353
		[DataContract]
		public class L2TN_GTFA_1353 
		{
			//Standard type parameters
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2TN_GTFA_1353_Array cls_Get_Tenants_For_ApplicationID(P_L2TN_GTFA_1353 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L2TN_GTFA_1353_Array result = cls_Get_Tenants_For_ApplicationID.Invoke(connectionString,P_L2TN_GTFA_1353 Parameter,securityTicket);
	 return result;
}
*/