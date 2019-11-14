
	Select
	  log_rcp_receipt_position_discountamounts.LOG_RCP_Receipt_Position_DiscountAmountID,
	  log_rcp_receipt_position_discountamounts.IsAbsoluteValue,
	  log_rcp_receipt_position_discountamounts.IsRelativeValue,
	  log_rcp_receipt_position_discountamounts.PositionDiscountValue,
    log_rcp_receipt_position_discountamounts.LOG_RCP_Receipt_Position_RefID,
    log_rcp_receipt_position_discountamounts.ORD_PRC_DiscountType_RefID
	From
	  log_rcp_receipt_position_discountamounts
	Where
	  log_rcp_receipt_position_discountamounts.LOG_RCP_Receipt_Position_RefID = @ReceiptPositionsID And
	  log_rcp_receipt_position_discountamounts.Tenant_RefID = @TenantID And
	  log_rcp_receipt_position_discountamounts.IsDeleted = 0
  