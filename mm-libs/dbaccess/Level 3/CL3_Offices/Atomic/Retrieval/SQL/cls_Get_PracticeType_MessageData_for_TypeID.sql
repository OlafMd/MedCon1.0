
Select
  hec_medicalpractice_types.MedicalPracticeType_Name_DictID,
  hec_medicalpractice_types.MedicalPracticeTypeITL,
  hec_medicalpractice_types.IsDeleted,
  hec_medicalpractice_types.HEC_MedicalPractice_TypeID
From
  hec_medicalpractice_types
Where
  hec_medicalpractice_types.Tenant_RefID = @TenantID And
  hec_medicalpractice_types.HEC_MedicalPractice_TypeID = @TypeID
  