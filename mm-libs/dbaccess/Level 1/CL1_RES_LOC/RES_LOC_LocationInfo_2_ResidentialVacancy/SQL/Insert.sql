INSERT INTO 
	res_loc_locationinfo_2_residentialvacancy
	(
		AssignmentID,
		RES_LOC_LocationInfo_RefID,
		RES_LOC_ResidentialVacancy_RefID,
		Comment,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@RES_LOC_LocationInfo_RefID,
		@RES_LOC_ResidentialVacancy_RefID,
		@Comment,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)