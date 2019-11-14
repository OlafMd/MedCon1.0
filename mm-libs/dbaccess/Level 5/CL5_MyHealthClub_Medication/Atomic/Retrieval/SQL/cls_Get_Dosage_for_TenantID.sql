
	Select
	  hec_dosages.HEC_DosageID,
	  hec_dosages.DosageText
	From
	  hec_dosages
	Where
	  hec_dosages.Tenant_RefID = @TenantID And
	  hec_dosages.IsDeleted = 0
  