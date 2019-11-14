
Select
  hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID,
  hec_cas_case_billcodes.HEC_CAS_Case_BillCodeID,
  hec_bil_billpositions.HEC_BIL_BillPositionID,
  bil_billpositions.BIL_BillPositionID,
  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID
From
  hec_cas_case_billcodes
  Inner Join hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
    hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And
    hec_bil_billposition_billcodes.IsDeleted = 0 
  Inner Join hec_bil_billpositions
    On hec_bil_billposition_billcodes.BillPosition_RefID =
    hec_bil_billpositions.HEC_BIL_BillPositionID And
    hec_bil_billpositions.Tenant_RefID= @TenantID And
    hec_bil_billpositions.IsDeleted = 0
  Inner Join bil_billpositions
    On hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
    bil_billpositions.BIL_BillPositionID And
    bil_billpositions.Tenant_RefID = @TenantID And
    bil_billpositions.IsDeleted = 0
  Inner Join bil_billposition_transmitionstatuses
    On bil_billpositions.BIL_BillPositionID =
    bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.IsDeleted = 0 And
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
    bil_billposition_transmitionstatuses.IsActive = 1
Where
  bil_billposition_transmitionstatuses.TransmitionStatusKey = 'aftercare' And
  hec_cas_case_billcodes.HEC_CAS_Case_RefID = @CaseID And
  hec_cas_case_billcodes.IsDeleted = 0 And
  hec_cas_case_billcodes.Tenant_RefID = @TenantID 
	