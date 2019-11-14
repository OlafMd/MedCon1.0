
Select
  hec_medicalpractice_2_universalproperty.Value_String As PeriodStartAt,
  hec_medicalpractises.HEC_MedicalPractiseID,
  hec_medicalpractice_2_universalproperty.AssignmentID
From
  hec_medicalpractises Inner Join
  hec_medicalpractice_2_universalproperty
    On hec_medicalpractises.HEC_MedicalPractiseID =
    hec_medicalpractice_2_universalproperty.HEC_MedicalPractice_RefID And
    hec_medicalpractice_2_universalproperty.IsDeleted = 0 And
    hec_medicalpractice_2_universalproperty.Tenant_RefID = @TenantID Inner Join
  hec_medicalpractice_universalproperties
    On hec_medicalpractice_universalproperties.IsDeleted = 0 And
    hec_medicalpractice_universalproperties.Tenant_RefID = @TenantID And
    hec_medicalpractice_universalproperties.GlobalPropertyMatchingID = 'mm.docconnect.practice.pasword-grace-period' And
    hec_medicalpractice_2_universalproperty.HEC_MedicalPractice_UniversalProperty_RefID = hec_medicalpractice_universalproperties.HEC_MedicalPractice_UniversalPropertyID
Where
  hec_medicalpractises.IsDeleted = 0 And
  hec_medicalpractises.Tenant_RefID = @TenantID And
  hec_medicalpractises.HEC_MedicalPractiseID = @PracticeID
	