INSERT INTO 
	res_loc_residentialvacancies
	(
		RES_LOC_ResidentialVacancyID,
		ResidentialVacancy_Name_DictID,
		ResidentialVacancy_Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_LOC_ResidentialVacancyID,
		@ResidentialVacancy_Name,
		@ResidentialVacancy_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)