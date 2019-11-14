
	Select
	  hec_patient_parameters.Parameter_Name_DictID,
	  hec_patient_parameters.HEC_Patient_ParameterID,
	  hec_patient_parameters.IsFloat_ApplicableUnit_RefID
	From
	  hec_patient_parameters
	Where
	  hec_patient_parameters.Tenant_RefID = @TenantID And
	  hec_patient_parameters.IsDeleted = 0
  