
   SELECT
      log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID,
      log_rcp_receipt_positions.ReceiptPosition_Product_RefID,
      log_rcp_receipt_position_qualitycontrolitems.Target_WRH_Shelf_RefID,
      log_rcp_receipt_positions.ExpectedPositionPrice AS Receipt_ExpectedPositionPrice,
      log_rcp_receipt_positions.TotalQuantityTakenIntoStock AS Receipt_TotalQuantityTakenIntoStock,
      log_rcp_receipt_positions.PriceOnSupplierBill,
      ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID,
      ord_prc_procurementorder_positions.Position_Quantity AS Procurement_OrderedQuantity,
      ord_prc_procurementorder_positions.Position_ValuePerUnit AS Procurement_ValuePerUnit,
      ord_prc_procurementorder_positions.Position_ValueTotal AS Procurement_ValueTotal,
      log_rcp_receipt_position_qualitycontrolitems.Quantity AS QualityControl_Quantity,
      log_rcp_receipt_position_qualitycontrolitems.BatchNumber,
      log_rcp_receipt_position_qualitycontrolitems.ExpiryDate,
      log_rcp_receipt_headers.IsQualityControlPerformed,
      log_rcp_receipt_position_discountamounts.PositionDiscountValue,
      log_rcp_receipt_position_discountamounts.ORD_PRC_DiscountType_RefID,
      log_rcp_receipt_position_discountamounts.LOG_RCP_Receipt_Position_DiscountAmountID,
      log_rcp_receipt_positions.TotalQuantityFreeOfCharge,
      log_wrh_shelf_contentadjustments.ShelfContent_RefID,
      log_wrh_shelf_contentadjustment_trackinginstances.LOG_ProductTrackingInstance_RefID,
      ord_prc_discounttypes.GlobalPropertyMatchingID,
      ord_prc_discounttypes.DisplayName
    FROM log_rcp_receipt_positions
    INNER JOIN log_rcp_receipt_headers 
        ON log_rcp_receipt_positions.Receipt_Header_RefID = log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID
        AND log_rcp_receipt_positions.Tenant_RefID = @TenantID
        AND log_rcp_receipt_positions.IsDeleted = 0
    LEFT JOIN log_rcp_receiptposition_2_procurementorderposition
       ON log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID = log_rcp_receiptposition_2_procurementorderposition.LOG_RCP_Receipt_Position_RefID 
        AND log_rcp_receiptposition_2_procurementorderposition.Tenant_RefID = @TenantID 
        AND log_rcp_receiptposition_2_procurementorderposition.IsDeleted = 0
    LEFT JOIN ord_prc_procurementorder_positions
        ON log_rcp_receiptposition_2_procurementorderposition.ORD_PRO_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID
        AND ord_prc_procurementorder_positions.Tenant_RefID = @TenantID 
        AND ord_prc_procurementorder_positions.IsDeleted = 0
    LEFT JOIN log_rcp_receipt_position_qualitycontrolitems
       ON log_rcp_receipt_position_qualitycontrolitems.Receipt_Position_RefID = log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID
        AND log_rcp_receipt_position_qualitycontrolitems.Tenant_RefID = @TenantID
       AND log_rcp_receipt_position_qualitycontrolitems.IsDeleted = 0
    LEFT JOIN log_rcp_receipt_position_discountamounts
        ON log_rcp_receipt_position_discountamounts.LOG_RCP_Receipt_Position_RefID = log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID
        AND log_rcp_receipt_position_discountamounts.Tenant_RefID = @TenantID
        AND log_rcp_receipt_position_discountamounts.IsDeleted = 0
    LEFT JOIN ord_prc_discounttypes
        ON ord_prc_discounttypes.ORD_PRC_DiscountTypeID = log_rcp_receipt_position_discountamounts.ORD_PRC_DiscountType_RefID
        AND ord_prc_discounttypes.Tenant_RefID = @TenantID
        AND ord_prc_discounttypes.IsDeleted = 0
    LEFT JOIN log_wrh_shelf_contentadjustments
        ON log_wrh_shelf_contentadjustments.IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID = log_rcp_receipt_position_qualitycontrolitems.LOG_RCP_Receipt_Position_QualityControlItem
        AND log_wrh_shelf_contentadjustments.Tenant_RefID = @TenantID
        AND log_wrh_shelf_contentadjustments.IsDeleted = 0
    LEFT JOIN log_wrh_shelf_contentadjustment_trackinginstances
        ON log_wrh_shelf_contentadjustment_trackinginstances.LOG_WRH_Shelf_ContentAdjustment_RefID = log_wrh_shelf_contentadjustments.LOG_WRH_Shelf_ContentAdjustmentID
        AND log_wrh_shelf_contentadjustment_trackinginstances.Tenant_RefID = @TenantID
        AND log_wrh_shelf_contentadjustment_trackinginstances.IsDeleted = 0
    WHERE
       log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID = @ReceiptHeaderID
       AND log_rcp_receipt_headers.Tenant_RefID = @TenantID  
       AND log_rcp_receipt_headers.IsDeleted = 0
  