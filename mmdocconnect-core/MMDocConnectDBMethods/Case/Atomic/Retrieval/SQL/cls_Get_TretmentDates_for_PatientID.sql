      
SELECT
  hec_act_plannedactions.PlannedFor_Date AS treatment_date,
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code AS localization,
  hec_cas_case_relevantperformedactions.Case_RefID AS case_id,
  bil_billposition_transmitionstatuses.TransmitionCode AS transmition_code,
  bil_billposition_transmitionstatuses.TransmitionStatusKey AS transmition_status_key
FROM
  hec_act_plannedactions
  INNER JOIN hec_cas_case_relevantperformedactions ON hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID =
    hec_cas_case_relevantperformedactions.PerformedAction_RefID AND hec_cas_case_relevantperformedactions.Tenant_RefID =
    @TenantID AND hec_cas_case_relevantperformedactions.IsDeleted = 0 AND
    hec_cas_case_relevantperformedactions.Case_RefID = @CaseIDs
  INNER JOIN hec_act_performedaction_diagnosisupdates ON hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID AND
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID AND
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0
  INNER JOIN hec_act_performedaction_diagnosisupdate_localizations
    ON hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
    hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID AND
    hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID AND
    hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
  INNER JOIN hec_cas_case_billcodes ON hec_cas_case_relevantperformedactions.Case_RefID =
    hec_cas_case_billcodes.HEC_CAS_Case_RefID AND hec_cas_case_billcodes.IsDeleted = 0 AND
    hec_cas_case_billcodes.Tenant_RefID = @TenantID
  INNER JOIN hec_bil_billposition_billcodes ON hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
    hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID AND hec_bil_billposition_billcodes.Tenant_RefID =
    @TenantID AND hec_bil_billposition_billcodes.IsDeleted = 0
  INNER JOIN hec_bil_potentialcodes ON hec_bil_billposition_billcodes.PotentialCode_RefID =
    hec_bil_potentialcodes.HEC_BIL_PotentialCodeID AND hec_bil_potentialcodes.Tenant_RefID = @TenantID AND
    hec_bil_potentialcodes.IsDeleted = 0
  INNER JOIN hec_bil_potentialcode_catalogs ON hec_bil_potentialcodes.PotentialCode_Catalog_RefID =
    hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID AND
    hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID LIKE '%operation%' AND
    hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID AND hec_bil_potentialcode_catalogs.IsDeleted = 0
  INNER JOIN hec_bil_billpositions ON hec_bil_billposition_billcodes.BillPosition_RefID =
    hec_bil_billpositions.HEC_BIL_BillPositionID AND hec_bil_billpositions.Tenant_RefID = @TenantID AND
    hec_bil_billpositions.IsDeleted = 0
  LEFT JOIN bil_billposition_transmitionstatuses ON hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
    bil_billposition_transmitionstatuses.BillPosition_RefID AND bil_billposition_transmitionstatuses.Tenant_RefID =
    @TenantID AND bil_billposition_transmitionstatuses.IsDeleted = 0 AND bil_billposition_transmitionstatuses.IsActive =
    1
WHERE
  hec_act_plannedactions.Patient_RefID = @PatientID AND
  hec_act_plannedactions.IsCancelled = 0 AND
  hec_act_plannedactions.Tenant_RefID = @TenantID AND
  hec_act_plannedactions.IsDeleted = 0
	