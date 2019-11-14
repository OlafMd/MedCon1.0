
Select
  bil_billheaders.BIL_BillHeaderID as header_id
From
  hec_cas_case_billcodes Inner Join
  hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
    hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And
    hec_bil_billposition_billcodes.IsDeleted = 0
     Inner Join
  hec_bil_billpositions On hec_bil_billposition_billcodes.BillPosition_RefID =
    hec_bil_billpositions.HEC_BIL_BillPositionID And
    hec_bil_billpositions.Tenant_RefID = @TenantID And
    hec_bil_billpositions.IsDeleted = 0
     Inner Join
  bil_billpositions On hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
    bil_billpositions.BIL_BillPositionID And
    bil_billpositions.Tenant_RefID = @TenantID And
    bil_billpositions.IsDeleted = 0
    Inner Join
  bil_billheaders On bil_billpositions.BIL_BilHeader_RefID =
    bil_billheaders.BIL_BillHeaderID And
    bil_billheaders.Tenant_RefID = @TenantID And
    bil_billheaders.IsDeleted =0
Where
  hec_cas_case_billcodes.HEC_CAS_Case_RefID = @CaseID And
  hec_cas_case_billcodes.IsDeleted = 0 And
  hec_cas_case_billcodes.Tenant_RefID = @TenantID
Group By
  hec_cas_case_billcodes.HEC_CAS_Case_RefID
	