
	Select
	  res_loc_meansoftransportations.RES_LOC_MeansOfTransportationID,
	  res_loc_meansoftransportations.Transportation_Name_DictID
	From
	  res_loc_meansoftransportations
	Where
	  res_loc_meansoftransportations.IsDeleted = 0 And
	  res_loc_meansoftransportations.Tenant_RefID = @TenantID
  