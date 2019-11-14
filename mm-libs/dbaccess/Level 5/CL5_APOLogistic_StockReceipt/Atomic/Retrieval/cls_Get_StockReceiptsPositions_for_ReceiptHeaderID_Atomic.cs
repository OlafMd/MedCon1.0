/* 
 * Generated on 11/12/2014 2:10:36 PM
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

namespace CL5_APOLogistic_StockReceipt.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StockReceiptsPositions_for_ReceiptHeaderID_Atomic.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StockReceiptsPositions_for_ReceiptHeaderID_Atomic
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SR_GSROfHA_1408_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_GSROfHA_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SR_GSROfHA_1408_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_StockReceipt.Atomic.Retrieval.SQL.cls_Get_StockReceiptsPositions_for_ReceiptHeaderID_Atomic.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ReceiptHeaderID", Parameter.ReceiptHeaderID);



			List<L5SR_GSROfHA_1408_raw> results = new List<L5SR_GSROfHA_1408_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_RCP_Receipt_PositionID","ReceiptPosition_Product_RefID","Target_WRH_Shelf_RefID","Receipt_ExpectedPositionPrice","Receipt_TotalQuantityTakenIntoStock","ORD_PRC_ProcurementOrder_PositionID","Procurement_OrderedQuantity","Procurement_ValuePerUnit","Procurement_ValueTotal","IsQualityControlPerformed","QualityControl_Quantity","PriceOnSupplierBill","TotalQuantityFreeOfCharge","BatchNumber","ExpiryDate","ShelfContent_RefID","LOG_ProductTrackingInstance_RefID","LOG_RCP_Receipt_Position_DiscountAmountID","ORD_PRC_DiscountType_RefID","PositionDiscountValue","GlobalPropertyMatchingID","DisplayName" });
				while(reader.Read())
				{
					L5SR_GSROfHA_1408_raw resultItem = new L5SR_GSROfHA_1408_raw();
					//0:Parameter LOG_RCP_Receipt_PositionID of type Guid
					resultItem.LOG_RCP_Receipt_PositionID = reader.GetGuid(0);
					//1:Parameter ReceiptPosition_Product_RefID of type Guid
					resultItem.ReceiptPosition_Product_RefID = reader.GetGuid(1);
					//2:Parameter Target_WRH_Shelf_RefID of type Guid
					resultItem.Target_WRH_Shelf_RefID = reader.GetGuid(2);
					//3:Parameter Receipt_ExpectedPositionPrice of type Decimal
					resultItem.Receipt_ExpectedPositionPrice = reader.GetDecimal(3);
					//4:Parameter Receipt_TotalQuantityTakenIntoStock of type Double
					resultItem.Receipt_TotalQuantityTakenIntoStock = reader.GetDouble(4);
					//5:Parameter ORD_PRC_ProcurementOrder_PositionID of type Guid
					resultItem.ORD_PRC_ProcurementOrder_PositionID = reader.GetGuid(5);
					//6:Parameter Procurement_OrderedQuantity of type Double
					resultItem.Procurement_OrderedQuantity = reader.GetDouble(6);
					//7:Parameter Procurement_ValuePerUnit of type Decimal
					resultItem.Procurement_ValuePerUnit = reader.GetDecimal(7);
					//8:Parameter Procurement_ValueTotal of type Decimal
					resultItem.Procurement_ValueTotal = reader.GetDecimal(8);
					//9:Parameter IsQualityControlPerformed of type Boolean
					resultItem.IsQualityControlPerformed = reader.GetBoolean(9);
					//10:Parameter QualityControl_Quantity of type Double
					resultItem.QualityControl_Quantity = reader.GetDouble(10);
					//11:Parameter PriceOnSupplierBill of type Decimal
					resultItem.PriceOnSupplierBill = reader.GetDecimal(11);
					//12:Parameter TotalQuantityFreeOfCharge of type Double
					resultItem.TotalQuantityFreeOfCharge = reader.GetDouble(12);
					//13:Parameter BatchNumber of type String
					resultItem.BatchNumber = reader.GetString(13);
					//14:Parameter ExpiryDate of type DateTime
					resultItem.ExpiryDate = reader.GetDate(14);
					//15:Parameter ShelfContent_RefID of type Guid
					resultItem.ShelfContent_RefID = reader.GetGuid(15);
					//16:Parameter LOG_ProductTrackingInstance_RefID of type Guid
					resultItem.LOG_ProductTrackingInstance_RefID = reader.GetGuid(16);
					//17:Parameter LOG_RCP_Receipt_Position_DiscountAmountID of type Guid
					resultItem.LOG_RCP_Receipt_Position_DiscountAmountID = reader.GetGuid(17);
					//18:Parameter ORD_PRC_DiscountType_RefID of type Guid
					resultItem.ORD_PRC_DiscountType_RefID = reader.GetGuid(18);
					//19:Parameter PositionDiscountValue of type Double
					resultItem.PositionDiscountValue = reader.GetDouble(19);
					//20:Parameter GlobalPropertyMatchingID of type string
					resultItem.GlobalPropertyMatchingID = reader.GetString(20);
					//21:Parameter DisplayName of type string
					resultItem.DisplayName = reader.GetString(21);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_StockReceiptsPositions_for_ReceiptHeaderID_Atomic",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5SR_GSROfHA_1408_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SR_GSROfHA_1408_Array Invoke(string ConnectionString,P_L5SR_GSROfHA_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SR_GSROfHA_1408_Array Invoke(DbConnection Connection,P_L5SR_GSROfHA_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SR_GSROfHA_1408_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_GSROfHA_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SR_GSROfHA_1408_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_GSROfHA_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SR_GSROfHA_1408_Array functionReturn = new FR_L5SR_GSROfHA_1408_Array();
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

				throw new Exception("Exception occured in method cls_Get_StockReceiptsPositions_for_ReceiptHeaderID_Atomic",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5SR_GSROfHA_1408_raw 
	{
		public Guid LOG_RCP_Receipt_PositionID; 
		public Guid ReceiptPosition_Product_RefID; 
		public Guid Target_WRH_Shelf_RefID; 
		public Decimal Receipt_ExpectedPositionPrice; 
		public Double Receipt_TotalQuantityTakenIntoStock; 
		public Guid ORD_PRC_ProcurementOrder_PositionID; 
		public Double Procurement_OrderedQuantity; 
		public Decimal Procurement_ValuePerUnit; 
		public Decimal Procurement_ValueTotal; 
		public Boolean IsQualityControlPerformed; 
		public Double QualityControl_Quantity; 
		public Decimal PriceOnSupplierBill; 
		public Double TotalQuantityFreeOfCharge; 
		public String BatchNumber; 
		public DateTime ExpiryDate; 
		public Guid ShelfContent_RefID; 
		public Guid LOG_ProductTrackingInstance_RefID; 
		public Guid LOG_RCP_Receipt_Position_DiscountAmountID; 
		public Guid ORD_PRC_DiscountType_RefID; 
		public Double PositionDiscountValue; 
		public string GlobalPropertyMatchingID; 
		public string DisplayName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5SR_GSROfHA_1408[] Convert(List<L5SR_GSROfHA_1408_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5SR_GSROfHA_1408 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.LOG_RCP_Receipt_PositionID)).ToArray()
	group el_L5SR_GSROfHA_1408 by new 
	{ 
		el_L5SR_GSROfHA_1408.LOG_RCP_Receipt_PositionID,

	}
	into gfunct_L5SR_GSROfHA_1408
	select new L5SR_GSROfHA_1408
	{     
		LOG_RCP_Receipt_PositionID = gfunct_L5SR_GSROfHA_1408.Key.LOG_RCP_Receipt_PositionID ,
		ReceiptPosition_Product_RefID = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().ReceiptPosition_Product_RefID ,
		Target_WRH_Shelf_RefID = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().Target_WRH_Shelf_RefID ,
		Receipt_ExpectedPositionPrice = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().Receipt_ExpectedPositionPrice ,
		Receipt_TotalQuantityTakenIntoStock = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().Receipt_TotalQuantityTakenIntoStock ,
		ORD_PRC_ProcurementOrder_PositionID = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().ORD_PRC_ProcurementOrder_PositionID ,
		Procurement_OrderedQuantity = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().Procurement_OrderedQuantity ,
		Procurement_ValuePerUnit = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().Procurement_ValuePerUnit ,
		Procurement_ValueTotal = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().Procurement_ValueTotal ,
		IsQualityControlPerformed = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().IsQualityControlPerformed ,
		QualityControl_Quantity = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().QualityControl_Quantity ,
		PriceOnSupplierBill = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().PriceOnSupplierBill ,
		TotalQuantityFreeOfCharge = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().TotalQuantityFreeOfCharge ,
		BatchNumber = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().BatchNumber ,
		ExpiryDate = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().ExpiryDate ,
		ShelfContent_RefID = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().ShelfContent_RefID ,
		LOG_ProductTrackingInstance_RefID = gfunct_L5SR_GSROfHA_1408.FirstOrDefault().LOG_ProductTrackingInstance_RefID ,

		DiscountAmounts = 
		(
			from el_DiscountAmounts in gfunct_L5SR_GSROfHA_1408.ToArray()
			select new L5SR_GSROfHA_1408a
			{     
				LOG_RCP_Receipt_Position_DiscountAmountID = el_DiscountAmounts.LOG_RCP_Receipt_Position_DiscountAmountID,
				ORD_PRC_DiscountType_RefID = el_DiscountAmounts.ORD_PRC_DiscountType_RefID,
				PositionDiscountValue = el_DiscountAmounts.PositionDiscountValue,
				GlobalPropertyMatchingID = el_DiscountAmounts.GlobalPropertyMatchingID,
				DisplayName = el_DiscountAmounts.DisplayName,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5SR_GSROfHA_1408_Array : FR_Base
	{
		public L5SR_GSROfHA_1408[] Result	{ get; set; } 
		public FR_L5SR_GSROfHA_1408_Array() : base() {}

		public FR_L5SR_GSROfHA_1408_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SR_GSROfHA_1408 for attribute P_L5SR_GSROfHA_1408
		[DataContract]
		public class P_L5SR_GSROfHA_1408 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SR_GSROfHA_1408 for attribute L5SR_GSROfHA_1408
		[DataContract]
		public class L5SR_GSROfHA_1408 
		{
			[DataMember]
			public L5SR_GSROfHA_1408a[] DiscountAmounts { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_PositionID { get; set; } 
			[DataMember]
			public Guid ReceiptPosition_Product_RefID { get; set; } 
			[DataMember]
			public Guid Target_WRH_Shelf_RefID { get; set; } 
			[DataMember]
			public Decimal Receipt_ExpectedPositionPrice { get; set; } 
			[DataMember]
			public Double Receipt_TotalQuantityTakenIntoStock { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_PositionID { get; set; } 
			[DataMember]
			public Double Procurement_OrderedQuantity { get; set; } 
			[DataMember]
			public Decimal Procurement_ValuePerUnit { get; set; } 
			[DataMember]
			public Decimal Procurement_ValueTotal { get; set; } 
			[DataMember]
			public Boolean IsQualityControlPerformed { get; set; } 
			[DataMember]
			public Double QualityControl_Quantity { get; set; } 
			[DataMember]
			public Decimal PriceOnSupplierBill { get; set; } 
			[DataMember]
			public Double TotalQuantityFreeOfCharge { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpiryDate { get; set; } 
			[DataMember]
			public Guid ShelfContent_RefID { get; set; } 
			[DataMember]
			public Guid LOG_ProductTrackingInstance_RefID { get; set; } 

		}
		#endregion
		#region SClass L5SR_GSROfHA_1408a for attribute DiscountAmounts
		[DataContract]
		public class L5SR_GSROfHA_1408a 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_Position_DiscountAmountID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_DiscountType_RefID { get; set; } 
			[DataMember]
			public Double PositionDiscountValue { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public string DisplayName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SR_GSROfHA_1408_Array cls_Get_StockReceiptsPositions_for_ReceiptHeaderID_Atomic(,P_L5SR_GSROfHA_1408 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SR_GSROfHA_1408_Array invocationResult = cls_Get_StockReceiptsPositions_for_ReceiptHeaderID_Atomic.Invoke(connectionString,P_L5SR_GSROfHA_1408 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Atomic.Retrieval.P_L5SR_GSROfHA_1408();
parameter.ReceiptHeaderID = ...;

*/
