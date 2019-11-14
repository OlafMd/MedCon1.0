
Select
  Right(hec_cas_case_universalpropertyvalue.Value_String, 5) As CaseOrderNumber
From
  hec_cas_case_universalproperties Inner Join
  hec_cas_case_universalpropertyvalue
    On hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID And
    hec_cas_case_universalpropertyvalue.IsDeleted = 0 And
    hec_cas_case_universalpropertyvalue.Value_String Like @PracticeBSNR And
    hec_cas_case_universalproperties.HEC_CAS_Case_UniversalPropertyID =
    hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID
Where
  hec_cas_case_universalproperties.GlobalPropertyMatchingID =
  'mm.doc.connect.case.order.number' And
  hec_cas_case_universalproperties.Tenant_RefID = @TenantID And
  hec_cas_case_universalproperties.IsDeleted = 0
Order by
	CaseOrderNumber Desc
Limit 1
	