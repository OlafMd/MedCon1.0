
Select
  bil_billposition_transmitionstatuses.IsActive,
  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID As StatusID,
  bil_billposition_transmitionstatuses.TransmitionCode As StatusCode,
  bil_billposition_transmitionstatuses.PrimaryComment As StatusComment,
  bil_billposition_transmitionstatuses.TransmittedOnDate As StatusDate,
  bil_billpositions.PositionNumber
From
  hec_cas_case_billcodes
  Inner Join hec_bil_billposition_billcodes On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID 
  Inner Join hec_bil_potentialcodes On hec_bil_billposition_billcodes.PotentialCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID  And
    hec_bil_potentialcodes.Tenant_RefID = @TenantID 
  Inner Join hec_bil_billpositions On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID
    And hec_bil_billpositions.Tenant_RefID = @TenantID
  Inner Join bil_billposition_transmitionstatuses On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID 
  Inner Join bil_billpositions On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billpositions.BIL_BillPositionID And
    bil_billpositions.Tenant_RefID = @TenantID 
Where
  hec_bil_potentialcodes.BillingCode = '36620062' And
  bil_billposition_transmitionstatuses.TransmitionStatusKey = 'aftercare' And
  hec_cas_case_billcodes.HEC_CAS_Case_RefID = @CaseID And
  hec_cas_case_billcodes.Tenant_RefID = @TenantID
	