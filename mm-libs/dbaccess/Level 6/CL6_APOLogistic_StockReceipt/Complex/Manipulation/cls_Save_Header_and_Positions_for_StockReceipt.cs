/* 
 * Generated on 9/17/2014 4:12:14 PM
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
using CL5_APOLogistic_StockReceipt.Complex.Manipulation;

namespace CL6_APOLogistic_StockReceipt.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Header_and_Positions_for_StockReceipt.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Header_and_Positions_for_StockReceipt
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6SR_SHaPfSR1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            //Put your code here

            #region Save Header
            
            P_L5SR_SRH_1545 stockReceiptHeaderParam = new P_L5SR_SRH_1545();
            
            stockReceiptHeaderParam.LatestDeliveryDate = Parameter.LatestDeliveryDate;
            stockReceiptHeaderParam.ProcurementOrderStatus = Parameter.ProcurementOrderStatus;
            stockReceiptHeaderParam.ReceiptHeaderID = Parameter.ReceiptHeaderID;
            stockReceiptHeaderParam.SupplierID = Parameter.SupplierID;

            Guid receiptHeaderID = cls_Save_StockReceiptHeader.Invoke(Connection, Transaction, stockReceiptHeaderParam, securityTicket).Result;
            
            #endregion

            #region Save Position

            var addOrUpdatePositions = Parameter.StockPositions.Where(i => i.IsDeleted == false);

            List<P_L5SR_SRPaEDP_1406a> stockPositions = new List<P_L5SR_SRPaEDP_1406a>();
            foreach (var item in addOrUpdatePositions)
            {
                P_L5SR_SRPaEDP_1406a sp = new P_L5SR_SRPaEDP_1406a();
                sp.BatchNumber = item.BatchNumber;
                sp.ExpiryDate = item.ExpiryDate;
                sp.OrderQuantity = item.OrderQuantity;
                sp.ProductID = item.ProductID;
                sp.ReceiptPositionID = item.ReceiptPositionID;
                sp.UnitPrice = item.UnitPrice;
                stockPositions.Add(sp);
            }

            P_L5SR_SRPaEDP_1406 stockReceiptPositionParam = new P_L5SR_SRPaEDP_1406();
            stockReceiptPositionParam.ReceiptHeaderID = receiptHeaderID;
            stockReceiptPositionParam.StockPositions = stockPositions.ToArray();

            cls_Save_StockReceipt_Procurement_and_ExpectedDelivery_Positions.Invoke(Connection, Transaction, stockReceiptPositionParam, securityTicket);

            #endregion

            #region Delete Positions

            var deletePositions = Parameter.StockPositions.Where(i => i.IsDeleted == true);

            if (deletePositions.Count() != 0) 
            {
                P_L5SR_DDSRP_1715 deleteStockReceiptPositionParam = new P_L5SR_DDSRP_1715();
                deleteStockReceiptPositionParam.ReceiptPositionIDs = deletePositions.Select(i=>i.ReceiptPositionID).ToArray();

                cls_DeepDelete_StockReceiptPositions.Invoke(Connection, Transaction, deleteStockReceiptPositionParam, securityTicket);
            }

            #endregion


            returnValue.Result = receiptHeaderID;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6SR_SHaPfSR1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6SR_SHaPfSR1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SR_SHaPfSR1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SR_SHaPfSR1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_Header_and_Positions_for_StockReceipt",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6SR_SHaPfSR1645 for attribute P_L6SR_SHaPfSR1645
		[DataContract]
		public class P_L6SR_SHaPfSR1645 
		{
			[DataMember]
			public P_L6SR_SHaPfSR1645a[] StockPositions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 
			[DataMember]
			public string ProcurementOrderStatus { get; set; } 
			[DataMember]
			public Guid SupplierID { get; set; } 
			[DataMember]
			public DateTime? LatestDeliveryDate { get; set; } 

		}
		#endregion
		#region SClass P_L6SR_SHaPfSR1645a for attribute StockPositions
		[DataContract]
		public class P_L6SR_SHaPfSR1645a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptPositionID { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public double OrderQuantity { get; set; } 
			[DataMember]
			public decimal UnitPrice { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpiryDate { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Header_and_Positions_for_StockReceipt(,P_L6SR_SHaPfSR1645 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Header_and_Positions_for_StockReceipt.Invoke(connectionString,P_L6SR_SHaPfSR1645 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_StockReceipt.Complex.Manipulation.P_L6SR_SHaPfSR1645();
parameter.StockPositions = ...;

parameter.ReceiptHeaderID = ...;
parameter.ProcurementOrderStatus = ...;
parameter.SupplierID = ...;
parameter.LatestDeliveryDate = ...;

*/
