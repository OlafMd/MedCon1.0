
Select
  hec_bil_billposition_billcodes.PotentialCode_RefID As GposID,
  hec_cas_case_billcodes.HEC_CAS_Case_RefID As CaseID
From
  hec_cas_case_billcodes
  Inner Join hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID
Where
  hec_cas_case_billcodes.IsDeleted = 0 And
  hec_cas_case_billcodes.Tenant_RefID = @TenantID
	