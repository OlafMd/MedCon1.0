/* 
 * Generated on 3/13/2014 2:14:20 PM
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

namespace CL5_APOLogistic_Inventory.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_InventoryJobs_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_InventoryJobs_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CL5I_GIJfT_1413_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CL5I_GIJfT_1413_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_Inventory.Atomic.Retrieval.SQL.cls_Get_InventoryJobs_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<CL5I_GIJfT_1413> results = new List<CL5I_GIJfT_1413>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_INJ_InventoryJobID","InventoryJob_DisplayName","InventoryJob_Name_DictID","Warehouse_RefID","Warehouse_Name" });
				while(reader.Read())
				{
					CL5I_GIJfT_1413 resultItem = new CL5I_GIJfT_1413();
					//0:Parameter LOG_WRH_INJ_InventoryJobID of type Guid
					resultItem.LOG_WRH_INJ_InventoryJobID = reader.GetGuid(0);
					//1:Parameter InventoryJob_DisplayName of type String
					resultItem.InventoryJob_DisplayName = reader.GetString(1);
					//2:Parameter InventoryJob_Name of type Dict
					resultItem.InventoryJob_Name = reader.GetDictionary(2);
					resultItem.InventoryJob_Name.SourceTable = "log_wrh_inj_inventoryjobs";
					loader.Append(resultItem.InventoryJob_Name);
					//3:Parameter Warehouse_RefID of type Guid
					resultItem.Warehouse_RefID = reader.GetGuid(3);
					//4:Parameter Warehouse_Name of type String
					resultItem.Warehouse_Name = reader.GetString(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_InventoryJobs_for_TenantID",ex);
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
		public static FR_CL5I_GIJfT_1413_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CL5I_GIJfT_1413_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CL5I_GIJfT_1413_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CL5I_GIJfT_1413_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CL5I_GIJfT_1413_Array functionReturn = new FR_CL5I_GIJfT_1413_Array();
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

				throw new Exception("Exception occured in method cls_Get_InventoryJobs_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CL5I_GIJfT_1413_Array : FR_Base
	{
		public CL5I_GIJfT_1413[] Result	{ get; set; } 
		public FR_CL5I_GIJfT_1413_Array() : base() {}

		public FR_CL5I_GIJfT_1413_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass CL5I_GIJfT_1413 for attribute CL5I_GIJfT_1413
		[DataContract]
		public class CL5I_GIJfT_1413 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_INJ_InventoryJobID { get; set; } 
			[DataMember]
			public String InventoryJob_DisplayName { get; set; } 
			[DataMember]
			public Dict InventoryJob_Name { get; set; } 
			[DataMember]
			public Guid Warehouse_RefID { get; set; } 
			[DataMember]
			public String Warehouse_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CL5I_GIJfT_1413_Array cls_Get_InventoryJobs_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CL5I_GIJfT_1413_Array invocationResult = cls_Get_InventoryJobs_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

