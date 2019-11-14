
Select
  X.*,
  Sum(log_wrh_shelf_contents.Quantity_Current) As StockQuantity
From
  (Select
    log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID,
    log_rcp_receipt_headers.ReceiptNumber,
    cmn_bpt_businessparticipants.DisplayName As Supplier,
    log_rcp_receipt_headers.Creation_Timestamp,
    log_rcp_receipt_position_qualitycontrolitems.BatchNumber,
    log_rcp_receipt_position_qualitycontrolitems.ExpiryDate,
    log_rcp_receipt_positions.TotalQuantityTakenIntoStock As InitialQuantity,
    log_rcp_receipt_positions.ReceiptPosition_Product_RefID,
    log_rcp_receipt_positions.ExpectedPositionPrice,
    log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID,
    log_wrh_shelfcontent_2_trackinginstance.LOG_ProductTrackingInstance_RefID,
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID As SupplierId,
    log_rcp_receipt_position_qualitycontrolitems.LOG_RCP_Receipt_Position_QualityControlItem,
    log_wrh_shelf_contents.R_FreeQuantity As FreeQuantity,
    log_wrh_shelf_contents.Quantity_Current As CurrentQuantity
  From
    log_rcp_receipt_positions Inner Join
    log_rcp_receipt_headers On log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID
      = log_rcp_receipt_positions.Receipt_Header_RefID And
      log_rcp_receipt_headers.Tenant_RefID =
      log_rcp_receipt_positions.Tenant_RefID And
      log_rcp_receipt_headers.IsDeleted = log_rcp_receipt_positions.IsDeleted
    Inner Join
    cmn_bpt_suppliers On cmn_bpt_suppliers.CMN_BPT_SupplierID =
      log_rcp_receipt_headers.ProvidingSupplier_RefID And
      cmn_bpt_suppliers.Tenant_RefID = log_rcp_receipt_positions.Tenant_RefID
      And cmn_bpt_suppliers.IsDeleted = log_rcp_receipt_positions.IsDeleted
    Inner Join
    cmn_bpt_businessparticipants
      On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
      cmn_bpt_suppliers.Ext_BusinessParticipant_RefID And
      cmn_bpt_businessparticipants.Tenant_RefID =
      log_rcp_receipt_positions.Tenant_RefID And
      cmn_bpt_businessparticipants.IsDeleted =
      log_rcp_receipt_positions.IsDeleted Left Join
    log_rcp_receipt_position_qualitycontrolitems
      On log_rcp_receipt_position_qualitycontrolitems.Receipt_Position_RefID =
      log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID And
      log_rcp_receipt_position_qualitycontrolitems.Tenant_RefID =
      log_rcp_receipt_positions.Tenant_RefID And
      log_rcp_receipt_position_qualitycontrolitems.IsDeleted =
      log_rcp_receipt_positions.IsDeleted Inner Join
    log_rcp_receiptposition_2_procurementorderposition
      On
      log_rcp_receiptposition_2_procurementorderposition.LOG_RCP_Receipt_Position_RefID = log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID And log_rcp_receiptposition_2_procurementorderposition.Tenant_RefID = log_rcp_receipt_positions.Tenant_RefID And log_rcp_receiptposition_2_procurementorderposition.IsDeleted = log_rcp_receipt_positions.IsDeleted Inner Join
    log_wrh_shelf_contents On log_wrh_shelf_contents.Shelf_RefID =
      log_rcp_receipt_position_qualitycontrolitems.Target_WRH_Shelf_RefID And
      log_rcp_receipt_positions.ReceiptPosition_Product_RefID =
      log_wrh_shelf_contents.Product_RefID And
      log_wrh_shelf_contents.ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID = log_rcp_receiptposition_2_procurementorderposition.ORD_PRO_ProcurementOrder_Position_RefID And log_wrh_shelf_contents.Tenant_RefID = log_rcp_receipt_positions.Tenant_RefID And log_wrh_shelf_contents.IsDeleted = log_rcp_receipt_positions.IsDeleted Left Join
    log_wrh_shelfcontent_2_trackinginstance
      On log_wrh_shelfcontent_2_trackinginstance.LOG_WRH_Shelf_Content_RefID =
      log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID And
      log_wrh_shelfcontent_2_trackinginstance.Tenant_RefID =
      log_rcp_receipt_positions.Tenant_RefID And
      log_wrh_shelfcontent_2_trackinginstance.IsDeleted =
      log_rcp_receipt_positions.IsDeleted
  Where
    log_rcp_receipt_positions.ReceiptPosition_Product_RefID = @ProductID And
    log_rcp_receipt_positions.Tenant_RefID = @TenantID And
    log_rcp_receipt_positions.IsDeleted = 0 And
    log_wrh_shelf_contents.Quantity_Current > 0
  Group By
    log_rcp_receipt_position_qualitycontrolitems.LOG_RCP_Receipt_Position_QualityControlItem, log_wrh_shelf_contents.R_FreeQuantity, log_wrh_shelf_contents.Quantity_Current) As X Inner Join
  log_wrh_shelf_contents On log_wrh_shelf_contents.Product_RefID =
    X.ReceiptPosition_Product_RefID And log_wrh_shelf_contents.IsDeleted = 0 And
    log_wrh_shelf_contents.Tenant_RefID = @TenantID
Group By
  X.LOG_RCP_Receipt_Position_QualityControlItem
  