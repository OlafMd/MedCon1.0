/* 
 * Generated on 27.10.2014 13:30:41
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

namespace CL3_Warehouse.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Warehouse_Group_Areas_Racks_Shelves_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Warehouse_Group_Areas_Racks_Shelves_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3WH_GWGARSfT_1538_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3WH_GWGARSfT_1538_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Warehouse.Atomic.Retrieval.SQL.cls_Get_Warehouse_Group_Areas_Racks_Shelves_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3WH_GWGARSfT_1538> results = new List<L3WH_GWGARSfT_1538>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_Warehouse_GroupID","WarehouseGroup_Name","LOG_WRH_WarehouseID","Warehouse_Name","IsWarehouseHidden","LOG_WRH_AreaID","Area_Name","Rack_NamePrefix","IsAreaHidden","LOG_WRH_RackID","Rack_Name","Shelf_NamePrefix","IsRackHidden","LOG_WRH_ShelfID","Shelf_Name" });
				while(reader.Read())
				{
					L3WH_GWGARSfT_1538 resultItem = new L3WH_GWGARSfT_1538();
					//0:Parameter LOG_WRH_Warehouse_GroupID of type Guid
					resultItem.LOG_WRH_Warehouse_GroupID = reader.GetGuid(0);
					//1:Parameter WarehouseGroup_Name of type String
					resultItem.WarehouseGroup_Name = reader.GetString(1);
					//2:Parameter LOG_WRH_WarehouseID of type Guid
					resultItem.LOG_WRH_WarehouseID = reader.GetGuid(2);
					//3:Parameter Warehouse_Name of type String
					resultItem.Warehouse_Name = reader.GetString(3);
					//4:Parameter IsWarehouseHidden of type bool
					resultItem.IsWarehouseHidden = reader.GetBoolean(4);
					//5:Parameter LOG_WRH_AreaID of type Guid
					resultItem.LOG_WRH_AreaID = reader.GetGuid(5);
					//6:Parameter Area_Name of type String
					resultItem.Area_Name = reader.GetString(6);
					//7:Parameter Rack_NamePrefix of type String
					resultItem.Rack_NamePrefix = reader.GetString(7);
					//8:Parameter IsAreaHidden of type bool
					resultItem.IsAreaHidden = reader.GetBoolean(8);
					//9:Parameter LOG_WRH_RackID of type Guid
					resultItem.LOG_WRH_RackID = reader.GetGuid(9);
					//10:Parameter Rack_Name of type String
					resultItem.Rack_Name = reader.GetString(10);
					//11:Parameter Shelf_NamePrefix of type String
					resultItem.Shelf_NamePrefix = reader.GetString(11);
					//12:Parameter IsRackHidden of type bool
					resultItem.IsRackHidden = reader.GetBoolean(12);
					//13:Parameter LOG_WRH_ShelfID of type Guid
					resultItem.LOG_WRH_ShelfID = reader.GetGuid(13);
					//14:Parameter Shelf_Name of type String
					resultItem.Shelf_Name = reader.GetString(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Warehouse_Group_Areas_Racks_Shelves_for_TenantID",ex);
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
		public static FR_L3WH_GWGARSfT_1538_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3WH_GWGARSfT_1538_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3WH_GWGARSfT_1538_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3WH_GWGARSfT_1538_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3WH_GWGARSfT_1538_Array functionReturn = new FR_L3WH_GWGARSfT_1538_Array();
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

				throw new Exception("Exception occured in method cls_Get_Warehouse_Group_Areas_Racks_Shelves_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3WH_GWGARSfT_1538_Array : FR_Base
	{
		public L3WH_GWGARSfT_1538[] Result	{ get; set; } 
		public FR_L3WH_GWGARSfT_1538_Array() : base() {}

		public FR_L3WH_GWGARSfT_1538_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3WH_GWGARSfT_1538 for attribute L3WH_GWGARSfT_1538
		[DataContract]
		public class L3WH_GWGARSfT_1538 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_Warehouse_GroupID { get; set; } 
			[DataMember]
			public String WarehouseGroup_Name { get; set; } 
			[DataMember]
			public Guid LOG_WRH_WarehouseID { get; set; } 
			[DataMember]
			public String Warehouse_Name { get; set; } 
			[DataMember]
			public bool IsWarehouseHidden { get; set; } 
			[DataMember]
			public Guid LOG_WRH_AreaID { get; set; } 
			[DataMember]
			public String Area_Name { get; set; } 
			[DataMember]
			public String Rack_NamePrefix { get; set; } 
			[DataMember]
			public bool IsAreaHidden { get; set; } 
			[DataMember]
			public Guid LOG_WRH_RackID { get; set; } 
			[DataMember]
			public String Rack_Name { get; set; } 
			[DataMember]
			public String Shelf_NamePrefix { get; set; } 
			[DataMember]
			public bool IsRackHidden { get; set; } 
			[DataMember]
			public Guid LOG_WRH_ShelfID { get; set; } 
			[DataMember]
			public String Shelf_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3WH_GWGARSfT_1538_Array cls_Get_Warehouse_Group_Areas_Racks_Shelves_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3WH_GWGARSfT_1538_Array invocationResult = cls_Get_Warehouse_Group_Areas_Racks_Shelves_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

