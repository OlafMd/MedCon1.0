UPDATE 
	res_loc_locationinformation_2_emmission
SET 
	RES_LOC_LocationInformation_RefID=@RES_LOC_LocationInformation_RefID,
	RES_LOC_Emmission_RefID=@RES_LOC_Emmission_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID