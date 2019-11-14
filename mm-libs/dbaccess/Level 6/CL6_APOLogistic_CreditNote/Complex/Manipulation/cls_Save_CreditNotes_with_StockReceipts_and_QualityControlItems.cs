/* 
 * Generated on 7/10/2014 9:48:20 AM
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
using CL3_Price.Complex.Retrieval;
using CL5_APOLogistic_StockReceipt.Complex.Manipulation;
using CL5_APOLogistic_ReturnShipment.Atomic.Manipulation;
using CL1_USR;
using CL1_LOG_RCP;
using CL3_Warehouse.Complex.Manipulation;

namespace CL6_APOLogistic_CreditNote.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CreditNotes_with_StockReceipts_and_QualityControlItems.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CreditNotes_with_StockReceipts_and_QualityControlItems
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L6CN_SCNwSRaQCI_0739 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Bool();

            #region Get Preloading Data

            #region Get StandardPrices for Products
            var priceParam = new P_L3PR_GSPfPIL_1645
            {
                ProductIDList = Parameter.Positions.Select(p => p.ProductId).ToArray()
            };
            var prices = cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction, priceParam, securityTicket).Result;
            #endregion
            #endregion

            #region Create Receipt Header
            var resultReceiptHeader = cls_Save_StockReceiptHeader.Invoke(
                Connection,
                Transaction,
                new P_L5SR_SRH_1545()
                {
                    ReceiptHeaderID = Guid.Empty,
                    SupplierID = Parameter.SupplierID
                },
                securityTicket);
            if (resultReceiptHeader.Result == Guid.Empty)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = false;
                return returnValue;
            }
            #endregion

            #region Create Receipt positions for Receipt header
            var receiptPositions = new List<P_L5RS_CNfRS_1119a>();
            foreach (var position in Parameter.Positions)
            {
                #region Get Preloading Data
                #region Get Performed By Account
                var performedByBusinessParticipant = new ORM_USR_Account();
                performedByBusinessParticipant.Load(Connection, Transaction, securityTicket.AccountID);
                if (performedByBusinessParticipant.BusinessParticipant_RefID == Guid.Empty)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = false;
                    return returnValue;
                }
                #endregion
                #endregion

                #region Create new Receipt Position object
                var receiptPosition = new ORM_LOG_RCP_Receipt_Position();
                receiptPosition.LOG_RCP_Receipt_PositionID = Guid.NewGuid();
                receiptPosition.Creation_Timestamp = DateTime.Now;
                receiptPosition.Tenant_RefID = securityTicket.TenantID;
                receiptPosition.ReceiptPositionITL = receiptPosition.LOG_RCP_Receipt_PositionID.ToString();
                receiptPosition.Receipt_Header_RefID = resultReceiptHeader.Result;
                receiptPosition.ReceiptPosition_Product_RefID = position.ProductId;
                receiptPosition.TotalQuantityFreeOfCharge = 0.0;    
                receiptPosition.TotalQuantityTakenIntoStock = position.Quantity;
                receiptPosition.ExpectedPositionPrice = Convert.ToDecimal(position.Quantity) * position.ValuePerUnit;
                receiptPosition.ExpectedPositionPrice = prices.Where(i => i.ProductID == position.ProductId).Select(j => j.AbdaPrice).SingleOrDefault();
                #endregion

                #region Create new QualityControlItem object
                var qualityControlItem = new ORM_LOG_RCP_Receipt_Position_QualityControlItem();
                qualityControlItem.LOG_RCP_Receipt_Position_QualityControlItem = Guid.NewGuid();
                qualityControlItem.Tenant_RefID = securityTicket.TenantID;
                qualityControlItem.Creation_Timestamp = DateTime.Now;
                qualityControlItem.Receipt_Position_RefID = receiptPosition.LOG_RCP_Receipt_PositionID;
                qualityControlItem.Quantity = position.Quantity;
                qualityControlItem.BatchNumber = position.BatchNumber;
                qualityControlItem.ExpiryDate = position.ExpiryDate;
                qualityControlItem.Target_WRH_Shelf_RefID = position.ShelfId;
                qualityControlItem.QualityControl_PerformedByBusinessParticipant_RefID = performedByBusinessParticipant.BusinessParticipant_RefID;
                qualityControlItem.ReceiptPositionCountedItemITL = string.Empty;
                qualityControlItem.QualityControl_PerformedAtDate = DateTime.Now;
                #endregion

                #region Save objects
                var resultReceiptPosition = receiptPosition.Save(Connection, Transaction);
                if (resultReceiptPosition.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = false;
                    return returnValue;
                }
                var resultQualityControlItem = qualityControlItem.Save(Connection, Transaction);
                if (resultQualityControlItem.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = false;
                    return returnValue;
                }
                #endregion

                receiptPositions.Add(new P_L5RS_CNfRS_1119a() 
                    {
                        receiptPositionId = receiptPosition.LOG_RCP_Receipt_PositionID,
                        compesationValue = qualityControlItem.Quantity * Convert.ToDouble(position.ValuePerUnit)
                    });
            }
            #endregion

            #region Place articles on stock
            CL3_Warehouse.Complex.Manipulation.cls_StockReceipt_IntakeConfirmation.Invoke(
                Connection, 
                Transaction, 
                new P_L3WH_SRIC_1421() 
                {
                    ReceiptHeaderID = resultReceiptHeader.Result,
                    WithoutProcurement = true
                }, 
                securityTicket);
            #endregion

            #region Create CreditNote
            var resultCreditNote = cls_Save_CreditNote_for_ReturnShipment.Invoke(
                Connection, 
                Transaction, 
                new P_L5RS_CNfRS_1119() 
                { 
                    headerId = Parameter.CreditNoteHeaderID,
                    headerValue = Convert.ToDecimal(receiptPositions.Sum(rp => rp.compesationValue)),
                    receiptPositions = receiptPositions.ToArray(),
                    returnShipmentPositions = null
                }, 
                securityTicket);
            if (resultCreditNote.Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = false;
                return returnValue;
            }
            #endregion

            returnValue.Result = true;
            returnValue.Status = FR_Status.Success;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L6CN_SCNwSRaQCI_0739 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L6CN_SCNwSRaQCI_0739 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L6CN_SCNwSRaQCI_0739 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6CN_SCNwSRaQCI_0739 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Save_CreditNotes_with_StockReceipts_and_QualityControlItems",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6CN_SCNwSRaQCI_0739 for attribute P_L6CN_SCNwSRaQCI_0739
		[DataContract]
		public class P_L6CN_SCNwSRaQCI_0739 
		{
			[DataMember]
			public P_L6RS_SCNwSRaQCI_0739a[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid SupplierID { get; set; } 
			[DataMember]
			public Guid CreditNoteHeaderID { get; set; } 
			[DataMember]
			public string CreditNoteHeaderNumber { get; set; } 
			[DataMember]
			public DateTime CreditNoteHeaderDate { get; set; } 
			[DataMember]
			public Guid CreditNoteHeaderCurrencyId { get; set; } 
			[DataMember]
			public decimal CreditNoteHeaderValue { get; set; } 

		}
		#endregion
		#region SClass P_L6RS_SCNwSRaQCI_0739a for attribute Positions
		[DataContract]
		public class P_L6RS_SCNwSRaQCI_0739a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductId { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public decimal ValuePerUnit { get; set; } 
			[DataMember]
			public string BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpiryDate { get; set; } 
			[DataMember]
			public Guid ShelfId { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_CreditNotes_with_StockReceipts_and_QualityControlItems(,P_L6CN_SCNwSRaQCI_0739 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_CreditNotes_with_StockReceipts_and_QualityControlItems.Invoke(connectionString,P_L6CN_SCNwSRaQCI_0739 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_CreditNote.Complex.Manipulation.P_L6CN_SCNwSRaQCI_0739();
parameter.Positions = ...;

parameter.SupplierID = ...;
parameter.CreditNoteHeaderID = ...;
parameter.CreditNoteHeaderNumber = ...;
parameter.CreditNoteHeaderDate = ...;
parameter.CreditNoteHeaderCurrencyId = ...;
parameter.CreditNoteHeaderValue = ...;

*/
