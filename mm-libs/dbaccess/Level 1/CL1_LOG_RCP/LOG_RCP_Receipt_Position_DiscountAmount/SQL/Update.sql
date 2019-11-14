UPDATE 
	log_rcp_receipt_position_discountamounts
SET 
	ORD_PRC_DiscountType_RefID=@ORD_PRC_DiscountType_RefID,
	LOG_RCP_Receipt_Position_RefID=@LOG_RCP_Receipt_Position_RefID,
	IsAbsoluteValue=@IsAbsoluteValue,
	IsRelativeValue=@IsRelativeValue,
	PositionDiscountValue=@PositionDiscountValue,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_RCP_Receipt_Position_DiscountAmountID = @LOG_RCP_Receipt_Position_DiscountAmountID