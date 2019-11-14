
SELECT
    log_producttrackinginstances.BatchNumber,
    log_producttrackinginstances.SerialNumber,
    log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID,
    log_rcp_receipt_positions.ReceiptPosition_Product_RefID,
    log_rcp_receipt_positions.ExpectedPositionPrice,
    log_rcp_receipt_positions.TotalQuantityTakenIntoStock AS ReceiptQuantity,
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID AS SupplierId,
    cmn_bpt_businessparticipants.DisplayName AS SupplierName
FROM log_producttrackinginstances
INNER JOIN log_wrh_shelfcontent_2_trackinginstance
    ON log_wrh_shelfcontent_2_trackinginstance.LOG_ProductTrackingInstance_RefID = log_producttrackinginstances.LOG_ProductTrackingInstanceID
    AND log_wrh_shelfcontent_2_trackinginstance.Tenant_RefID = log_producttrackinginstances.Tenant_RefID
    AND log_wrh_shelfcontent_2_trackinginstance.IsDeleted = log_producttrackinginstances.IsDeleted
INNER JOIN log_wrh_shelf_contents
    ON log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID = log_wrh_shelfcontent_2_trackinginstance.LOG_WRH_Shelf_Content_RefID
    AND log_wrh_shelf_contents.Tenant_RefID = log_producttrackinginstances.Tenant_RefID
    AND log_wrh_shelf_contents.IsDeleted = log_producttrackinginstances.IsDeleted
INNER JOIN log_rcp_receiptposition_2_procurementorderposition
    ON log_rcp_receiptposition_2_procurementorderposition.ORD_PRO_ProcurementOrder_Position_RefID = log_wrh_shelf_contents.ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID
    AND log_rcp_receiptposition_2_procurementorderposition.Tenant_RefID = log_producttrackinginstances.Tenant_RefID
    AND log_rcp_receiptposition_2_procurementorderposition.IsDeleted = log_producttrackinginstances.IsDeleted
INNER JOIN log_rcp_receipt_positions
	ON log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID = log_rcp_receiptposition_2_procurementorderposition.LOG_RCP_Receipt_Position_RefID
    AND log_rcp_receipt_positions.Tenant_RefID = log_producttrackinginstances.Tenant_RefID
    AND log_rcp_receipt_positions.IsDeleted = log_producttrackinginstances.IsDeleted
INNER JOIN log_rcp_receipt_headers
	ON log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID = log_rcp_receipt_positions.Receipt_Header_RefID
    AND log_rcp_receipt_headers.Tenant_RefID = log_producttrackinginstances.Tenant_RefID
    AND log_rcp_receipt_headers.IsDeleted = log_producttrackinginstances.IsDeleted
INNER JOIN cmn_bpt_suppliers
    ON cmn_bpt_suppliers.CMN_BPT_SupplierID = log_rcp_receipt_headers.ProvidingSupplier_RefID
    AND cmn_bpt_suppliers.Tenant_RefID = log_producttrackinginstances.Tenant_RefID
    AND cmn_bpt_suppliers.IsDeleted = log_producttrackinginstances.IsDeleted
INNER JOIN cmn_bpt_businessparticipants
	ON cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = cmn_bpt_suppliers.Ext_BusinessParticipant_RefID
    AND cmn_bpt_businessparticipants.Tenant_RefID = log_producttrackinginstances.Tenant_RefID
    AND cmn_bpt_businessparticipants.IsDeleted = log_producttrackinginstances.IsDeleted
WHERE
    log_producttrackinginstances.BatchNumber = @BatchNumbers
    AND log_rcp_receipt_positions.ReceiptPosition_Product_RefID = @ProductIDs
    AND log_producttrackinginstances.Tenant_RefID = @TenantID
    AND log_producttrackinginstances.IsDeleted = 0
    AND log_rcp_receipt_headers.IsCustomerReturnReceipt = 0;
  