
	Select
	  res_loc_parkingsituations.RES_LOC_ParkingSituationID,
	  res_loc_parkingsituations.ParkingSituation_Name_DictID
	From
	  res_loc_parkingsituations
	Where
	  res_loc_parkingsituations.IsDeleted = 0 And
	  res_loc_parkingsituations.Tenant_RefID = @TenantID
  