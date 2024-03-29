/* 
 * Generated on 18/11/2013 03:04:27
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL2_Warehouse.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Warehouse_Group_for_ID_or_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Warehouse_Group_for_ID_or_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2WH_GWHGfIoT_1438_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2WH_GWHGfIoT_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2WH_GWHGfIoT_1438_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Warehouse.Atomic.Retrieval.SQL.cls_Get_Warehouse_Group_for_ID_or_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Warehouse_GroupID", Parameter.Warehouse_GroupID);



			List<L2WH_GWHGfIoT_1438> results = new List<L2WH_GWHGfIoT_1438>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_Warehouse_GroupID","Parent_RefID","WarehouseGroup_Name","WarehouseGroup_Description_DictID","IsDeleted","CMN_BPT_Supplier_RefID" });
				while(reader.Read())
				{
					L2WH_GWHGfIoT_1438 resultItem = new L2WH_GWHGfIoT_1438();
					//0:Parameter LOG_WRH_Warehouse_GroupID of type Guid
					resultItem.LOG_WRH_Warehouse_GroupID = reader.GetGuid(0);
					//1:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(1);
					//2:Parameter WarehouseGroup_Name of type String
					resultItem.WarehouseGroup_Name = reader.GetString(2);
					//3:Parameter WarehouseGroup_Description of type Dict
					resultItem.WarehouseGroup_Description = reader.GetDictionary(3);
					resultItem.WarehouseGroup_Description.SourceTable = "log_wrh_warehouse_groups";
					loader.Append(resultItem.WarehouseGroup_Description);
					//4:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(4);
					//5:Parameter CMN_BPT_Supplier_RefID of type Guid
					resultItem.CMN_BPT_Supplier_RefID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Warehouse_Group_for_ID_or_TenantID",ex);
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
		public static FR_L2WH_GWHGfIoT_1438_Array Invoke(string ConnectionString,P_L2WH_GWHGfIoT_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2WH_GWHGfIoT_1438_Array Invoke(DbConnection Connection,P_L2WH_GWHGfIoT_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2WH_GWHGfIoT_1438_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2WH_GWHGfIoT_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2WH_GWHGfIoT_1438_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2WH_GWHGfIoT_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2WH_GWHGfIoT_1438_Array functionReturn = new FR_L2WH_GWHGfIoT_1438_Array();
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

				throw new Exception("Exception occured in method cls_Get_Warehouse_Group_for_ID_or_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2WH_GWHGfIoT_1438_Array : FR_Base
	{
		public L2WH_GWHGfIoT_1438[] Result	{ get; set; } 
		public FR_L2WH_GWHGfIoT_1438_Array() : base() {}

		public FR_L2WH_GWHGfIoT_1438_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2WH_GWHGfIoT_1438 for attribute P_L2WH_GWHGfIoT_1438
		[DataContract]
		public class P_L2WH_GWHGfIoT_1438 
		{
			//Standard type parameters
			[DataMember]
			public Guid? Warehouse_GroupID { get; set; } 

		}
		#endregion
		#region SClass L2WH_GWHGfIoT_1438 for attribute L2WH_GWHGfIoT_1438
		[DataContract]
		public class L2WH_GWHGfIoT_1438 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_Warehouse_GroupID { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public String WarehouseGroup_Name { get; set; } 
			[DataMember]
			public Dict WarehouseGroup_Description { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid CMN_BPT_Supplier_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2WH_GWHGfIoT_1438_Array cls_Get_Warehouse_Group_for_ID_or_TenantID(,P_L2WH_GWHGfIoT_1438 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2WH_GWHGfIoT_1438_Array invocationResult = cls_Get_Warehouse_Group_for_ID_or_TenantID.Invoke(connectionString,P_L2WH_GWHGfIoT_1438 Parameter,securityTicket);
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
var parameter = new CL2_Warehouse.Atomic.Retrieval.P_L2WH_GWHGfIoT_1438();
parameter.Warehouse_GroupID = ...;

*/
