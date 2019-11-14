UPDATE 
	log_wrh_shelf_contents
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Shelf_RefID=@Shelf_RefID,
	Quantity_Current=@Quantity_Current,
	Quantity_Initial=@Quantity_Initial,
	UsedShelfCapacityAmount=@UsedShelfCapacityAmount,
	PlacedIntoStock_Date=@PlacedIntoStock_Date,
	ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID=@ReceivedAsFulfillmentOf_ProcurementOrderHeader_RefID,
	ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID=@ReceivedAsFulfillmentOf_ProcurementOrderPosition_RefID,
	R_ProcurementValue=@R_ProcurementValue,
	R_ProcurementValue_Currency_RefID=@R_ProcurementValue_Currency_RefID,
	Product_RefID=@Product_RefID,
	Product_Variant_RefID=@Product_Variant_RefID,
	Product_Release_RefID=@Product_Release_RefID,
	ReceptionDate=@ReceptionDate,
	IntakeIntoInventoryDate=@IntakeIntoInventoryDate,
	IsLocked=@IsLocked,
	R_ReservedQuantity=@R_ReservedQuantity,
	R_FreeQuantity=@R_FreeQuantity,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_Shelf_ContentID = @LOG_WRH_Shelf_ContentID