INSERT INTO 
	log_wrh_shelf_content_adjustmenthistory
	(
		LOG_WRH_Shelf_Content_AdjustmentHistoryID,
		ContentAdjustments_RefID,
		Shelf_Content_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@LOG_WRH_Shelf_Content_AdjustmentHistoryID,
		@ContentAdjustments_RefID,
		@Shelf_Content_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)