UPDATE 
	log_wrh_inj_inventoryjob_series_rythms
SET 
	InventoryJob_Series_RefID=@InventoryJob_Series_RefID,
	RythmCronExpression=@RythmCronExpression,
	StartDate=@StartDate,
	EndDate=@EndDate,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_INJ_InventoryJob_Series_RythmID = @LOG_WRH_INJ_InventoryJob_Series_RythmID