
    SELECT
      hec_cas_cases.HEC_CAS_CaseID
    FROM
      hec_cas_cases
      INNER JOIN hec_cas_case_billcodes ON hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_billcodes.HEC_CAS_Case_RefID
      INNER JOIN hec_bil_billposition_billcodes ON hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
        hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID
      INNER JOIN hec_bil_billpositions ON hec_bil_billposition_billcodes.BillPosition_RefID =
        hec_bil_billpositions.HEC_BIL_BillPositionID
      INNER JOIN hec_bil_potentialcodes ON hec_bil_billposition_billcodes.PotentialCode_RefID =
        hec_bil_potentialcodes.HEC_BIL_PotentialCodeID
      INNER JOIN hec_bil_potentialcode_catalogs ON hec_bil_potentialcodes.PotentialCode_Catalog_RefID =
        hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID
      LEFT JOIN bil_billposition_transmitionstatuses ON hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
        bil_billposition_transmitionstatuses.BillPosition_RefID AND bil_billposition_transmitionstatuses.Tenant_RefID =
        @TenantID AND bil_billposition_transmitionstatuses.IsDeleted = 0
    WHERE
      hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID LIKE '%vor%' AND
      bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID IS NULL AND
      hec_cas_cases.Tenant_RefID = @TenantID AND
      hec_cas_cases.IsDeleted = 0 AND
      hec_bil_billposition_billcodes.Tenant_RefID = @TenantID AND
      hec_bil_billposition_billcodes.IsDeleted = 0 AND
      hec_bil_billpositions.Tenant_RefID = @TenantID AND
      hec_bil_billpositions.IsDeleted = 0 AND
      hec_bil_potentialcodes.Tenant_RefID = @TenantID AND
      hec_bil_potentialcodes.IsDeleted = 0 AND
      hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID AND
      hec_bil_potentialcode_catalogs.IsDeleted = 0
	