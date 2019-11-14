UPDATE 
	log_wrh_inj_inventoryjob_series
SET 
	InventoryJobSeries_DisplayName=@InventoryJobSeries_DisplayName,
	IsUsingNumberOfProductsSeriesType=@IsUsingNumberOfProductsSeriesType,
	NumberOfProductsToSelect=@NumberOfProductsToSelect,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_INJ_InventoryJob_SeriesID = @LOG_WRH_INJ_InventoryJob_SeriesID