
Select
  hec_cas_case_billcodes.HEC_CAS_Case_BillCodeID As hec_case_bill_code_id
From
  hec_cas_case_billcodes Inner Join
  hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
    hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID =
    @TenantID And
    hec_bil_billposition_billcodes.IsDeleted = 0 Inner Join
  hec_bil_potentialcodes On hec_bil_billposition_billcodes.PotentialCode_RefID =
    hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And
    hec_bil_potentialcodes.Tenant_RefID = @TenantID
    And hec_bil_potentialcodes.IsDeleted = 0 And
    hec_bil_potentialcodes.BillingCode = @BillingCode
Where
  hec_cas_case_billcodes.Tenant_RefID = @TenantID And
  hec_cas_case_billcodes.IsDeleted = 0 And
  hec_cas_case_billcodes.HEC_CAS_Case_RefID = @CaseID
	