INSERT INTO 
	log_rcp_receipt_position_qualitycontrolitems
	(
		LOG_RCP_Receipt_Position_QualityControlItem,
		ReceiptPositionCountedItemITL,
		Receipt_Position_RefID,
		Quantity,
		BatchNumber,
		SerialKey,
		ExpiryDate,
		Target_WRH_Shelf_RefID,
		QualityControl_PerformedByBusinessParticipant_RefID,
		QualityControl_PerformedAtDate,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_RCP_Receipt_Position_QualityControlItem,
		@ReceiptPositionCountedItemITL,
		@Receipt_Position_RefID,
		@Quantity,
		@BatchNumber,
		@SerialKey,
		@ExpiryDate,
		@Target_WRH_Shelf_RefID,
		@QualityControl_PerformedByBusinessParticipant_RefID,
		@QualityControl_PerformedAtDate,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)