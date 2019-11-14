UPDATE 
	res_loc_locationinfo_2_residentialvacancy
SET 
	RES_LOC_LocationInfo_RefID=@RES_LOC_LocationInfo_RefID,
	RES_LOC_ResidentialVacancy_RefID=@RES_LOC_ResidentialVacancy_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID