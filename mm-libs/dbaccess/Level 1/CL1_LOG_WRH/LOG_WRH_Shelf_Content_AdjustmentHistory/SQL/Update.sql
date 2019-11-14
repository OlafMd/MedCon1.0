UPDATE 
	log_wrh_shelf_content_adjustmenthistory
SET 
	ContentAdjustments_RefID=@ContentAdjustments_RefID,
	Shelf_Content_RefID=@Shelf_Content_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	LOG_WRH_Shelf_Content_AdjustmentHistoryID = @LOG_WRH_Shelf_Content_AdjustmentHistoryID