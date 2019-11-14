
    Select
      count(distinct hec_cas_cases.Patient_RefID) As case_count
    From
      hec_cas_case_universalpropertyvalue Inner Join
      hec_cas_cases
        On hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID = hec_cas_cases.HEC_CAS_CaseID And
        hec_cas_cases.Tenant_RefID = @TenantID And
        hec_cas_cases.IsDeleted = 0 Inner Join
      hec_patient_medicalpractices
        On hec_cas_cases.Patient_RefID = hec_patient_medicalpractices.HEC_Patient_RefID And
  	    hec_patient_medicalpractices.HEC_MedicalPractices_RefID = @PracticeID And
        hec_patient_medicalpractices.Tenant_RefID = @TenantID And
        hec_patient_medicalpractices.IsDeleted = 0
    Where
      hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID = @CaseUniversalPropertyID And
      hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID And
      hec_cas_case_universalpropertyvalue.IsDeleted = 0
	