/* 
 * Generated on 28.10.2019 13:34:16
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

namespace MMDocConnectDBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Case_FS_Statuses_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Case_FS_Statuses_on_Tenant
	{
		public static readonly int QueryTimeout = 600;

		#region Method Execution
		protected static FR_CAS_GCFSSoT_1858_Array Execute(DbConnection connection, DbTransaction transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			var returnStatus = new FR_CAS_GCFSSoT_1858_Array();

			var command = connection.CreateCommand();
			command.Connection = connection;
			command.Transaction = transaction;
			const string commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Case_FS_Statuses_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			var results = new List<CAS_GCFSSoT_1858>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(connection, transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new[] { "fs_status","fs_key","status_date","gpos_type","is_status_active","bill_position_id","is_status_manually_set","case_id" });
				while (reader.Read())
				{
					var resultItem = new CAS_GCFSSoT_1858();
					//0:parameter fs_status of type int
					resultItem.fs_status = reader.GetInteger(0);
					//1:parameter fs_key of type String
					resultItem.fs_key = reader.GetString(1);
					//2:parameter status_date of type DateTime
					resultItem.status_date = reader.GetDate(2);
					//3:parameter gpos_type of type String
					resultItem.gpos_type = reader.GetString(3);
					//4:parameter is_status_active of type Boolean
					resultItem.is_status_active = reader.GetBoolean(4);
					//5:parameter bill_position_id of type Guid
					resultItem.bill_position_id = reader.GetGuid(5);
					//6:parameter is_status_manually_set of type Boolean
					resultItem.is_status_manually_set = reader.GetBoolean(6);
					//7:parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(7);

					results.Add(resultItem);
				}
			} 
			catch (Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occurred during data retrieval in method cls_Get_Case_FS_Statuses_on_Tenant", ex);
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
		public static FR_CAS_GCFSSoT_1858_Array Invoke(string connectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, connectionString, securityTicket);
		}
		///<summary>
		/// Invokes the method with the given connection, leaving it open if no exceptions occurred
		///<summary>
		public static FR_CAS_GCFSSoT_1858_Array Invoke(DbConnection connection, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(connection, null, null, securityTicket);
		}
		///<summary>
		/// Invokes the method for the given connection and transaction, leaving them open/not committed if no exceptions occurred
		///<summary>
		public static FR_CAS_GCFSSoT_1858_Array Invoke(DbConnection connection, DbTransaction transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(connection, transaction, null, securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCFSSoT_1858_Array Invoke(DbConnection connection, DbTransaction transaction, string connectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			var cleanupConnection = connection == null;
			var cleanupTransaction = transaction == null;

			var functionReturn = new FR_CAS_GCFSSoT_1858_Array();
			try
			{
				if (cleanupConnection) 
				{
					connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
					connection.Open();
				}
				if (cleanupTransaction)
				{
					transaction = connection.BeginTransaction();
				}

				functionReturn = Execute(connection, transaction, securityTicket);

				#region Cleanup Connection/Transaction
				//Commit the transaction 
				if (cleanupTransaction)
				{
					transaction.Commit();
				}
				//Close the connection
				if (cleanupConnection)
				{
					connection.Close();
				}
				#endregion
			}
			catch (Exception ex)
			{
				try
				{
					if (cleanupTransaction)
					{
						transaction?.Rollback();
					}
				}
				catch
				{
					// ignored
				}

				try
				{
					if (cleanupConnection)
					{
						connection?.Close();
					}
				}
				catch
				{
					// ignored
				}

				throw new Exception("Exception occurred in method cls_Get_Case_FS_Statuses_on_Tenant", ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCFSSoT_1858_Array : FR_Base
	{
		public CAS_GCFSSoT_1858[] Result	{ get; set; } 
		public FR_CAS_GCFSSoT_1858_Array() : base() {}

		public FR_CAS_GCFSSoT_1858_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass CAS_GCFSSoT_1858 for attribute CAS_GCFSSoT_1858
		[DataContract]
		public class CAS_GCFSSoT_1858 
		{
			//Standard type parameters
			[DataMember]
			public int fs_status { get; set; } 
			[DataMember]
			public String fs_key { get; set; } 
			[DataMember]
			public DateTime status_date { get; set; } 
			[DataMember]
			public String gpos_type { get; set; } 
			[DataMember]
			public Boolean is_status_active { get; set; } 
			[DataMember]
			public Guid bill_position_id { get; set; } 
			[DataMember]
			public Boolean is_status_manually_set { get; set; } 
			[DataMember]
			public Guid case_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCFSSoT_1858_Array cls_Get_Case_FS_Statuses_on_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCFSSoT_1858_Array invocationResult = cls_Get_Case_FS_Statuses_on_Tenant.Invoke(connectionString, securityTicket);
		return invocationResult.result;
	} 
	catch (Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

