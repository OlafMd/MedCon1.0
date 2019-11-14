
	Select
	  res_loc_neighborhoodqualities.RES_LOC_NeighborhoodQualityID,
	  res_loc_neighborhoodqualities.NeighborhoodQuality_Name_DictID
	From
	  res_loc_neighborhoodqualities
	Where
	  res_loc_neighborhoodqualities.IsDeleted = 0 And
	  res_loc_neighborhoodqualities.Tenant_RefID = @TenantID
  