
    SELECT
      hec_cas_case_billcodes.HEC_CAS_Case_RefID
    FROM
      hec_cas_case_billcodes
      INNER JOIN hec_bil_billposition_billcodes ON hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
        hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID AND
        hec_bil_billposition_billcodes.Tenant_RefID = @TenantID AND
        hec_bil_billposition_billcodes.IsDeleted = 0
      INNER JOIN hec_bil_billpositions ON hec_bil_billposition_billcodes.BillPosition_RefID =
        hec_bil_billpositions.HEC_BIL_BillPositionID AND
        hec_bil_billpositions.Tenant_RefID = @TenantID AND
        hec_bil_billpositions.IsDeleted = 0
      INNER JOIN bil_billposition_transmitionstatuses ON hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
        bil_billposition_transmitionstatuses.BillPosition_RefID AND
        bil_billposition_transmitionstatuses.TransmitionStatusKey = 'treatment' AND
        bil_billposition_transmitionstatuses.TransmitionCode NOT IN (8, 11, 17) AND
        bil_billposition_transmitionstatuses.IsActive = 1 AND
        bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID AND
        bil_billposition_transmitionstatuses.IsDeleted = 0
    WHERE
      hec_cas_case_billcodes.Tenant_RefID = @TenantID AND
      hec_cas_case_billcodes.IsDeleted = 0
	