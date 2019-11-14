
Select
  hec_cas_cases.HEC_CAS_CaseID,
  hec_cas_cases.CaseNumber
From
  hec_cas_cases Inner Join
  hec_cas_case_universalpropertyvalue
    On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID And hec_cas_case_universalpropertyvalue.Value_Boolean = 1
    And hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID And hec_cas_case_universalpropertyvalue.IsDeleted = 0 Inner Join
  hec_cas_case_universalproperties
    On hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID = hec_cas_case_universalproperties.HEC_CAS_Case_UniversalPropertyID And
    hec_cas_case_universalproperties.GlobalPropertyMatchingID = 'mm.doc.connect.case.is.for.documentation.only' And
    hec_cas_case_universalproperties.Tenant_RefID = @TenantID And hec_cas_case_universalproperties.IsDeleted = 0 Left Join
  hec_cas_case_billcodes
    On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_billcodes.HEC_CAS_Case_RefID
Where
  hec_cas_case_billcodes.HEC_CAS_Case_BillCodeID Is Null And
  hec_cas_cases.Tenant_RefID = @TenantID And
  hec_cas_cases.IsDeleted = 0
	