
	Select
	  res_loc_residentialvacancies.RES_LOC_ResidentialVacancyID,
	  res_loc_residentialvacancies.ResidentialVacancy_Name_DictID
	From
	  res_loc_residentialvacancies
	Where
	  res_loc_residentialvacancies.IsDeleted = 0 And
	  res_loc_residentialvacancies.Tenant_RefID = @TenantID
  