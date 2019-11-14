UPDATE 
	log_rcp_receipt_position_qualitycontrolitems
SET 
	ReceiptPositionCountedItemITL=@ReceiptPositionCountedItemITL,
	Receipt_Position_RefID=@Receipt_Position_RefID,
	Quantity=@Quantity,
	BatchNumber=@BatchNumber,
	SerialKey=@SerialKey,
	ExpiryDate=@ExpiryDate,
	Target_WRH_Shelf_RefID=@Target_WRH_Shelf_RefID,
	QualityControl_PerformedByBusinessParticipant_RefID=@QualityControl_PerformedByBusinessParticipant_RefID,
	QualityControl_PerformedAtDate=@QualityControl_PerformedAtDate,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_RCP_Receipt_Position_QualityControlItem = @LOG_RCP_Receipt_Position_QualityControlItem