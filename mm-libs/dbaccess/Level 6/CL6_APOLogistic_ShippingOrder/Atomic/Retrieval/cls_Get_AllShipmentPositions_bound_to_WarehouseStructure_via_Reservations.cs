/* 
 * Generated on 25.09.2014 12:20:19
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

namespace CL6_APOLogistic_ShippingOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllShipmentPositions_bound_to_WarehouseStructure_via_Reservations.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllShipmentPositions_bound_to_WarehouseStructure_via_Reservations
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6SO_GASPbtWSvR_1413_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6SO_GASPbtWSvR_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6SO_GASPbtWSvR_1413_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_APOLogistic_ShippingOrder.Atomic.Retrieval.SQL.cls_Get_AllShipmentPositions_bound_to_WarehouseStructure_via_Reservations.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentHeaderID", Parameter.ShipmentHeaderID);



			List<L6SO_GASPbtWSvR_1413> results = new List<L6SO_GASPbtWSvR_1413>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_PositionID","LOG_SHP_Shipment_Header_RefID","CMN_PRO_Product_RefID","CMN_PRO_ProductVariant_RefID","CMN_PRO_ProductRelease_RefID","TrackingInstance_ToShip_RefID","QuantityToShip","LOG_RSV_ReservationID","ReservedQuantity","IsReservationExpirable","ReservationExpiryDate","IsReservationExecuted","LOG_WRH_Shelf_ContentID","ShelfContent_Quantity_Current","ShelfContent_Quantity_Initial","LOG_WRH_ShelfID","Shelf_CoordinateCode","Shelf_CoordinateX","Shelf_CoordinateY","Shelf_CoordinateZ","Shelf_Name","LOG_WRH_RackID","Rack_CoordinateCode","Rack_Shelves_XLabel","Rack_Shelves_YLabel","Rack_Shelves_ZLabel","Rack_Name","Rack_Shelf_NamePrefix","LOG_WRH_AreaID","Area_CoordinateCode","Area_Name","Area_Rack_NamePrefix","LOG_WRH_WarehouseID","Warehouse_CoordinateCode","Warehouse_Name","LOG_ProductTrackingInstanceID","SerialNumber","BatchNumber","ExpirationDate","ReservedQuantityFromTrackingInstance" });
				while(reader.Read())
				{
					L6SO_GASPbtWSvR_1413 resultItem = new L6SO_GASPbtWSvR_1413();
					//0:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(0);
					//1:Parameter LOG_SHP_Shipment_Header_RefID of type Guid
					resultItem.LOG_SHP_Shipment_Header_RefID = reader.GetGuid(1);
					//2:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(2);
					//3:Parameter CMN_PRO_ProductVariant_RefID of type Guid
					resultItem.CMN_PRO_ProductVariant_RefID = reader.GetGuid(3);
					//4:Parameter CMN_PRO_ProductRelease_RefID of type Guid
					resultItem.CMN_PRO_ProductRelease_RefID = reader.GetGuid(4);
					//5:Parameter TrackingInstance_ToShip_RefID of type Guid
					resultItem.TrackingInstance_ToShip_RefID = reader.GetGuid(5);
					//6:Parameter QuantityToShip of type double
					resultItem.QuantityToShip = reader.GetDouble(6);
					//7:Parameter LOG_RSV_ReservationID of type Guid
					resultItem.LOG_RSV_ReservationID = reader.GetGuid(7);
					//8:Parameter ReservedQuantity of type double
					resultItem.ReservedQuantity = reader.GetDouble(8);
					//9:Parameter IsReservationExpirable of type Boolean
					resultItem.IsReservationExpirable = reader.GetBoolean(9);
					//10:Parameter ReservationExpiryDate of type DateTime
					resultItem.ReservationExpiryDate = reader.GetDate(10);
					//11:Parameter IsReservationExecuted of type Boolean
					resultItem.IsReservationExecuted = reader.GetBoolean(11);
					//12:Parameter LOG_WRH_Shelf_ContentID of type Guid
					resultItem.LOG_WRH_Shelf_ContentID = reader.GetGuid(12);
					//13:Parameter ShelfContent_Quantity_Current of type double
					resultItem.ShelfContent_Quantity_Current = reader.GetDouble(13);
					//14:Parameter ShelfContent_Quantity_Initial of type double
					resultItem.ShelfContent_Quantity_Initial = reader.GetDouble(14);
					//15:Parameter LOG_WRH_ShelfID of type Guid
					resultItem.LOG_WRH_ShelfID = reader.GetGuid(15);
					//16:Parameter Shelf_CoordinateCode of type String
					resultItem.Shelf_CoordinateCode = reader.GetString(16);
					//17:Parameter Shelf_CoordinateX of type String
					resultItem.Shelf_CoordinateX = reader.GetString(17);
					//18:Parameter Shelf_CoordinateY of type String
					resultItem.Shelf_CoordinateY = reader.GetString(18);
					//19:Parameter Shelf_CoordinateZ of type String
					resultItem.Shelf_CoordinateZ = reader.GetString(19);
					//20:Parameter Shelf_Name of type String
					resultItem.Shelf_Name = reader.GetString(20);
					//21:Parameter LOG_WRH_RackID of type Guid
					resultItem.LOG_WRH_RackID = reader.GetGuid(21);
					//22:Parameter Rack_CoordinateCode of type String
					resultItem.Rack_CoordinateCode = reader.GetString(22);
					//23:Parameter Rack_Shelves_XLabel of type String
					resultItem.Rack_Shelves_XLabel = reader.GetString(23);
					//24:Parameter Rack_Shelves_YLabel of type String
					resultItem.Rack_Shelves_YLabel = reader.GetString(24);
					//25:Parameter Rack_Shelves_ZLabel of type String
					resultItem.Rack_Shelves_ZLabel = reader.GetString(25);
					//26:Parameter Rack_Name of type String
					resultItem.Rack_Name = reader.GetString(26);
					//27:Parameter Rack_Shelf_NamePrefix of type String
					resultItem.Rack_Shelf_NamePrefix = reader.GetString(27);
					//28:Parameter LOG_WRH_AreaID of type Guid
					resultItem.LOG_WRH_AreaID = reader.GetGuid(28);
					//29:Parameter Area_CoordinateCode of type String
					resultItem.Area_CoordinateCode = reader.GetString(29);
					//30:Parameter Area_Name of type String
					resultItem.Area_Name = reader.GetString(30);
					//31:Parameter Area_Rack_NamePrefix of type String
					resultItem.Area_Rack_NamePrefix = reader.GetString(31);
					//32:Parameter LOG_WRH_WarehouseID of type Guid
					resultItem.LOG_WRH_WarehouseID = reader.GetGuid(32);
					//33:Parameter Warehouse_CoordinateCode of type String
					resultItem.Warehouse_CoordinateCode = reader.GetString(33);
					//34:Parameter Warehouse_Name of type String
					resultItem.Warehouse_Name = reader.GetString(34);
					//35:Parameter LOG_ProductTrackingInstanceID of type Guid
					resultItem.LOG_ProductTrackingInstanceID = reader.GetGuid(35);
					//36:Parameter SerialNumber of type String
					resultItem.SerialNumber = reader.GetString(36);
					//37:Parameter BatchNumber of type String
					resultItem.BatchNumber = reader.GetString(37);
					//38:Parameter ExpirationDate of type DateTime
					resultItem.ExpirationDate = reader.GetDate(38);
					//39:Parameter ReservedQuantityFromTrackingInstance of type float
					resultItem.ReservedQuantityFromTrackingInstance = (float)reader.GetDouble(39);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllShipmentPositions_bound_to_WarehouseStructure_via_Reservations",ex);
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
		public static FR_L6SO_GASPbtWSvR_1413_Array Invoke(string ConnectionString,P_L6SO_GASPbtWSvR_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6SO_GASPbtWSvR_1413_Array Invoke(DbConnection Connection,P_L6SO_GASPbtWSvR_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6SO_GASPbtWSvR_1413_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SO_GASPbtWSvR_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6SO_GASPbtWSvR_1413_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SO_GASPbtWSvR_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6SO_GASPbtWSvR_1413_Array functionReturn = new FR_L6SO_GASPbtWSvR_1413_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllShipmentPositions_bound_to_WarehouseStructure_via_Reservations",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6SO_GASPbtWSvR_1413_Array : FR_Base
	{
		public L6SO_GASPbtWSvR_1413[] Result	{ get; set; } 
		public FR_L6SO_GASPbtWSvR_1413_Array() : base() {}

		public FR_L6SO_GASPbtWSvR_1413_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6SO_GASPbtWSvR_1413 for attribute P_L6SO_GASPbtWSvR_1413
		[DataContract]
		public class P_L6SO_GASPbtWSvR_1413 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L6SO_GASPbtWSvR_1413 for attribute L6SO_GASPbtWSvR_1413
		[DataContract]
		public class L6SO_GASPbtWSvR_1413 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_Header_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductVariant_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductRelease_RefID { get; set; } 
			[DataMember]
			public Guid TrackingInstance_ToShip_RefID { get; set; } 
			[DataMember]
			public double QuantityToShip { get; set; } 
			[DataMember]
			public Guid LOG_RSV_ReservationID { get; set; } 
			[DataMember]
			public double ReservedQuantity { get; set; } 
			[DataMember]
			public Boolean IsReservationExpirable { get; set; } 
			[DataMember]
			public DateTime ReservationExpiryDate { get; set; } 
			[DataMember]
			public Boolean IsReservationExecuted { get; set; } 
			[DataMember]
			public Guid LOG_WRH_Shelf_ContentID { get; set; } 
			[DataMember]
			public double ShelfContent_Quantity_Current { get; set; } 
			[DataMember]
			public double ShelfContent_Quantity_Initial { get; set; } 
			[DataMember]
			public Guid LOG_WRH_ShelfID { get; set; } 
			[DataMember]
			public String Shelf_CoordinateCode { get; set; } 
			[DataMember]
			public String Shelf_CoordinateX { get; set; } 
			[DataMember]
			public String Shelf_CoordinateY { get; set; } 
			[DataMember]
			public String Shelf_CoordinateZ { get; set; } 
			[DataMember]
			public String Shelf_Name { get; set; } 
			[DataMember]
			public Guid LOG_WRH_RackID { get; set; } 
			[DataMember]
			public String Rack_CoordinateCode { get; set; } 
			[DataMember]
			public String Rack_Shelves_XLabel { get; set; } 
			[DataMember]
			public String Rack_Shelves_YLabel { get; set; } 
			[DataMember]
			public String Rack_Shelves_ZLabel { get; set; } 
			[DataMember]
			public String Rack_Name { get; set; } 
			[DataMember]
			public String Rack_Shelf_NamePrefix { get; set; } 
			[DataMember]
			public Guid LOG_WRH_AreaID { get; set; } 
			[DataMember]
			public String Area_CoordinateCode { get; set; } 
			[DataMember]
			public String Area_Name { get; set; } 
			[DataMember]
			public String Area_Rack_NamePrefix { get; set; } 
			[DataMember]
			public Guid LOG_WRH_WarehouseID { get; set; } 
			[DataMember]
			public String Warehouse_CoordinateCode { get; set; } 
			[DataMember]
			public String Warehouse_Name { get; set; } 
			[DataMember]
			public Guid LOG_ProductTrackingInstanceID { get; set; } 
			[DataMember]
			public String SerialNumber { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpirationDate { get; set; } 
			[DataMember]
			public float ReservedQuantityFromTrackingInstance { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6SO_GASPbtWSvR_1413_Array cls_Get_AllShipmentPositions_bound_to_WarehouseStructure_via_Reservations(,P_L6SO_GASPbtWSvR_1413 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6SO_GASPbtWSvR_1413_Array invocationResult = cls_Get_AllShipmentPositions_bound_to_WarehouseStructure_via_Reservations.Invoke(connectionString,P_L6SO_GASPbtWSvR_1413 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_ShippingOrder.Atomic.Retrieval.P_L6SO_GASPbtWSvR_1413();
parameter.ShipmentHeaderID = ...;

*/
