
SELECT
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code AS localization,
  hec_cas_cases.Patient_RefID AS patient_id,
  bil_billposition_transmitionstatuses.TransmitionCode AS fs_status_code,
  hec_act_plannedactions.PlannedFor_Date AS op_date,
  hec_cas_case_billcodes.HEC_CAS_Case_RefID AS case_id
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
  INNER JOIN bil_billposition_transmitionstatuses ON hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
    bil_billposition_transmitionstatuses.BillPosition_RefID AND
    bil_billposition_transmitionstatuses.TransmitionStatusKey = 'oct' AND
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID AND bil_billposition_transmitionstatuses.IsDeleted = 0
  INNER JOIN hec_cas_case_relevantperformedactions
    ON hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID AND
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID AND hec_cas_case_relevantperformedactions.IsDeleted =
    0
  INNER JOIN hec_act_performedaction_diagnosisupdates ON hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID AND
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID AND
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0
  INNER JOIN hec_act_performedaction_diagnosisupdate_localizations
    ON hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
    hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID AND
    hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID AND
    hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
  INNER JOIN hec_act_plannedactions ON hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID =
    hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID AND hec_act_plannedactions.Tenant_RefID = @TenantID
    AND hec_act_plannedactions.IsDeleted = 0
WHERE
  hec_cas_cases.Tenant_RefID = @TenantID AND
  hec_cas_cases.IsDeleted = 0
ORDER BY
  hec_cas_case_billcodes.Creation_Timestamp DESC
	