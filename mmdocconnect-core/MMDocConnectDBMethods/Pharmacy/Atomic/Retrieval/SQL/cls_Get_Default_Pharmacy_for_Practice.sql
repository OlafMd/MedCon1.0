
Select
  hec_medicalpractice_2_universalproperty.Value_String As DefaultPharmacy
From
  hec_medicalpractises Inner Join
  hec_medicalpractice_2_universalproperty
    On hec_medicalpractises.HEC_MedicalPractiseID =
    hec_medicalpractice_2_universalproperty.HEC_MedicalPractice_RefID And
    hec_medicalpractice_2_universalproperty.Tenant_RefID = @TenantID And
    hec_medicalpractice_2_universalproperty.IsDeleted = 0 Inner Join
  hec_medicalpractice_universalproperties
    On
    hec_medicalpractice_2_universalproperty.HEC_MedicalPractice_UniversalProperty_RefID = hec_medicalpractice_universalproperties.HEC_MedicalPractice_UniversalPropertyID And 
    hec_medicalpractice_universalproperties.PropertyName = "Default pharmacy" And 
    hec_medicalpractice_universalproperties.Tenant_RefID = @TenantID And 
    hec_medicalpractice_universalproperties.IsDeleted = 0
Where
  hec_medicalpractises.HEC_MedicalPractiseID = @PracticeID And
  hec_medicalpractises.Tenant_RefID = @TenantID And
  hec_medicalpractises.IsDeleted = 0
  