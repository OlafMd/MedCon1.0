
Select
  bil_billposition_transmitionstatuses.TransmitionCode,
  hec_cas_case_billcodes.HEC_CAS_Case_RefID As CaseID
From
  hec_cas_case_billcodes Inner Join
  hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
    hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And
    hec_bil_billposition_billcodes.IsDeleted = 0 Inner Join
  hec_bil_billpositions
    On hec_bil_billposition_billcodes.BillPosition_RefID =
    hec_bil_billpositions.HEC_BIL_BillPositionID And
    hec_bil_billpositions.Tenant_RefID = @TenantID And
    hec_bil_billpositions.IsDeleted = 0 Inner Join
  bil_billposition_transmitionstatuses
    On hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
    bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.IsActive = 1 And
    bil_billposition_transmitionstatuses.TransmitionStatusKey = @StatusKey And
    bil_billposition_transmitionstatuses.IsDeleted = 0 And
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID
Where
  hec_cas_case_billcodes.HEC_CAS_Case_RefID = @CaseIDs And
  hec_cas_case_billcodes.Tenant_RefID = @TenantID And
  hec_cas_case_billcodes.IsDeleted = 0
Order By
  hec_cas_case_billcodes.Creation_Timestamp
	