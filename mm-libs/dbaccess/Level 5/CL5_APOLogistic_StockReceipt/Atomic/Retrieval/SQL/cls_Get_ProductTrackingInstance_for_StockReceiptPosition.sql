
    SELECT 
      log_rcp_receiptposition_2_procurementorderposition.LOG_RCP_Receipt_Position_RefID,
      log_producttrackinginstances.LOG_ProductTrackingInstanceID,
      log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID
    FROM log_rcp_receiptposition_2_procurementorderposition
    INNER JOIN ord_prc_procurementorder_positions
      ON ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID = log_rcp_receiptposition_2_procurementorderposition.ORD_PRO_ProcurementOrder_Position_RefID
      AND ord_prc_procurementorder_positions.Tenant_RefID = log_rcp_receiptposition_2_procurementorderposition.Tenant_RefID
      AND ord_prc_procurementorder_positions.IsDeleted = 0
    INNER JOIN log_wrh_shelf_contents
      ON log_wrh_shelf_contents.ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID
      AND log_wrh_shelf_contents.Tenant_RefID = log_rcp_receiptposition_2_procurementorderposition.Tenant_RefID
      AND log_wrh_shelf_contents.IsDeleted = 0
    INNER JOIN log_wrh_shelfcontent_2_trackinginstance
      ON log_wrh_shelfcontent_2_trackinginstance.LOG_WRH_Shelf_Content_RefID = log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID
      AND log_wrh_shelfcontent_2_trackinginstance.Tenant_RefID = log_rcp_receiptposition_2_procurementorderposition.Tenant_RefID
      AND log_wrh_shelfcontent_2_trackinginstance.IsDeleted = 0
    INNER JOIN log_producttrackinginstances
      ON log_producttrackinginstances.LOG_ProductTrackingInstanceID = log_wrh_shelfcontent_2_trackinginstance.LOG_ProductTrackingInstance_RefID
      AND log_producttrackinginstances.Tenant_RefID = log_rcp_receiptposition_2_procurementorderposition.Tenant_RefID
      AND log_producttrackinginstances.IsDeleted = 0
    WHERE
      log_rcp_receiptposition_2_procurementorderposition.LOG_RCP_Receipt_Position_RefID = @ReceiptPositionsID
      AND log_rcp_receiptposition_2_procurementorderposition.Tenant_RefID = @TenantID
      AND log_rcp_receiptposition_2_procurementorderposition.IsDeleted = 0;

  