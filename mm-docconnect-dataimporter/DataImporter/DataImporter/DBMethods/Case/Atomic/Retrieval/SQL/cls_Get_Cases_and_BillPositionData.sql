
Select
  hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID As GposType,
  hec_cas_case_billcodes.IsDeleted As IsBillCodeDeleted,
  hec_cas_cases.HEC_CAS_CaseID As CaseID,
  bil_billposition_transmitionstatuses.TransmitionCode As FsStatusCode,
  bil_billposition_transmitionstatuses.TransmitionStatusKey As FsStatusType,
  hec_cas_cases.CaseNumber,
  hec_cas_case_billcodes.HEC_CAS_Case_BillCodeID,
  hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID,
  hec_bil_billpositions.HEC_BIL_BillPositionID,
  hec_bil_billpositions.Ext_BIL_BillPosition_RefID,
  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID,
  bil_billposition_transmitionstatuses.IsActive,
  hec_bil_billposition_billcodes.PotentialCode_RefID as GposID
From
  hec_cas_cases
  Inner Join hec_cas_case_billcodes On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_billcodes.HEC_CAS_Case_RefID
  Inner Join hec_bil_billposition_billcodes On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID
  Inner Join hec_bil_billpositions On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID
  Inner Join hec_bil_potentialcodes On hec_bil_billposition_billcodes.PotentialCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID
  Inner Join hec_bil_potentialcode_catalogs On hec_bil_potentialcodes.PotentialCode_Catalog_RefID = hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID
  Left Join bil_billposition_transmitionstatuses On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.IsActive = 1
Where
  hec_cas_cases.Tenant_RefID = @TenantID And
  hec_cas_cases.IsDeleted = 0
	