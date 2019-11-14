
Select
  hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID As CaseID,
  hec_cas_case_universalpropertyvalue.Value_String As ReportDownloadedForTypes
From
  hec_cas_case_universalproperties
  Inner Join hec_cas_case_universalpropertyvalue
    On hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID = hec_cas_case_universalproperties.HEC_CAS_Case_UniversalPropertyID And
      hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID And hec_cas_case_universalpropertyvalue.IsDeleted = 0
Where
  hec_cas_case_universalproperties.GlobalPropertyMatchingID = 'mm.docconnect.case.report.downloaded' And
  hec_cas_case_universalproperties.IsValue_String = 1 And
  hec_cas_case_universalproperties.Tenant_RefID = @TenantID And
  hec_cas_case_universalproperties.IsDeleted = 0
	