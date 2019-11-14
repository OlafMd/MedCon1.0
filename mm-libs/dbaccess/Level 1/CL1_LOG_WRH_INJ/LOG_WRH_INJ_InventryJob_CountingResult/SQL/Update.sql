UPDATE 
	log_wrh_inj_inventryjob_countingresults
SET 
	CountingRun_RefID=@CountingRun_RefID,
	Process_Shelf_RefID=@Process_Shelf_RefID,
	CountedAmount=@CountedAmount,
	IsDifferenceToExpectedQuantityFound=@IsDifferenceToExpectedQuantityFound,
	Product_RefID=@Product_RefID,
	Product_Variant_RefID=@Product_Variant_RefID,
	Product_Release_RefID=@Product_Release_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_INJ_InventoryJob_CountingResultID = @LOG_WRH_INJ_InventoryJob_CountingResultID