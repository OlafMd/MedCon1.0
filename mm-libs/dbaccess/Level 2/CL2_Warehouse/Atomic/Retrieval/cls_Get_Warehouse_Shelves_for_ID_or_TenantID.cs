/* 
 * Generated on 11/12/2013 01:15:24
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
using System.Runtime.Serialization;

namespace CL2_Warehouse.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Warehouse_Shelves_for_ID_or_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Warehouse_Shelves_for_ID_or_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2WH_GWHSLfIoT_1456_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2WH_GWHSLfIoT_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2WH_GWHSLfIoT_1456_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Warehouse.Atomic.Retrieval.SQL.cls_Get_Warehouse_Shelves_for_ID_or_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShelfID", Parameter.ShelfID);



			List<L2WH_GWHSLfIoT_1456> results = new List<L2WH_GWHSLfIoT_1456>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_ShelfID","Rack_RefID","R_Warehouse_RefID","R_Area_RefID","Shelf_Name","CoordinateCode","CoordinateX","CoordinateY","CoordinateZ","ShelfCapacity_Unit_RefID","ShelfCapacity_Maximum","R_ShelfCapacity_Free","R_ShelfCapacity_Used","LimitShelfContent_ToOneProduct","LimitShelfContent_ToOneProductVariant","LimitShelfContent_ToOneProductRelease","IsShelfLocked","IsDeleted" });
				while(reader.Read())
				{
					L2WH_GWHSLfIoT_1456 resultItem = new L2WH_GWHSLfIoT_1456();
					//0:Parameter LOG_WRH_ShelfID of type Guid
					resultItem.LOG_WRH_ShelfID = reader.GetGuid(0);
					//1:Parameter Rack_RefID of type Guid
					resultItem.Rack_RefID = reader.GetGuid(1);
					//2:Parameter R_Warehouse_RefID of type Guid
					resultItem.R_Warehouse_RefID = reader.GetGuid(2);
					//3:Parameter R_Area_RefID of type Guid
					resultItem.R_Area_RefID = reader.GetGuid(3);
					//4:Parameter Shelf_Name of type String
					resultItem.Shelf_Name = reader.GetString(4);
					//5:Parameter CoordinateCode of type String
					resultItem.CoordinateCode = reader.GetString(5);
					//6:Parameter CoordinateX of type String
					resultItem.CoordinateX = reader.GetString(6);
					//7:Parameter CoordinateY of type String
					resultItem.CoordinateY = reader.GetString(7);
					//8:Parameter CoordinateZ of type String
					resultItem.CoordinateZ = reader.GetString(8);
					//9:Parameter ShelfCapacity_Unit_RefID of type Guid
					resultItem.ShelfCapacity_Unit_RefID = reader.GetGuid(9);
					//10:Parameter ShelfCapacity_Maximum of type double
					resultItem.ShelfCapacity_Maximum = reader.GetDouble(10);
					//11:Parameter R_ShelfCapacity_Free of type double
					resultItem.R_ShelfCapacity_Free = reader.GetDouble(11);
					//12:Parameter R_ShelfCapacity_Used of type double
					resultItem.R_ShelfCapacity_Used = reader.GetDouble(12);
					//13:Parameter LimitShelfContent_ToOneProduct of type bool
					resultItem.LimitShelfContent_ToOneProduct = reader.GetBoolean(13);
					//14:Parameter LimitShelfContent_ToOneProductVariant of type bool
					resultItem.LimitShelfContent_ToOneProductVariant = reader.GetBoolean(14);
					//15:Parameter LimitShelfContent_ToOneProductRelease of type bool
					resultItem.LimitShelfContent_ToOneProductRelease = reader.GetBoolean(15);
					//16:Parameter IsShelfLocked of type bool
					resultItem.IsShelfLocked = reader.GetBoolean(16);
					//17:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(17);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Warehouse_Shelves_for_ID_or_TenantID",ex);
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
		public static FR_L2WH_GWHSLfIoT_1456_Array Invoke(string ConnectionString,P_L2WH_GWHSLfIoT_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2WH_GWHSLfIoT_1456_Array Invoke(DbConnection Connection,P_L2WH_GWHSLfIoT_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2WH_GWHSLfIoT_1456_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2WH_GWHSLfIoT_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2WH_GWHSLfIoT_1456_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2WH_GWHSLfIoT_1456 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2WH_GWHSLfIoT_1456_Array functionReturn = new FR_L2WH_GWHSLfIoT_1456_Array();
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

				throw new Exception("Exception occured in method cls_Get_Warehouse_Shelves_for_ID_or_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2WH_GWHSLfIoT_1456_Array : FR_Base
	{
		public L2WH_GWHSLfIoT_1456[] Result	{ get; set; } 
		public FR_L2WH_GWHSLfIoT_1456_Array() : base() {}

		public FR_L2WH_GWHSLfIoT_1456_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2WH_GWHSLfIoT_1456 for attribute P_L2WH_GWHSLfIoT_1456
		[DataContract]
		public class P_L2WH_GWHSLfIoT_1456 
		{
			//Standard type parameters
			[DataMember]
			public Guid? ShelfID { get; set; } 

		}
		#endregion
		#region SClass L2WH_GWHSLfIoT_1456 for attribute L2WH_GWHSLfIoT_1456
		[DataContract]
		public class L2WH_GWHSLfIoT_1456 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_ShelfID { get; set; } 
			[DataMember]
			public Guid Rack_RefID { get; set; } 
			[DataMember]
			public Guid R_Warehouse_RefID { get; set; } 
			[DataMember]
			public Guid R_Area_RefID { get; set; } 
			[DataMember]
			public String Shelf_Name { get; set; } 
			[DataMember]
			public String CoordinateCode { get; set; } 
			[DataMember]
			public String CoordinateX { get; set; } 
			[DataMember]
			public String CoordinateY { get; set; } 
			[DataMember]
			public String CoordinateZ { get; set; } 
			[DataMember]
			public Guid ShelfCapacity_Unit_RefID { get; set; } 
			[DataMember]
			public double ShelfCapacity_Maximum { get; set; } 
			[DataMember]
			public double R_ShelfCapacity_Free { get; set; } 
			[DataMember]
			public double R_ShelfCapacity_Used { get; set; } 
			[DataMember]
			public bool LimitShelfContent_ToOneProduct { get; set; } 
			[DataMember]
			public bool LimitShelfContent_ToOneProductVariant { get; set; } 
			[DataMember]
			public bool LimitShelfContent_ToOneProductRelease { get; set; } 
			[DataMember]
			public bool IsShelfLocked { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2WH_GWHSLfIoT_1456_Array cls_Get_Warehouse_Shelves_for_ID_or_TenantID(,P_L2WH_GWHSLfIoT_1456 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2WH_GWHSLfIoT_1456_Array invocationResult = cls_Get_Warehouse_Shelves_for_ID_or_TenantID.Invoke(connectionString,P_L2WH_GWHSLfIoT_1456 Parameter,securityTicket);
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
var parameter = new CL2_Warehouse.Atomic.Retrieval.P_L2WH_GWHSLfIoT_1456();
parameter.ShelfID = ...;

*/
