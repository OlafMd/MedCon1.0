UPDATE 
	log_wrh_shelf_2_quantitylevels
SET 
	LOG_WRH_Shelf_RefID=@LOG_WRH_Shelf_RefID,
	LOG_WRH_QuantityLevel_RefID=@LOG_WRH_QuantityLevel_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID