UPDATE 
	res_loc_commercialvacancies
SET 
	CommercialVacancy_Name_DictID=@CommercialVacancy_Name,
	CommercialVacancy_Description_DictID=@CommercialVacancy_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_LOC_CommercialVacancyID = @RES_LOC_CommercialVacancyID