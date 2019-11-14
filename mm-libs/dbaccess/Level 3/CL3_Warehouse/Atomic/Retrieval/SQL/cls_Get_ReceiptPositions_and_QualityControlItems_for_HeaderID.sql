
    Select
      log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID,
      log_rcp_receipt_positions.Receipt_Header_RefID,
      log_rcp_receipt_positions.ReceiptPosition_Product_RefID,
      log_rcp_receipt_position_qualitycontrolitems.LOG_RCP_Receipt_Position_QualityControlItem,
      log_rcp_receipt_position_qualitycontrolitems.Receipt_Position_RefID,
      log_rcp_receipt_position_qualitycontrolitems.Quantity,
      log_rcp_receipt_position_qualitycontrolitems.BatchNumber,
      log_rcp_receipt_position_qualitycontrolitems.SerialKey,
      log_rcp_receipt_position_qualitycontrolitems.ExpiryDate,
      log_rcp_receipt_position_qualitycontrolitems.Target_WRH_Shelf_RefID
    From
      log_rcp_receipt_positions Inner Join
      log_rcp_receipt_position_qualitycontrolitems
        On log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID =
        log_rcp_receipt_position_qualitycontrolitems.Receipt_Position_RefID
    Where
      log_rcp_receipt_positions.Receipt_Header_RefID = @ReceiptHeaderID And
      log_rcp_receipt_positions.Tenant_RefID = @TenantID And
      log_rcp_receipt_positions.IsDeleted = 0 And
      log_rcp_receipt_position_qualitycontrolitems.IsDeleted = 0
  