
    Select
      hec_cas_case_universalpropertyvalue.Value_String,
      hec_cas_case_universalpropertyvalue.Value_Boolean,
      hec_cas_case_universalpropertyvalue.Value_Number,
      hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalPropertyValueID As ID,
      hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID As CaseID,
      hec_cas_cases.Patient_RefID as PatientID
    From
      hec_cas_case_universalpropertyvalue Inner Join
      hec_cas_case_universalproperties
        On hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID = hec_cas_case_universalproperties.HEC_CAS_Case_UniversalPropertyID And
        hec_cas_case_universalproperties.GlobalPropertyMatchingID = @PropertyGpmID And hec_cas_case_universalproperties.Tenant_RefID = @TenantID And
        hec_cas_case_universalproperties.IsDeleted = 0 Inner Join
      hec_cas_cases
        On hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID = hec_cas_cases.HEC_CAS_CaseID And
        hec_cas_cases.Tenant_RefID = @TenantID 
    Where
      hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID And
      hec_cas_case_universalpropertyvalue.IsDeleted = 0
	