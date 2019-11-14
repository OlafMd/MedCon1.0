
	Select
	  res_loc_surroundinginfrastructures.RES_LOC_SurroundingInfrastructureID,
	  res_loc_surroundinginfrastructures.SurroundingInfrastructure_Name_DictID
	From
	  res_loc_surroundinginfrastructures
	Where
	  res_loc_surroundinginfrastructures.IsDeleted = 0 And
	  res_loc_surroundinginfrastructures.Tenant_RefID = @TenantID
  