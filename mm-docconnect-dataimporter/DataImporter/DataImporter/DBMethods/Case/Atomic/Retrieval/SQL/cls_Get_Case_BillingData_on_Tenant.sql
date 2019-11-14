
SELECT
  hec_cas_cases.HEC_CAS_CaseID AS case_id,
  hec_cas_cases.CaseNumber AS case_number,
  bil_billpositions.BIL_BillPositionID AS bill_position_id,
  hec_bil_billposition_billcodes.PotentialCode_RefID AS gpos_id,
  bil_billposition_transmitionstatuses.TransmitionStatusKey AS fs_status_key,
  bil_billposition_transmitionstatuses.TransmitionCode AS fs_status_code,
  bil_billpositions.PositionNumber AS bill_position_number,
  hec_bil_potentialcodes.BillingCode AS gpos_code,
  bil_billpositions.PositionValue_IncludingTax AS gpos_price,
  hec_bil_billpositions.HEC_BIL_BillPositionID AS hec_bill_position_id,
  hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID AS gpos_type,
  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID AS fs_status_id,
  hec_cas_cases.Patient_RefID AS patient_id,
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code as localization
FROM
  hec_cas_cases
  INNER JOIN hec_cas_case_billcodes ON hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_billcodes.HEC_CAS_Case_RefID AND
    hec_cas_case_billcodes.Tenant_RefID = @TenantID AND hec_cas_case_billcodes.IsDeleted = 0
  INNER JOIN hec_bil_billposition_billcodes ON hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
    hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID AND hec_bil_billposition_billcodes.Tenant_RefID =
    @TenantID AND hec_bil_billposition_billcodes.IsDeleted = 0
  INNER JOIN hec_bil_billpositions ON hec_bil_billposition_billcodes.BillPosition_RefID =
    hec_bil_billpositions.HEC_BIL_BillPositionID AND hec_bil_billpositions.Tenant_RefID = @TenantID AND
    hec_bil_billpositions.IsDeleted = 0
  INNER JOIN bil_billpositions ON hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
    bil_billpositions.BIL_BillPositionID AND bil_billpositions.Tenant_RefID = @TenantID AND
    bil_billpositions.IsDeleted = 0
  LEFT JOIN bil_billposition_transmitionstatuses ON bil_billpositions.BIL_BillPositionID =
    bil_billposition_transmitionstatuses.BillPosition_RefID AND bil_billposition_transmitionstatuses.IsActive = 1 AND
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID AND bil_billposition_transmitionstatuses.IsDeleted = 0
  INNER JOIN hec_bil_potentialcodes ON hec_bil_billposition_billcodes.PotentialCode_RefID =
    hec_bil_potentialcodes.HEC_BIL_PotentialCodeID AND hec_bil_potentialcodes.Tenant_RefID = @TenantID AND
    hec_bil_potentialcodes.IsDeleted = 0
  INNER JOIN hec_bil_potentialcode_catalogs ON hec_bil_potentialcodes.PotentialCode_Catalog_RefID =
    hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID AND
    hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID = 'mm.docconnect.gpos.catalog.voruntersuchung' AND
    hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID AND hec_bil_potentialcode_catalogs.IsDeleted = 0
  INNER JOIN hec_cas_case_relevantperformedactions
    ON hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID AND
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID AND hec_cas_case_relevantperformedactions.IsDeleted = 0
  INNER JOIN hec_act_performedaction_diagnosisupdates ON hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID AND
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID AND
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0
  INNER JOIN hec_act_performedaction_diagnosisupdate_localizations
    ON hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
    hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID AND
    hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID AND
    hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
WHERE
  hec_cas_cases.Tenant_RefID = @TenantID AND
  hec_cas_cases.IsDeleted = 0
	