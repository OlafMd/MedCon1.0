
Select
  hec_cas_cases.HEC_CAS_CaseID As case_id,
  hec_cas_cases.CaseNumber As case_number,
  bil_billpositions.BIL_BillPositionID As bill_position_id,
  hec_bil_billposition_billcodes.PotentialCode_RefID As gpos_id,
  bil_billposition_transmitionstatuses.TransmitionStatusKey As fs_status_key,
  bil_billposition_transmitionstatuses.TransmitionCode As fs_status_code,
  bil_billpositions.PositionNumber As bill_position_number,
  hec_bil_potentialcodes.BillingCode As gpos_code,
  bil_billpositions.PositionValue_IncludingTax As gpos_price,
  hec_bil_billpositions.HEC_BIL_BillPositionID as hec_bill_position_id,
  hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID as gpos_type,
  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID as fs_status_id
From
  hec_cas_cases Inner Join
  hec_cas_case_billcodes
    On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_billcodes.HEC_CAS_Case_RefID And hec_cas_case_billcodes.Tenant_RefID = @TenantID And
    hec_cas_case_billcodes.IsDeleted = 0 Inner Join
  hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And hec_bil_billposition_billcodes.IsDeleted = 0 Inner Join
  hec_bil_billpositions
    On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And hec_bil_billpositions.Tenant_RefID = @TenantID And
    hec_bil_billpositions.IsDeleted = 0 Inner Join
  bil_billpositions
    On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billpositions.BIL_BillPositionID And bil_billpositions.Tenant_RefID = @TenantID And
    bil_billpositions.IsDeleted = 0 Left Join
  bil_billposition_transmitionstatuses
    On bil_billpositions.BIL_BillPositionID = bil_billposition_transmitionstatuses.BillPosition_RefID And bil_billposition_transmitionstatuses.IsActive = 1 And
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And bil_billposition_transmitionstatuses.IsDeleted = 0 Inner Join
  hec_bil_potentialcodes
    On hec_bil_billposition_billcodes.PotentialCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And hec_bil_potentialcodes.Tenant_RefID = @TenantID
    And hec_bil_potentialcodes.IsDeleted = 0 Inner Join
  hec_bil_potentialcode_catalogs
    On hec_bil_potentialcodes.PotentialCode_Catalog_RefID = hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
    hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID And
    hec_bil_potentialcode_catalogs.IsDeleted = 0
Where
  hec_cas_cases.Tenant_RefID = @TenantID And
  hec_cas_cases.IsDeleted = 0
Order By
  hec_cas_case_billcodes.Creation_Timestamp
	