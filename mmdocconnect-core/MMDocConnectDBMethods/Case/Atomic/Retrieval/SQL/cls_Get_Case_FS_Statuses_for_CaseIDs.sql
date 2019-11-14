
    SELECT
      bil_billposition_transmitionstatuses.TransmitionCode AS fs_status,
      bil_billposition_transmitionstatuses.TransmitionStatusKey AS fs_key,
      hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID AS gpos_type,
      bil_billposition_transmitionstatuses.Creation_Timestamp AS status_date,
      bil_billposition_transmitionstatuses.IsActive AS is_status_active,
      hec_bil_billpositions.Ext_BIL_BillPosition_RefID AS bill_position_id,
      bil_billposition_transmitionstatuses.IsTransmitionStatusManuallySet AS is_status_manually_set,
      bil_billposition_transmitionstatuses.PrimaryComment AS primary_comment,
      bil_billposition_transmitionstatuses.SecondaryComment AS secondary_comment,
      bil_billposition_transmitionstatuses.TransmissionDataXML AS immutable_data,
      hec_cas_case_billcodes.HEC_CAS_Case_RefID AS case_id,
      hec_bil_billpositions.Creation_Timestamp AS bill_position_creation_date,
      hec_cas_cases.Patient_RefID AS patient_id
    FROM
      hec_cas_case_billcodes
      INNER JOIN hec_bil_billposition_billcodes ON hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
        hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID AND hec_bil_billposition_billcodes.Tenant_RefID =
        @TenantID AND hec_bil_billposition_billcodes.IsDeleted = 0
      INNER JOIN hec_bil_billpositions ON hec_bil_billposition_billcodes.BillPosition_RefID =
        hec_bil_billpositions.HEC_BIL_BillPositionID AND hec_bil_billpositions.Tenant_RefID = @TenantID AND
        hec_bil_billpositions.IsDeleted = 0
      INNER JOIN bil_billposition_transmitionstatuses ON hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
        bil_billposition_transmitionstatuses.BillPosition_RefID AND bil_billposition_transmitionstatuses.Tenant_RefID =
        @TenantID AND bil_billposition_transmitionstatuses.IsDeleted = 0
      INNER JOIN hec_bil_potentialcodes ON hec_bil_billposition_billcodes.PotentialCode_RefID =
        hec_bil_potentialcodes.HEC_BIL_PotentialCodeID AND hec_bil_potentialcodes.Tenant_RefID = @TenantID AND
        hec_bil_potentialcodes.IsDeleted = 0
      INNER JOIN hec_bil_potentialcode_catalogs ON hec_bil_potentialcodes.PotentialCode_Catalog_RefID =
        hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID AND hec_bil_potentialcode_catalogs.IsDeleted = 0 AND
        hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID
      INNER JOIN hec_cas_cases ON hec_cas_case_billcodes.HEC_CAS_Case_RefID = hec_cas_cases.HEC_CAS_CaseID AND
        hec_cas_cases.Tenant_RefID = @TenantID
    WHERE
      hec_cas_cases.Patient_RefID = @PatientIDs AND
      hec_cas_case_billcodes.Tenant_RefID = @TenantID AND
      hec_cas_case_billcodes.IsDeleted = 0
    ORDER BY
      status_date DESC
	