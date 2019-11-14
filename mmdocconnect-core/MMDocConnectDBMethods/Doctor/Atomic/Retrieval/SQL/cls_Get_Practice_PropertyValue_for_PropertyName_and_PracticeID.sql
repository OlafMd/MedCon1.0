
    Select
      hec_medicalpractice_2_universalproperty.Value_Boolean As BooleanValue,
      hec_medicalpractice_2_universalproperty.Value_Number As NumericValue,
      hec_medicalpractice_2_universalproperty.Value_String As TextValue
    From
      hec_medicalpractice_2_universalproperty
      Inner Join hec_medicalpractice_universalproperties
        On hec_medicalpractice_2_universalproperty.HEC_MedicalPractice_UniversalProperty_RefID = hec_medicalpractice_universalproperties.HEC_MedicalPractice_UniversalPropertyID And
        hec_medicalpractice_2_universalproperty.Tenant_RefID = @TenantID And hec_medicalpractice_2_universalproperty.IsDeleted = 0 And
        hec_medicalpractice_2_universalproperty.HEC_MedicalPractice_RefID = @PracticeID
    Where
      hec_medicalpractice_universalproperties.PropertyName = @PropertyName And
      hec_medicalpractice_universalproperties.Tenant_RefID = @TenantID And
      hec_medicalpractice_universalproperties.IsDeleted = 0
	