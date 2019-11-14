
	Select
	  res_loc_commercialvacancies.RES_LOC_CommercialVacancyID,
	  res_loc_commercialvacancies.CommercialVacancy_Name_DictID
	From
	  res_loc_commercialvacancies
	Where
	  res_loc_commercialvacancies.IsDeleted = 0 And
	  res_loc_commercialvacancies.Tenant_RefID = @TenantID
  