/* 
 * Generated on 3/10/2015 10:52:21
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
    /// var result = cls_Get_Warehouse_Area_Rack_Shelf_for_WarehouseID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Warehouse_Area_Rack_Shelf_for_WarehouseID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3WH_GWARSfW_1050_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3WH_GWARSfW_1050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3WH_GWARSfW_1050_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Warehouse.Atomic.Retrieval.SQL.cls_Get_Warehouse_Area_Rack_Shelf_for_WarehouseID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"WarehouseID", Parameter.WarehouseID);



			List<L3WH_GWARSfW_1050> results = new List<L3WH_GWARSfW_1050>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_WarehouseID","Warehouse_Name","IsWarehouseHidden","LOG_WRH_AreaID","Area_Name","Rack_NamePrefix","IsAreaHidden","LOG_WRH_RackID","Rack_Name","Shelf_NamePrefix","IsRackHidden","LOG_WRH_ShelfID","Shelf_Name" });
				while(reader.Read())
				{
					L3WH_GWARSfW_1050 resultItem = new L3WH_GWARSfW_1050();
					//0:Parameter LOG_WRH_WarehouseID of type Guid
					resultItem.LOG_WRH_WarehouseID = reader.GetGuid(0);
					//1:Parameter Warehouse_Name of type String
					resultItem.Warehouse_Name = reader.GetString(1);
					//2:Parameter IsWarehouseHidden of type bool
					resultItem.IsWarehouseHidden = reader.GetBoolean(2);
					//3:Parameter LOG_WRH_AreaID of type Guid
					resultItem.LOG_WRH_AreaID = reader.GetGuid(3);
					//4:Parameter Area_Name of type String
					resultItem.Area_Name = reader.GetString(4);
					//5:Parameter Rack_NamePrefix of type String
					resultItem.Rack_NamePrefix = reader.GetString(5);
					//6:Parameter IsAreaHidden of type bool
					resultItem.IsAreaHidden = reader.GetBoolean(6);
					//7:Parameter LOG_WRH_RackID of type Guid
					resultItem.LOG_WRH_RackID = reader.GetGuid(7);
					//8:Parameter Rack_Name of type String
					resultItem.Rack_Name = reader.GetString(8);
					//9:Parameter Shelf_NamePrefix of type String
					resultItem.Shelf_NamePrefix = reader.GetString(9);
					//10:Parameter IsRackHidden of type bool
					resultItem.IsRackHidden = reader.GetBoolean(10);
					//11:Parameter LOG_WRH_ShelfID of type Guid
					resultItem.LOG_WRH_ShelfID = reader.GetGuid(11);
					//12:Parameter Shelf_Name of type String
					resultItem.Shelf_Name = reader.GetString(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Warehouse_Area_Rack_Shelf_for_WarehouseID",ex);
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
		public static FR_L3WH_GWARSfW_1050_Array Invoke(string ConnectionString,P_L3WH_GWARSfW_1050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3WH_GWARSfW_1050_Array Invoke(DbConnection Connection,P_L3WH_GWARSfW_1050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3WH_GWARSfW_1050_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3WH_GWARSfW_1050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3WH_GWARSfW_1050_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3WH_GWARSfW_1050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3WH_GWARSfW_1050_Array functionReturn = new FR_L3WH_GWARSfW_1050_Array();
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

				throw new Exception("Exception occured in method cls_Get_Warehouse_Area_Rack_Shelf_for_WarehouseID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3WH_GWARSfW_1050_Array : FR_Base
	{
		public L3WH_GWARSfW_1050[] Result	{ get; set; } 
		public FR_L3WH_GWARSfW_1050_Array() : base() {}

		public FR_L3WH_GWARSfW_1050_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3WH_GWARSfW_1050 for attribute P_L3WH_GWARSfW_1050
		[DataContract]
		public class P_L3WH_GWARSfW_1050 
		{
			//Standard type parameters
			[DataMember]
			public Guid WarehouseID { get; set; } 

		}
		#endregion
		#region SClass L3WH_GWARSfW_1050 for attribute L3WH_GWARSfW_1050
		[DataContract]
		public class L3WH_GWARSfW_1050 
		{
			//Standard type parameters
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
FR_L3WH_GWARSfW_1050_Array cls_Get_Warehouse_Area_Rack_Shelf_for_WarehouseID(,P_L3WH_GWARSfW_1050 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3WH_GWARSfW_1050_Array invocationResult = cls_Get_Warehouse_Area_Rack_Shelf_for_WarehouseID.Invoke(connectionString,P_L3WH_GWARSfW_1050 Parameter,securityTicket);
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
var parameter = new CL3_Warehouse.Atomic.Retrieval.P_L3WH_GWARSfW_1050();
parameter.WarehouseID = ...;

*/
