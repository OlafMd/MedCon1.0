
	Select
	  hec_medicalservices.ServiceName_DictID,
	  hec_medicalservices.HEC_MedicalServiceID
	From
	  hec_medicalservices
	Where
	  hec_medicalservices.Tenant_RefID = @TenantID And
	  hec_medicalservices.IsDeleted = 0
  