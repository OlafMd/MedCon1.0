INSERT INTO 
	log_wrh_shelf_contents
	(
		LOG_WRH_Shelf_ContentID,
		GlobalPropertyMatchingID,
		Shelf_RefID,
		Quantity_Current,
		Quantity_Initial,
		UsedShelfCapacityAmount,
		PlacedIntoStock_Date,
		ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID,
		ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID,
		R_ProcurementValue,
		R_ProcurementValue_Currency_RefID,
		Product_RefID,
		Product_Variant_RefID,
		Product_Release_RefID,
		ReceptionDate,
		IntakeIntoInventoryDate,
		IsLocked,
		R_ReservedQuantity,
		R_FreeQuantity,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_WRH_Shelf_ContentID,
		@GlobalPropertyMatchingID,
		@Shelf_RefID,
		@Quantity_Current,
		@Quantity_Initial,
		@UsedShelfCapacityAmount,
		@PlacedIntoStock_Date,
		@ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID,
		@ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID,
		@R_ProcurementValue,
		@R_ProcurementValue_Currency_RefID,
		@Product_RefID,
		@Product_Variant_RefID,
		@Product_Release_RefID,
		@ReceptionDate,
		@IntakeIntoInventoryDate,
		@IsLocked,
		@R_ReservedQuantity,
		@R_FreeQuantity,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)