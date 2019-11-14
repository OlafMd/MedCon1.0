/* 
 * Generated on 8/4/2014 11:32:45 AM
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
using CL5_APOLogistic_ReturnShipment.Complex.Manipulation;
using CL1_LOG_SHP;
using CL5_APOLogistic_StockReceipt.Atomic.Retrieval;
using CL1_USR;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL5_APOLogistic_ReturnShipment.Atomic.Manipulation;

namespace CL6_APOLogistic_CreditNote.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CreditNotes_and_UpdateReturnShipments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CreditNotes_and_UpdateReturnShipments
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6CN_SCNaURS_0910 Execute(DbConnection Connection,DbTransaction Transaction,P_L6CN_SCNaURS_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6CN_SCNaURS_0910();
            returnValue.Result = new L6CN_SCNaURS_0910();
            var newShipmentHeaderGuids = new List<Guid>();
            var shipmentPositionsToBeCredited = new List<Guid>();
            var newShipmentPositions = new List<P_L5RS_CSaRSPfH_0449a>();

            foreach (var header in Parameter.ShipmentHeaders)
            {
                var shipmentHeader = new ORM_LOG_SHP_Shipment_Header();
                var shipmentHeaderPositions = new List<ORM_LOG_SHP_Shipment_Position>();

                #region Load Shipment Header and Positions
                var result = shipmentHeader.Load(Connection, Transaction, header.ShipmentHeaderID);
                if (result.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    return returnValue;
                }

                shipmentHeaderPositions = ORM_LOG_SHP_Shipment_Position.Query.Search(
                    Connection,
                    Transaction,
                    new ORM_LOG_SHP_Shipment_Position.Query()
                    {
                        LOG_SHP_Shipment_Header_RefID = header.ShipmentHeaderID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });
                #endregion

                L5RS_CSaRSH_0244 newHeader = null;
                decimal updatedHeaderTotalValue = 0;

                foreach (var position in shipmentHeaderPositions)
                {
                    var positionToBeCredited = header.ShipmentPositions.FirstOrDefault(hsp => hsp.ShipmentPositionID == position.LOG_SHP_Shipment_PositionID);

                    // Split Shipment in case that not all positions of one header are selected for crediting 
                    // or in case that selected positions quantities are edited.
                    #region Create New Header and Position Object if position is not selected or dirty
                    if (positionToBeCredited == null || positionToBeCredited.Quantity != positionToBeCredited.OriginalQuantity)
                    {
                        if (Parameter.ReturnToStock == false)
                        {
                            #region Create New Header
                            if (newHeader == null)
                            {
                                var newHeaderParameter = new P_L5RS_CSaRSH_0244() { SupplierID = Parameter.SupplierId };
                                var createResult = cls_Create_Shipment_and_ReturnShipment_Header.Invoke(Connection, Transaction, newHeaderParameter, securityTicket);
                                if (createResult.Status != FR_Status.Success)
                                {
                                    returnValue.Status = FR_Status.Error_Internal;
                                    return returnValue;
                                }
                                newHeader = createResult.Result;
                                newShipmentHeaderGuids.Add(newHeader.ShipmentHeaderID);
                            }
                            #endregion

                            #region Set New Position Object
                            P_L5RS_CSaRSPfH_0449a newPosition;
                            if (positionToBeCredited == null)
                            {
                                var productTrackingInstance = cls_Get_ProductTrackingInstance_for_StockReceiptPosition.Invoke(
                                    Connection,
                                    Transaction,
                                    new P_L5SR_GPTIfSRP_1322() { ReceiptPositionsID = header.ShipmentPositions[0].ReceiptPositionID },
                                    securityTicket).Result;
                                newPosition = new P_L5RS_CSaRSPfH_0449a()
                                {
                                    Quantity = Convert.ToInt32(position.QuantityToShip),
                                    PricePerUnit = position.ShipmentPosition_PricePerUnitValueWithoutTax,
                                    ProductId = position.CMN_PRO_Product_RefID,
                                    ReceiptPositionId = header.ShipmentPositions[0].ReceiptPositionID,
                                    ReturnPolicyId = header.ShipmentPositions[0].ReturnPolicyID,
                                    ShipmentHeaderID = newHeader.ShipmentHeaderID,
                                    ReturnShipmentHeaderID = newHeader.ReturnShipmentHeaderID,
                                    ProductTrackingInstance = productTrackingInstance.LOG_ProductTrackingInstanceID,
                                    ShelfContentID = productTrackingInstance.LOG_WRH_Shelf_ContentID
                                };
                            }
                            else
                            {
                                var productTrackingInstance = cls_Get_ProductTrackingInstance_for_StockReceiptPosition.Invoke(
                                    Connection,
                                    Transaction,
                                    new P_L5SR_GPTIfSRP_1322() { ReceiptPositionsID = positionToBeCredited.ReceiptPositionID },
                                    securityTicket).Result;
                                newPosition = new P_L5RS_CSaRSPfH_0449a()
                                {
                                    Quantity = positionToBeCredited.OriginalQuantity - positionToBeCredited.Quantity,
                                    PricePerUnit = positionToBeCredited.OriginalTotalValue / positionToBeCredited.OriginalQuantity,
                                    ProductId = positionToBeCredited.ProductId,
                                    ReceiptPositionId = positionToBeCredited.ReceiptPositionID,
                                    ReturnPolicyId = positionToBeCredited.ReturnPolicyID,
                                    ShipmentHeaderID = newHeader.ShipmentHeaderID,
                                    ReturnShipmentHeaderID = newHeader.ReturnShipmentHeaderID,
                                    ProductTrackingInstance = productTrackingInstance.LOG_ProductTrackingInstanceID,
                                    ShelfContentID = productTrackingInstance.LOG_WRH_Shelf_ContentID
                                };
                            }
                            newShipmentPositions.Add(newPosition);
                            #endregion
                        }
                        else
                        {
                            #region Return to Stock
                            //The difference in the credited quantity compared to the returned position is taken back to stock.

                            if (positionToBeCredited == null)
                            {
                                var productTrackingInstance = cls_Get_ProductTrackingInstance_for_StockReceiptPosition.Invoke(
                                    Connection,
                                    Transaction,
                                    new P_L5SR_GPTIfSRP_1322() { ReceiptPositionsID = header.ShipmentPositions[0].ReceiptPositionID },
                                    securityTicket).Result;

                                CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content shelfContent = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content();
                                shelfContent.Load(Connection, Transaction, productTrackingInstance.LOG_WRH_Shelf_ContentID);

                                shelfContent.Quantity_Current = Convert.ToInt32(position.QuantityToShip);
                                shelfContent.Save(Connection, Transaction);

                                CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment shelfContentAdjustment = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment();
                                shelfContentAdjustment.ShelfContent_RefID = shelfContent.Shelf_RefID;
                                shelfContentAdjustment.QuantityChangedAmount = shelfContent.Quantity_Current;
                                shelfContentAdjustment.QuantityChangedDate = DateTime.Now;
                                shelfContentAdjustment.Creation_Timestamp = DateTime.Now;
                                shelfContentAdjustment.Tenant_RefID = securityTicket.TenantID;
                                shelfContentAdjustment.Save(Connection, Transaction);

                            }
                            else
                            { 
                                var productTrackingInstance = cls_Get_ProductTrackingInstance_for_StockReceiptPosition.Invoke(
                                    Connection,
                                    Transaction,
                                    new P_L5SR_GPTIfSRP_1322() { ReceiptPositionsID = positionToBeCredited.ReceiptPositionID },
                                    securityTicket).Result;

                                CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content shelfContent = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content();
                                shelfContent.Load(Connection, Transaction, productTrackingInstance.LOG_WRH_Shelf_ContentID);

                                shelfContent.Quantity_Current = positionToBeCredited.OriginalQuantity - positionToBeCredited.Quantity;
                                shelfContent.Save(Connection, Transaction);

                                CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment shelfContentAdjustment = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment();
                                shelfContentAdjustment.ShelfContent_RefID = shelfContent.Shelf_RefID;
                                shelfContentAdjustment.QuantityChangedAmount = shelfContent.Quantity_Current;
                                shelfContentAdjustment.QuantityChangedDate = DateTime.Now;
                                shelfContentAdjustment.Creation_Timestamp = DateTime.Now;
                                shelfContentAdjustment.Tenant_RefID = securityTicket.TenantID;
                                shelfContentAdjustment.Save(Connection, Transaction);
                            }

                            #endregion
                        }
                    }
                    #endregion

                    if (positionToBeCredited == null)
                    {
                        #region Cancel Position

                        #region Get Account
                        var account = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            USR_AccountID = securityTicket.AccountID
                        }).FirstOrDefault();
                        #endregion

                        position.IsCancelled = true;
                        position.CancelledOnDate = DateTime.Now;
                        position.CancelledBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID;
                        var resultUpdate = position.Save(Connection, Transaction);
                        if (resultUpdate.Status != FR_Status.Success)
                        {
                            returnValue.Status = FR_Status.Error_Internal;
                            return returnValue;
                        }
                        #endregion
                    }
                    else
                    {
                        shipmentPositionsToBeCredited.Add(positionToBeCredited.ReturnShipmentPositionID);
                        updatedHeaderTotalValue += positionToBeCredited.TotalValue;

                        #region Update Position if data is dirty
                        if (positionToBeCredited.Quantity != positionToBeCredited.OriginalQuantity
                            || positionToBeCredited.TotalValue != positionToBeCredited.OriginalTotalValue)
                        {
                            position.QuantityToShip = positionToBeCredited.Quantity;
                            position.ShipmentPosition_ValueWithoutTax = positionToBeCredited.TotalValue;
                            var resultUpdate = position.Save(Connection, Transaction);
                            if (resultUpdate.Status != FR_Status.Success)
                            {
                                returnValue.Status = FR_Status.Error_Internal;
                                return returnValue;
                            }
                        }
                        #endregion
                    }
                }

                #region Update shipmentHeader

                #region Create Credited Status History
                // fetch 'credited' status id
                var returnedStatusId = ORM_LOG_SHP_Shipment_Status.Query.Search(
                    Connection,
                    Transaction,
                    new ORM_LOG_SHP_Shipment_Status.Query()
                    {
                        GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EShipmentStatus.Credited),
                        Tenant_RefID = securityTicket.TenantID
                    }).FirstOrDefault().LOG_SHP_Shipment_StatusID;
                // fetch Status History 'credited by' User Account
                var performedByAccount = ORM_USR_Account.Query.Search(
                    Connection,
                    Transaction,
                    new ORM_USR_Account.Query() { USR_AccountID = securityTicket.AccountID })
                    .FirstOrDefault();
                // create status Shipment Status history entry
                var statusHistoryCredited = new ORM_LOG_SHP_Shipment_StatusHistory();
                statusHistoryCredited.Creation_Timestamp = DateTime.Now;
                statusHistoryCredited.IsDeleted = false;
                statusHistoryCredited.LOG_SHP_Shipment_Header_RefID = shipmentHeader.LOG_SHP_Shipment_HeaderID;
                statusHistoryCredited.LOG_SHP_Shipment_Status_RefID = returnedStatusId;
                statusHistoryCredited.LOG_SHP_Shipment_StatusHistoryID = Guid.NewGuid();
                statusHistoryCredited.PerformedBy_BusinessParticipant_RefID =
                    performedByAccount == null
                    ? Guid.Empty
                    : performedByAccount.BusinessParticipant_RefID;
                statusHistoryCredited.Tenant_RefID = securityTicket.TenantID;
                var resultSave = statusHistoryCredited.Save(Connection, Transaction);
                if (resultSave.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    return returnValue;
                }
                #endregion

                shipmentHeader.ShipmentType_RefID = statusHistoryCredited.LOG_SHP_Shipment_StatusHistoryID;
                shipmentHeader.ShipmentHeader_ValueWithoutTax = updatedHeaderTotalValue;
                resultSave = shipmentHeader.Save(Connection, Transaction);
                if (resultSave.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    return returnValue;
                }
                #endregion
            }

            #region Create New Positions
            foreach (var shipmentHeaderId in newShipmentHeaderGuids)
            {
                var positions = new P_L5RS_CSaRSPfH_0449();
                positions.Positions = newShipmentPositions.FindAll(nsp => nsp.ShipmentHeaderID == shipmentHeaderId).ToArray();
                var returnShipment = new P_L5RS_SRSHaP_0807a()
                {
                    CreateNewHeader = false,
                    ShipmentHeader = null,
                    ShipmentPositions = positions
                };
                var savePositionsInputParameter = new P_L5RS_SRSHaP_0807()
                {
                    ReturnShipments = new P_L5RS_SRSHaP_0807a[] { returnShipment } 
                };
                var resultCreate = cls_Save_ReturnShipment_Header_and_Position.Invoke(Connection, Transaction, savePositionsInputParameter, securityTicket);
                if (resultCreate.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    return returnValue;
                }
            }
            #endregion

            #region Save CreditNote Header and Positions
            var inputParameter = new P_L5RS_CNfRS_1119()
            {
                headerId = Guid.Empty,
                headerNumber = Parameter.CreditNoteHeaderNumber,
                headerValue = Parameter.CreditNoteHeaderValue,
                currencyRef = Parameter.CreditNoteHeaderCurrencyId,
                creditNoteDate = Parameter.CreditNoteHeaderDate,
                returnShipmentPositions = shipmentPositionsToBeCredited.ToArray(),
                receiptPositions = null
            };
            var resultCreditNote = cls_Save_CreditNote_for_ReturnShipment.Invoke(Connection, Transaction, inputParameter, securityTicket);
            if (resultCreditNote.Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                return returnValue;
            }
            #endregion

            returnValue.Status = FR_Status.Success;
            returnValue.Result.CreditNoteHeaderId = resultCreditNote.Result;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6CN_SCNaURS_0910 Invoke(string ConnectionString,P_L6CN_SCNaURS_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6CN_SCNaURS_0910 Invoke(DbConnection Connection,P_L6CN_SCNaURS_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6CN_SCNaURS_0910 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6CN_SCNaURS_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6CN_SCNaURS_0910 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6CN_SCNaURS_0910 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6CN_SCNaURS_0910 functionReturn = new FR_L6CN_SCNaURS_0910();
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

				throw new Exception("Exception occured in method cls_Save_CreditNotes_and_UpdateReturnShipments",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6CN_SCNaURS_0910 : FR_Base
	{
		public L6CN_SCNaURS_0910 Result	{ get; set; }

		public FR_L6CN_SCNaURS_0910() : base() {}

		public FR_L6CN_SCNaURS_0910(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6CN_SCNaURS_0910 for attribute P_L6CN_SCNaURS_0910
		[DataContract]
		public class P_L6CN_SCNaURS_0910 
		{
			[DataMember]
			public P_L5RS_SCNaURS_1523a[] ShipmentHeaders { get; set; }

			//Standard type parameters
			[DataMember]
			public string CreditNoteHeaderNumber { get; set; } 
			[DataMember]
			public decimal CreditNoteHeaderValue { get; set; } 
			[DataMember]
			public Guid CreditNoteHeaderCurrencyId { get; set; } 
			[DataMember]
			public DateTime CreditNoteHeaderDate { get; set; } 
			[DataMember]
			public Guid SupplierId { get; set; } 
			[DataMember]
			public bool ReturnToStock { get; set; } 

		}
		#endregion
		#region SClass P_L5RS_SCNaURS_1523a for attribute ShipmentHeaders
		[DataContract]
		public class P_L5RS_SCNaURS_1523a 
		{
			[DataMember]
			public P_L5RS_SCNaURS_1523b[] ShipmentPositions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ReturnShipmentHeaderID { get; set; } 
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass P_L5RS_SCNaURS_1523b for attribute ShipmentPositions
		[DataContract]
		public class P_L5RS_SCNaURS_1523b 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReturnShipmentPositionID { get; set; } 
			[DataMember]
			public Guid ShipmentPositionID { get; set; } 
			[DataMember]
			public Guid ProductId { get; set; } 
			[DataMember]
			public int OriginalQuantity { get; set; } 
			[DataMember]
			public int Quantity { get; set; } 
			[DataMember]
			public Decimal OriginalTotalValue { get; set; } 
			[DataMember]
			public Decimal TotalValue { get; set; } 
			[DataMember]
			public Guid ReturnPolicyID { get; set; } 
			[DataMember]
			public Guid ReceiptPositionID { get; set; } 

		}
		#endregion
		#region SClass L6CN_SCNaURS_0910 for attribute L6CN_SCNaURS_0910
		[DataContract]
		public class L6CN_SCNaURS_0910 
		{
			//Standard type parameters
			[DataMember]
			public Guid CreditNoteHeaderId { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6CN_SCNaURS_0910 cls_Save_CreditNotes_and_UpdateReturnShipments(,P_L6CN_SCNaURS_0910 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6CN_SCNaURS_0910 invocationResult = cls_Save_CreditNotes_and_UpdateReturnShipments.Invoke(connectionString,P_L6CN_SCNaURS_0910 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_CreditNote.Complex.Manipulation.P_L6CN_SCNaURS_0910();
parameter.ShipmentHeaders = ...;

parameter.CreditNoteHeaderNumber = ...;
parameter.CreditNoteHeaderValue = ...;
parameter.CreditNoteHeaderCurrencyId = ...;
parameter.CreditNoteHeaderDate = ...;
parameter.SupplierId = ...;
parameter.ReturnToStock = ...;

*/
