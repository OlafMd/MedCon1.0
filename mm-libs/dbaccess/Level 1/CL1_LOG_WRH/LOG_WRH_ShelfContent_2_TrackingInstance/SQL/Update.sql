UPDATE 
	log_wrh_shelfcontent_2_trackinginstance
SET 
	LOG_ProductTrackingInstance_RefID=@LOG_ProductTrackingInstance_RefID,
	LOG_WRH_Shelf_Content_RefID=@LOG_WRH_Shelf_Content_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID