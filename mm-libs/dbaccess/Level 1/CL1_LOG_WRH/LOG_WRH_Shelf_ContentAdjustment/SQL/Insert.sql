INSERT INTO 
	log_wrh_shelf_contentadjustments
	(
		LOG_WRH_Shelf_ContentAdjustmentID,
		ShelfContent_RefID,
		QuantityChangedAmount,
		QuantityChangedDate,
		IsInitialReceipt,
		IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID,
		IsInventoryJobCorrection,
		IfInventoryJobCorrection_InvenoryJobProcess_RefID,
		IsShipmentWithdrawal,
		IfShipmentWithdrawal_ShipmentPosition_RefID,
		IsManualCorrection,
		IfManualCorrection_InventoryChangeReason_RefID,
		PerformedBy_Account_RefID,
		PerformedAt_Date,
		ContentAdjustmentComment,
		IsBatchNumberOrSerialKeyUpdate,
		IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID,
		IsRelocation,
		IfRelocation_CorrespondingAdjustment_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_WRH_Shelf_ContentAdjustmentID,
		@ShelfContent_RefID,
		@QuantityChangedAmount,
		@QuantityChangedDate,
		@IsInitialReceipt,
		@IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID,
		@IsInventoryJobCorrection,
		@IfInventoryJobCorrection_InvenoryJobProcess_RefID,
		@IsShipmentWithdrawal,
		@IfShipmentWithdrawal_ShipmentPosition_RefID,
		@IsManualCorrection,
		@IfManualCorrection_InventoryChangeReason_RefID,
		@PerformedBy_Account_RefID,
		@PerformedAt_Date,
		@ContentAdjustmentComment,
		@IsBatchNumberOrSerialKeyUpdate,
		@IfBatchNumberOrSerialKeyUpdate_CorrespondingAdjustment_RefID,
		@IsRelocation,
		@IfRelocation_CorrespondingAdjustment_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)