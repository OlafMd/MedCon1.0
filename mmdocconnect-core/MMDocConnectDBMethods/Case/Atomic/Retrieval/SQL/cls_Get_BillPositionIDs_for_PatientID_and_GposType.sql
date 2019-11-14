
SELECT
  hec_bil_billpositions.Ext_BIL_BillPosition_RefID AS bill_position_id,
  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID as status_id,
  bil_billposition_transmitionstatuses.PrimaryComment as comment,
  bil_billposition_transmitionstatuses.TransmitionCode as status_code
FROM
  hec_cas_case_billcodes
  INNER JOIN hec_bil_billposition_billcodes ON hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
    hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID AND hec_bil_billposition_billcodes.Tenant_RefID =
    @TenantID AND hec_bil_billposition_billcodes.IsDeleted = 0
  INNER JOIN hec_bil_billpositions ON hec_bil_billposition_billcodes.BillPosition_RefID =
    hec_bil_billpositions.HEC_BIL_BillPositionID AND hec_bil_billpositions.Tenant_RefID = @TenantID AND
    hec_bil_billpositions.IsDeleted = 0
  INNER JOIN hec_bil_potentialcodes ON hec_bil_billposition_billcodes.PotentialCode_RefID =
    hec_bil_potentialcodes.HEC_BIL_PotentialCodeID AND hec_bil_potentialcodes.Tenant_RefID = @TenantID AND
    hec_bil_potentialcodes.IsDeleted = 0
  INNER JOIN hec_bil_potentialcode_catalogs ON hec_bil_potentialcodes.PotentialCode_Catalog_RefID =
    hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID AND
    hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID = @GposType AND hec_bil_potentialcode_catalogs.Tenant_RefID
    = @TenantID AND hec_bil_potentialcode_catalogs.IsDeleted = 0
  INNER JOIN hec_cas_cases ON hec_cas_case_billcodes.HEC_CAS_Case_RefID = hec_cas_cases.HEC_CAS_CaseID AND
    hec_cas_cases.Tenant_RefID = @TenantID AND hec_cas_cases.IsDeleted = 0
  LEFT JOIN bil_billposition_transmitionstatuses ON hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
    bil_billposition_transmitionstatuses.BillPosition_RefID AND bil_billposition_transmitionstatuses.Tenant_RefID =
    @TenantID AND bil_billposition_transmitionstatuses.IsDeleted = 0 AND bil_billposition_transmitionstatuses.IsActive =
    1
WHERE
  hec_cas_cases.Patient_RefID = @PatientID AND
  hec_cas_case_billcodes.Tenant_RefID = @TenantID AND
  hec_cas_case_billcodes.IsDeleted = 0
ORDER BY
  hec_cas_case_billcodes.Creation_Timestamp
	