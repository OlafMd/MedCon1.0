
	Select
	  hec_medicalpractice_types.HEC_MedicalPractice_TypeID,
	  hec_medicalpractice_types.MedicalPracticeType_Name_DictID
	From
	  hec_medicalpractice_types
	Where
	  hec_medicalpractice_types.IsDeleted = 0 And
	  hec_medicalpractice_types.Tenant_RefID = @TenantID
  