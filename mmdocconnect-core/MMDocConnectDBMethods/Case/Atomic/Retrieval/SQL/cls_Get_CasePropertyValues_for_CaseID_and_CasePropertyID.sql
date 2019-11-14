
    Select
      hec_cas_case_universalpropertyvalue.Value_String As ReportDownloadedFor,
      hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID As CaseID
    From
      hec_cas_case_universalpropertyvalue
    Where
      hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID = @CaseIDs And
      hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID And
      hec_cas_case_universalpropertyvalue.IsDeleted = 0 And
      hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID = @CasePropertyID
	