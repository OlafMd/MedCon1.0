UPDATE 
	log_wrh_inj_inventoryjob_series_participatingshelves
SET 
	LOG_WRH_INJ_InventoryJob_Series_RefID=@LOG_WRH_INJ_InventoryJob_Series_RefID,
	LOG_WRH_Shelf_RefID=@LOG_WRH_Shelf_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelfID = @LOG_WRH_INJ_InventoryJob_Series_ParticipatingShelfID