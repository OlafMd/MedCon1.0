/* 
 * Generated on 8/11/2014 15:18:52
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

namespace CL3_QuickTask.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_QuickTaskTypes_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_QuickTaskTypes_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3QT_GQTTfT_1243_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3QT_GQTTfT_1243_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_QuickTask.Atomic.Retrieval.SQL.cls_Get_QuickTaskTypes_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3QT_GQTTfT_1243> results = new List<L3QT_GQTTfT_1243>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_QuickTask_TypeID","QuickTaskType_Name_DictID","QuickTaskType_ExternalID","QuickTaskType_Description_DictID","IsPersistent","Tenant_RefID" });
				while(reader.Read())
				{
					L3QT_GQTTfT_1243 resultItem = new L3QT_GQTTfT_1243();
					//0:Parameter TMS_QuickTask_TypeID of type Guid
					resultItem.TMS_QuickTask_TypeID = reader.GetGuid(0);
					//1:Parameter QuickTaskType_Name of type Dict
					resultItem.QuickTaskType_Name = reader.GetDictionary(1);
					resultItem.QuickTaskType_Name.SourceTable = "tms_quicktask_type";
					loader.Append(resultItem.QuickTaskType_Name);
					//2:Parameter QuickTaskType_ExternalID of type String
					resultItem.QuickTaskType_ExternalID = reader.GetString(2);
					//3:Parameter QuickTaskType_Description of type Dict
					resultItem.QuickTaskType_Description = reader.GetDictionary(3);
					resultItem.QuickTaskType_Description.SourceTable = "tms_quicktask_type";
					loader.Append(resultItem.QuickTaskType_Description);
					//4:Parameter IsPersistent of type bool
					resultItem.IsPersistent = reader.GetBoolean(4);
					//5:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_QuickTaskTypes_for_TenantID",ex);
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
		public static FR_L3QT_GQTTfT_1243_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3QT_GQTTfT_1243_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3QT_GQTTfT_1243_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3QT_GQTTfT_1243_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3QT_GQTTfT_1243_Array functionReturn = new FR_L3QT_GQTTfT_1243_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_QuickTaskTypes_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3QT_GQTTfT_1243_Array : FR_Base
	{
		public L3QT_GQTTfT_1243[] Result	{ get; set; } 
		public FR_L3QT_GQTTfT_1243_Array() : base() {}

		public FR_L3QT_GQTTfT_1243_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3QT_GQTTfT_1243 for attribute L3QT_GQTTfT_1243
		[DataContract]
		public class L3QT_GQTTfT_1243 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_QuickTask_TypeID { get; set; } 
			[DataMember]
			public Dict QuickTaskType_Name { get; set; } 
			[DataMember]
			public String QuickTaskType_ExternalID { get; set; } 
			[DataMember]
			public Dict QuickTaskType_Description { get; set; } 
			[DataMember]
			public bool IsPersistent { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3QT_GQTTfT_1243_Array cls_Get_QuickTaskTypes_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3QT_GQTTfT_1243_Array invocationResult = cls_Get_QuickTaskTypes_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

