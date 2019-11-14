
	Select
	  res_loc_emmissions.RES_LOC_EmmissionID,
	  res_loc_emmissions.Emmission_Name_DictID
	From
	  res_loc_emmissions
	Where
	  res_loc_emmissions.IsDeleted = 0 And
	  res_loc_emmissions.Tenant_RefID = @TenantID
  