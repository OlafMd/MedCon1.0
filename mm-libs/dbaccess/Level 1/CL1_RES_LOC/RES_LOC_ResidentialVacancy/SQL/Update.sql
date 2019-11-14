UPDATE 
	res_loc_residentialvacancies
SET 
	ResidentialVacancy_Name_DictID=@ResidentialVacancy_Name,
	ResidentialVacancy_Description_DictID=@ResidentialVacancy_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_LOC_ResidentialVacancyID = @RES_LOC_ResidentialVacancyID