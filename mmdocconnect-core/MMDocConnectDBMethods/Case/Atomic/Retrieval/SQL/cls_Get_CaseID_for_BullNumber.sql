
Select
  hec_cas_case_billcodes.HEC_CAS_Case_RefID
From
  hec_bil_billpositions Inner Join
  hec_bil_billposition_billcodes
    On hec_bil_billposition_billcodes.BillPosition_RefID =
    hec_bil_billpositions.HEC_BIL_BillPositionID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And
    hec_bil_billposition_billcodes.IsDeleted = 0 Inner Join
  hec_cas_case_billcodes
    On hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID =
    hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID And
    hec_cas_case_billcodes.Tenant_RefID = @TenantID And
    hec_cas_case_billcodes.IsDeleted = 0
Where
  hec_bil_billpositions.Ext_BIL_BillPosition_RefID = @BillPositionID And
  hec_bil_billpositions.Tenant_RefID = @TenantID And
  hec_bil_billpositions.IsDeleted = 0
	