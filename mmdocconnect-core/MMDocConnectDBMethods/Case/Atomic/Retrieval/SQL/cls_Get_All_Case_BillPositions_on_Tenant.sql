
Select
  hec_bil_billposition_billcodes.BillPosition_RefID As BillPositionID,
  hec_cas_case_billcodes.HEC_CAS_Case_RefID As CaseID,
  bil_billposition_transmitionstatuses.TransmitionStatusKey As PositionType,
  hec_bil_billposition_billcodes.PotentialCode_RefID As GposID,
  hec_cas_case_billcodes.IsDeleted,
  hec_cas_cases.Patient_RefID As PatientID,
  hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID As GposType
From
  hec_cas_case_billcodes Inner Join
  hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
    hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID Inner Join
  hec_bil_potentialcodes
    On hec_bil_billposition_billcodes.PotentialCode_RefID =
    hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And
    hec_bil_potentialcodes.Tenant_RefID = @TenantID And
    hec_bil_potentialcodes.IsDeleted = 0 Inner Join
  hec_bil_potentialcode_catalogs
    On hec_bil_potentialcodes.PotentialCode_Catalog_RefID =
    hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
    hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID And
    hec_bil_potentialcode_catalogs.IsDeleted = 0 Inner Join
  hec_bil_billpositions
    On hec_bil_billposition_billcodes.BillPosition_RefID =
    hec_bil_billpositions.HEC_BIL_BillPositionID And
    hec_bil_billpositions.Tenant_RefID = @TenantID Inner Join
  hec_cas_cases
    On hec_cas_case_billcodes.HEC_CAS_Case_RefID = hec_cas_cases.HEC_CAS_CaseID
    And
    hec_cas_cases.Tenant_RefID = @TenantID Left Join
  bil_billposition_transmitionstatuses
    On hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
    bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.IsActive = 1 And
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
    bil_billposition_transmitionstatuses.IsDeleted = 0
Where
  hec_cas_case_billcodes.Tenant_RefID = @TenantID
Group By
  hec_bil_billposition_billcodes.BillPosition_RefID
Order By
  hec_cas_case_billcodes.Creation_Timestamp
	