/* 
 * Generated on 10/6/2014 9:30:45 AM
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
    /// var result = cls_Get_StoragePlaces_for_FilterCriteria.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StoragePlaces_for_FilterCriteria
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3WH_GSPfFC_1504_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3WH_GSPfFC_1504 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3WH_GSPfFC_1504_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Warehouse.Atomic.Retrieval.SQL.cls_Get_StoragePlaces_for_FilterCriteria.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"WarehouseGroupID", Parameter.WarehouseGroupID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"WarehouseID", Parameter.WarehouseID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AreaID", Parameter.AreaID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RackID", Parameter.RackID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"UseShelfIDList", Parameter.UseShelfIDList);

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ShelfIDs"," IN $$ShelfIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ShelfIDs$",Parameter.ShelfIDs);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"UseProductIDList", Parameter.UseProductIDList);

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProductIDs"," IN $$ProductIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProductIDs$",Parameter.ProductIDs);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BottomShelfQuantity", Parameter.BottomShelfQuantity);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TopShelfQuantity", Parameter.TopShelfQuantity);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"UseProductTrackingInstanceIDList", Parameter.UseProductTrackingInstanceIDList);

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProductTrackingInstanceIDs"," IN $$ProductTrackingInstanceIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProductTrackingInstanceIDs$",Parameter.ProductTrackingInstanceIDs);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"StartExpirationDate", Parameter.StartExpirationDate);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"EndExpirationDate", Parameter.EndExpirationDate);



			List<L3WH_GSPfFC_1504> results = new List<L3WH_GSPfFC_1504>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_Warehouse_GroupID","WarehouseGroup_Name","LOG_WRH_WarehouseID","Warehouse_Name","WarehouseCoordinateCode","IsWarehouseHidden","LOG_WRH_AreaID","Area_Name","Rack_NamePrefix","AreaCoordinateCode","IsDefaultIntakeArea","IsAreaHidden","LOG_WRH_RackID","Rack_Name","Shelf_NamePrefix","RackCoordinateCode","IsRackHidden","LOG_WRH_ShelfID","Shelf_Name","ShelfCoordinateCode","Predefined_Product_RefID","LOG_WRH_Shelf_ContentID","Product_RefID","Quantity_Current","ExpirationDate","BatchNumber","CurrentQuantityOnTrackingInstance","LOG_ProductTrackingInstanceID" });
				while(reader.Read())
				{
					L3WH_GSPfFC_1504 resultItem = new L3WH_GSPfFC_1504();
					//0:Parameter LOG_WRH_Warehouse_GroupID of type Guid
					resultItem.LOG_WRH_Warehouse_GroupID = reader.GetGuid(0);
					//1:Parameter WarehouseGroup_Name of type String
					resultItem.WarehouseGroup_Name = reader.GetString(1);
					//2:Parameter LOG_WRH_WarehouseID of type Guid
					resultItem.LOG_WRH_WarehouseID = reader.GetGuid(2);
					//3:Parameter Warehouse_Name of type String
					resultItem.Warehouse_Name = reader.GetString(3);
					//4:Parameter WarehouseCoordinateCode of type String
					resultItem.WarehouseCoordinateCode = reader.GetString(4);
					//5:Parameter IsWarehouseHidden of type bool
					resultItem.IsWarehouseHidden = reader.GetBoolean(5);
					//6:Parameter LOG_WRH_AreaID of type Guid
					resultItem.LOG_WRH_AreaID = reader.GetGuid(6);
					//7:Parameter Area_Name of type String
					resultItem.Area_Name = reader.GetString(7);
					//8:Parameter Rack_NamePrefix of type String
					resultItem.Rack_NamePrefix = reader.GetString(8);
					//9:Parameter AreaCoordinateCode of type String
					resultItem.AreaCoordinateCode = reader.GetString(9);
					//10:Parameter IsDefaultIntakeArea of type bool
					resultItem.IsDefaultIntakeArea = reader.GetBoolean(10);
					//11:Parameter IsAreaHidden of type bool
					resultItem.IsAreaHidden = reader.GetBoolean(11);
					//12:Parameter LOG_WRH_RackID of type Guid
					resultItem.LOG_WRH_RackID = reader.GetGuid(12);
					//13:Parameter Rack_Name of type String
					resultItem.Rack_Name = reader.GetString(13);
					//14:Parameter Shelf_NamePrefix of type String
					resultItem.Shelf_NamePrefix = reader.GetString(14);
					//15:Parameter RackCoordinateCode of type String
					resultItem.RackCoordinateCode = reader.GetString(15);
					//16:Parameter IsRackHidden of type bool
					resultItem.IsRackHidden = reader.GetBoolean(16);
					//17:Parameter LOG_WRH_ShelfID of type Guid
					resultItem.LOG_WRH_ShelfID = reader.GetGuid(17);
					//18:Parameter Shelf_Name of type String
					resultItem.Shelf_Name = reader.GetString(18);
					//19:Parameter ShelfCoordinateCode of type String
					resultItem.ShelfCoordinateCode = reader.GetString(19);
					//20:Parameter Predefined_Product_RefID of type Guid
					resultItem.Predefined_Product_RefID = reader.GetGuid(20);
					//21:Parameter LOG_WRH_Shelf_ContentID of type Guid
					resultItem.LOG_WRH_Shelf_ContentID = reader.GetGuid(21);
					//22:Parameter Product_RefID of type Guid
					resultItem.Product_RefID = reader.GetGuid(22);
					//23:Parameter Quantity_Current of type double
					resultItem.Quantity_Current = reader.GetDouble(23);
					//24:Parameter ExpirationDate of type DateTime
					resultItem.ExpirationDate = reader.GetDate(24);
					//25:Parameter BatchNumber of type String
					resultItem.BatchNumber = reader.GetString(25);
					//26:Parameter CurrentQuantityOnTrackingInstance of type double
					resultItem.CurrentQuantityOnTrackingInstance = reader.GetDouble(26);
					//27:Parameter LOG_ProductTrackingInstanceID of type Guid
					resultItem.LOG_ProductTrackingInstanceID = reader.GetGuid(27);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_StoragePlaces_for_FilterCriteria",ex);
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
		public static FR_L3WH_GSPfFC_1504_Array Invoke(string ConnectionString,P_L3WH_GSPfFC_1504 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3WH_GSPfFC_1504_Array Invoke(DbConnection Connection,P_L3WH_GSPfFC_1504 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3WH_GSPfFC_1504_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3WH_GSPfFC_1504 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3WH_GSPfFC_1504_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3WH_GSPfFC_1504 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3WH_GSPfFC_1504_Array functionReturn = new FR_L3WH_GSPfFC_1504_Array();
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

				throw new Exception("Exception occured in method cls_Get_StoragePlaces_for_FilterCriteria",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3WH_GSPfFC_1504_Array : FR_Base
	{
		public L3WH_GSPfFC_1504[] Result	{ get; set; } 
		public FR_L3WH_GSPfFC_1504_Array() : base() {}

		public FR_L3WH_GSPfFC_1504_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3WH_GSPfFC_1504 for attribute P_L3WH_GSPfFC_1504
		[DataContract]
		public class P_L3WH_GSPfFC_1504 
		{
			//Standard type parameters
			[DataMember]
			public Guid? WarehouseGroupID { get; set; } 
			[DataMember]
			public Guid? WarehouseID { get; set; } 
			[DataMember]
			public Guid? AreaID { get; set; } 
			[DataMember]
			public Guid? RackID { get; set; } 
			[DataMember]
			public bool UseShelfIDList { get; set; } 
			[DataMember]
			public Guid[] ShelfIDs { get; set; } 
			[DataMember]
			public bool UseProductIDList { get; set; } 
			[DataMember]
			public Guid[] ProductIDs { get; set; } 
			[DataMember]
			public int? BottomShelfQuantity { get; set; } 
			[DataMember]
			public int? TopShelfQuantity { get; set; } 
			[DataMember]
			public bool UseProductTrackingInstanceIDList { get; set; } 
			[DataMember]
			public Guid[] ProductTrackingInstanceIDs { get; set; } 
			[DataMember]
			public DateTime? StartExpirationDate { get; set; } 
			[DataMember]
			public DateTime? EndExpirationDate { get; set; } 

		}
		#endregion
		#region SClass L3WH_GSPfFC_1504 for attribute L3WH_GSPfFC_1504
		[DataContract]
		public class L3WH_GSPfFC_1504 
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
			public String WarehouseCoordinateCode { get; set; } 
			[DataMember]
			public bool IsWarehouseHidden { get; set; } 
			[DataMember]
			public Guid LOG_WRH_AreaID { get; set; } 
			[DataMember]
			public String Area_Name { get; set; } 
			[DataMember]
			public String Rack_NamePrefix { get; set; } 
			[DataMember]
			public String AreaCoordinateCode { get; set; } 
			[DataMember]
			public bool IsDefaultIntakeArea { get; set; } 
			[DataMember]
			public bool IsAreaHidden { get; set; } 
			[DataMember]
			public Guid LOG_WRH_RackID { get; set; } 
			[DataMember]
			public String Rack_Name { get; set; } 
			[DataMember]
			public String Shelf_NamePrefix { get; set; } 
			[DataMember]
			public String RackCoordinateCode { get; set; } 
			[DataMember]
			public bool IsRackHidden { get; set; } 
			[DataMember]
			public Guid LOG_WRH_ShelfID { get; set; } 
			[DataMember]
			public String Shelf_Name { get; set; } 
			[DataMember]
			public String ShelfCoordinateCode { get; set; } 
			[DataMember]
			public Guid Predefined_Product_RefID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_Shelf_ContentID { get; set; } 
			[DataMember]
			public Guid Product_RefID { get; set; } 
			[DataMember]
			public double Quantity_Current { get; set; } 
			[DataMember]
			public DateTime ExpirationDate { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public double CurrentQuantityOnTrackingInstance { get; set; } 
			[DataMember]
			public Guid LOG_ProductTrackingInstanceID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3WH_GSPfFC_1504_Array cls_Get_StoragePlaces_for_FilterCriteria(,P_L3WH_GSPfFC_1504 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3WH_GSPfFC_1504_Array invocationResult = cls_Get_StoragePlaces_for_FilterCriteria.Invoke(connectionString,P_L3WH_GSPfFC_1504 Parameter,securityTicket);
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
var parameter = new CL3_Warehouse.Atomic.Retrieval.P_L3WH_GSPfFC_1504();
parameter.WarehouseGroupID = ...;
parameter.WarehouseID = ...;
parameter.AreaID = ...;
parameter.RackID = ...;
parameter.UseShelfIDList = ...;
parameter.ShelfIDs = ...;
parameter.UseProductIDList = ...;
parameter.ProductIDs = ...;
parameter.BottomShelfQuantity = ...;
parameter.TopShelfQuantity = ...;
parameter.UseProductTrackingInstanceIDList = ...;
parameter.ProductTrackingInstanceIDs = ...;
parameter.StartExpirationDate = ...;
parameter.EndExpirationDate = ...;

*/
