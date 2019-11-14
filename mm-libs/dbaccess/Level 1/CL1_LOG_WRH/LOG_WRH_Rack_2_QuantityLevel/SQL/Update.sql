UPDATE 
	log_wrh_rack_2_quantitylevels
SET 
	LOG_WRH_Rack_RefID=@LOG_WRH_Rack_RefID,
	LOG_WRH_QuantityLevel_RefID=@LOG_WRH_QuantityLevel_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID