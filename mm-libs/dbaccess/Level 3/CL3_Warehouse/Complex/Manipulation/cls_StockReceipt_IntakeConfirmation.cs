/* 
 * Generated on 4/28/2014 6:58:12 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL3_Warehouse.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_StockReceipt_IntakeConfirmation.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_StockReceipt_IntakeConfirmation
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3WH_SRIC_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            #region LOG_RCP_Receipt_Headers (Update)

            var receiptHeader = CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header.Query.Search(Connection, Transaction,
                new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header.Query()
                {
                    LOG_RCP_Receipt_HeaderID = Parameter.ReceiptHeaderID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

            receiptHeader.IsTakenIntoStock = true;
            receiptHeader.TakenIntoStock_ByAccount_RefID = securityTicket.AccountID;
            receiptHeader.TakenIntoStock_AtDate = DateTime.Now;
            receiptHeader.DeliverySlip_Date = Parameter.DeliveryDate;
            receiptHeader.DeliverySlip_Number = Parameter.DeliveryNumber;

            receiptHeader.Save(Connection, Transaction);

            #endregion

            #region ORD_PRC_ExpectedDelivery_Headers (Update)

            var expectedDeliveryHeader = CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header.Query.Search(Connection, Transaction,
            new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header.Query()
            {
                ORD_PRC_ExpectedDelivery_HeaderID = receiptHeader.ExpectedDeliveryHeader_RefID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (expectedDeliveryHeader != default(CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header))
            {
                expectedDeliveryHeader.IsDeliveryOpen = false;
                expectedDeliveryHeader.IsDeliveryClosed = true;
                expectedDeliveryHeader.Save(Connection, Transaction);
            }

            #endregion

            #region Receipt_Positions, Position_QualityControlItems ProcurementOrderPositions_and_ProcurementOrderHeader_for_ReceiptHeaderID (Read)

            var positionsAndQualityControlItems = CL3_Warehouse.Atomic.Retrieval.cls_Get_ReceiptPositions_and_QualityControlItems_for_HeaderID.
                Invoke(Connection, Transaction, new CL3_Warehouse.Atomic.Retrieval.P_L3WH_GRPaQCIfH_0905 { ReceiptHeaderID = Parameter.ReceiptHeaderID }, securityTicket).Result;

            var procurementOrderPositions = CL3_Warehouse.Atomic.Retrieval.cls_Get_ProcurementOrderPositions_and_ProcurementOrderHeader_for_ReceiptHeaderID.
                Invoke(Connection, Transaction, new CL3_Warehouse.Atomic.Retrieval.P_L3WH_GPOPaPOHfRH_0918 { ReceiptHeaderID = Parameter.ReceiptHeaderID }, securityTicket).Result;

            #endregion

            #region LOG_WRH_Shelf_Contents (Save)

            foreach (var item in positionsAndQualityControlItems)
            {
                #region ORM_LOG_WRH_Shelf_Content

                var shelfContent = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content();
                shelfContent.LOG_WRH_Shelf_ContentID = Guid.NewGuid();
                shelfContent.Shelf_RefID = item.Target_WRH_Shelf_RefID;
                shelfContent.Quantity_Current = item.Quantity;
                shelfContent.Quantity_Initial = item.Quantity;
                shelfContent.PlacedIntoStock_Date = DateTime.Now;

                // WithoutProcurement -needed when called from Backoffice for return shipments
                if (Parameter.WithoutProcurement == false)
                {
                    var procurementPosition = procurementOrderPositions.Where(x => x.LOG_RCP_Receipt_PositionID == item.Receipt_Position_RefID).Single();

                    shelfContent.ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID = procurementPosition.ORD_PRC_ProcurementOrder_HeaderID;
                    shelfContent.ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID = procurementPosition.ORD_PRC_ProcurementOrder_PositionID;
                    shelfContent.R_ProcurementValue = procurementPosition.Position_ValueTotal;
                    shelfContent.R_ProcurementValue_Currency_RefID = procurementPosition.ProcurementOrder_Currency_RefID;
                }

                shelfContent.Product_RefID = item.ReceiptPosition_Product_RefID;
                shelfContent.R_FreeQuantity = item.Quantity;

                shelfContent.Creation_Timestamp = DateTime.Now;
                shelfContent.Tenant_RefID = securityTicket.TenantID;
                shelfContent.Save(Connection, Transaction);

                #endregion

                #region LOG_WRH_Shelf_ContentAdjustments

                var contentAdjustment = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment();
                contentAdjustment.LOG_WRH_Shelf_ContentAdjustmentID = Guid.NewGuid();
                contentAdjustment.ShelfContent_RefID = shelfContent.LOG_WRH_Shelf_ContentID;

                contentAdjustment.QuantityChangedAmount = item.Quantity;
                contentAdjustment.QuantityChangedDate = DateTime.Now;

                contentAdjustment.IsInitialReceipt = true;
                contentAdjustment.IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID = item.LOG_RCP_Receipt_Position_QualityControlItem;

                contentAdjustment.IsInventoryJobCorrection = false;
                contentAdjustment.IsShipmentWithdrawal = false;
                contentAdjustment.IsManualCorrection = false;

                contentAdjustment.PerformedBy_Account_RefID = securityTicket.AccountID;
                contentAdjustment.PerformedAt_Date = DateTime.Now;

                contentAdjustment.ContentAdjustmentComment = "Product is being added on the shelf after intake confirmation of stock receipt";

                contentAdjustment.Tenant_RefID = securityTicket.TenantID;
                contentAdjustment.Creation_Timestamp = DateTime.Now;
                contentAdjustment.Save(Connection, Transaction);

                #endregion

                bool isTrackable = (!String.IsNullOrEmpty(item.BatchNumber) || (DateTime.MinValue != item.ExpiryDate));
                
                if (isTrackable)
                {
                    #region ORM_LOG_ProductTrackingInstance

                    var trackingInstance = new CL1_LOG.ORM_LOG_ProductTrackingInstance();
                    trackingInstance.LOG_ProductTrackingInstanceID = Guid.NewGuid();
                    trackingInstance.TrackingInstanceTakenFromSourceTrackingInstance_RefID = Guid.Empty;
                    trackingInstance.TrackingCode = String.Empty;
                    trackingInstance.SerialNumber = String.Empty;
                    trackingInstance.BatchNumber = item.BatchNumber;
                    trackingInstance.OwnedBy_BusinessParticipant_RefID = Guid.Empty; //this is important if we want to persist owner of product (mobile phone in a service)
                    trackingInstance.CMN_PRO_Product_RefID = item.ReceiptPosition_Product_RefID; ;
                    trackingInstance.CMN_PRO_Product_Release_RefID = Guid.Empty;
                    trackingInstance.CMN_PRO_Product_Variant_RefID = Guid.Empty;
                    trackingInstance.ExpirationDate = item.ExpiryDate;
                    trackingInstance.InitialQuantityOnTrackingInstance = item.Quantity;
                    trackingInstance.CurrentQuantityOnTrackingInstance = item.Quantity;
                    trackingInstance.R_ReservedQuantity = 0;
                    trackingInstance.R_FreeQuantity = item.Quantity;
                    trackingInstance.Creation_Timestamp = DateTime.Now;
                    trackingInstance.Tenant_RefID = securityTicket.TenantID;
                    trackingInstance.Save(Connection, Transaction);

                    #endregion

                    #region ORM_LOG_ProductTrackingInstance_HistoryEntry

                    var trackingInstanceHistory = new CL1_LOG.ORM_LOG_ProductTrackingInstance_HistoryEntry();
                    trackingInstanceHistory.LOG_ProductTrackingInstance_HistoryEntryID = Guid.NewGuid();
                    trackingInstanceHistory.ProductTrackingInstance_RefID = trackingInstance.LOG_ProductTrackingInstanceID;
                    trackingInstanceHistory.HistoryEntry_Text = "Product is being added on the shelf after intake confirmation of stock receipt";
                    trackingInstanceHistory.Creation_Timestamp = DateTime.Now;
                    trackingInstanceHistory.Tenant_RefID = securityTicket.TenantID;
                    trackingInstanceHistory.Save(Connection, Transaction);

                    #endregion

                    #region ORM_LOG_WRH_Shelf_ContentAdjustment_TrackingInstance

                    var adjustment2tracking = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment_TrackingInstance();
                    adjustment2tracking.LOG_WRH_Shelf_ContentAdjustment_TrackingInstanceID = Guid.NewGuid();
                    adjustment2tracking.LOG_ProductTrackingInstance_RefID = trackingInstance.LOG_ProductTrackingInstanceID;
                    adjustment2tracking.LOG_WRH_Shelf_ContentAdjustment_RefID = contentAdjustment.LOG_WRH_Shelf_ContentAdjustmentID;
                    adjustment2tracking.QuantityChangedAmount = item.Quantity;
                    adjustment2tracking.Creation_Timestamp = DateTime.Now;
                    adjustment2tracking.Tenant_RefID = securityTicket.TenantID;
                    adjustment2tracking.Save(Connection, Transaction);
                    
                    #endregion

                    #region ORM_LOG_WRH_ShelfContent_2_TrackingInstance

                    var shelf2tracking = new CL1_LOG_WRH.ORM_LOG_WRH_ShelfContent_2_TrackingInstance();
                    shelf2tracking.AssignmentID = Guid.NewGuid();
                    shelf2tracking.LOG_ProductTrackingInstance_RefID = trackingInstance.LOG_ProductTrackingInstanceID;
                    shelf2tracking.LOG_WRH_Shelf_Content_RefID = shelfContent.LOG_WRH_Shelf_ContentID;
                    shelf2tracking.Creation_Timestamp = DateTime.Now;
                    shelf2tracking.Tenant_RefID = securityTicket.TenantID;
                    shelf2tracking.Save(Connection, Transaction);

                    #endregion
                }
            }

            #endregion

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3WH_SRIC_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3WH_SRIC_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3WH_SRIC_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3WH_SRIC_1421 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_StockReceipt_IntakeConfirmation",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3WH_SRIC_1421 for attribute P_L3WH_SRIC_1421
		[DataContract]
		public class P_L3WH_SRIC_1421 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 
			[DataMember]
			public string DeliveryNumber { get; set; } 
			[DataMember]
			public DateTime DeliveryDate { get; set; } 
			[DataMember]
			public Boolean WithoutProcurement { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_StockReceipt_IntakeConfirmation(,P_L3WH_SRIC_1421 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_StockReceipt_IntakeConfirmation.Invoke(connectionString,P_L3WH_SRIC_1421 Parameter,securityTicket);
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
var parameter = new CL3_Warehouse.Complex.Manipulation.P_L3WH_SRIC_1421();
parameter.ReceiptHeaderID = ...;
parameter.DeliveryNumber = ...;
parameter.DeliveryDate = ...;
parameter.WithoutProcurement = ...;

*/
