UPDATE 
	log_wrh_inj_countingresult_trackinginstances
SET 
	LOG_WRH_INJ_InventoryJob_CountingResult_RefID=@LOG_WRH_INJ_InventoryJob_CountingResult_RefID,
	LOG_ProductTrackingInstanceID=@LOG_ProductTrackingInstanceID,
	CountedAmount=@CountedAmount,
	IsDifferenceToExpectedQuantityFound=@IsDifferenceToExpectedQuantityFound,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_INJ_CountingResult_TrackingInstanceID = @LOG_WRH_INJ_CountingResult_TrackingInstanceID