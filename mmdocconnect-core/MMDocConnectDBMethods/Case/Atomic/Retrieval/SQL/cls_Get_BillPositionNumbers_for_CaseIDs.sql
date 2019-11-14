
    SELECT
      bil_billpositions.PositionNumber AS BillPositionNumber,
      bil_billpositions.Creation_Timestamp AS BillPositionCreationDate,
      hec_cas_case_billcodes.HEC_CAS_Case_RefID AS CaseID,
      bil_billposition_transmitionstatuses.TransmitionStatusKey AS PositionType,
      bil_billposition_transmitionstatuses.TransmittedOnDate,
      hec_cas_cases.Patient_RefID AS PatientID
    FROM
      hec_cas_case_billcodes
      INNER JOIN hec_bil_billposition_billcodes ON hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
        hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID AND hec_bil_billposition_billcodes.Tenant_RefID =
        @TenantID AND hec_bil_billposition_billcodes.IsDeleted = 0
      INNER JOIN hec_bil_billpositions ON hec_bil_billposition_billcodes.BillPosition_RefID =
        hec_bil_billpositions.HEC_BIL_BillPositionID AND hec_bil_billpositions.Tenant_RefID = @TenantID AND
        hec_bil_billpositions.IsDeleted = 0
      INNER JOIN bil_billpositions ON hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
        bil_billpositions.BIL_BillPositionID AND bil_billpositions.Tenant_RefID = @TenantID AND
        bil_billpositions.IsDeleted = 0
      INNER JOIN bil_billposition_transmitionstatuses ON bil_billpositions.BIL_BillPositionID =
        bil_billposition_transmitionstatuses.BillPosition_RefID AND bil_billposition_transmitionstatuses.IsActive = 1 AND
        bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID AND bil_billposition_transmitionstatuses.IsDeleted = 0
      INNER JOIN hec_cas_cases ON hec_cas_case_billcodes.HEC_CAS_Case_RefID = hec_cas_cases.HEC_CAS_CaseID AND
        hec_cas_cases.Tenant_RefID = @TenantID
    WHERE
      hec_cas_cases.Patient_RefID = @PatientIDs AND
      hec_cas_case_billcodes.Tenant_RefID = @TenantID AND
      hec_cas_case_billcodes.IsDeleted = 0
    ORDER BY
      bil_billposition_transmitionstatuses.TransmittedOnDate DESC
	