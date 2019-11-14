
(SELECT
  hec_act_performedactions.IfPerfomed_DateOfAction AS TreatmentDate,
  hec_act_performedactions.Patient_RefID AS PatientID,
  0 AS IsOp,
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code AS Localization,
  0 AS IsOpPerformed,
  hec_cas_case_relevantplannedactions.Case_RefID AS CaseID,
  hec_act_plannedactions.HEC_ACT_PlannedActionID as ActionID
FROM
  hec_act_performedactions
  INNER JOIN hec_act_performedaction_diagnosisupdates ON hec_act_performedactions.HEC_ACT_PerformedActionID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID AND
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID AND
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0
  INNER JOIN hec_act_performedaction_diagnosisupdate_localizations
    ON hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
    hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID AND
    hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID AND
    hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
  INNER JOIN hec_act_performedaction_2_actiontype ON hec_act_performedactions.HEC_ACT_PerformedActionID =
    hec_act_performedaction_2_actiontype.HEC_ACT_PerformedAction_RefID AND
    hec_act_performedaction_2_actiontype.Tenant_RefID = @TenantID AND hec_act_performedaction_2_actiontype.IsDeleted = 0
  INNER JOIN hec_act_actiontype ON hec_act_performedaction_2_actiontype.HEC_ACT_ActionType_RefID =
    hec_act_actiontype.HEC_ACT_ActionTypeID AND hec_act_actiontype.GlobalPropertyMatchingID =
    'mm.docconect.doc.app.performed.action.oct' AND hec_act_actiontype.Tenant_RefID = @TenantID AND
    hec_act_actiontype.IsDeleted = 0
  INNER JOIN hec_act_plannedactions ON hec_act_plannedactions.IfPerformed_PerformedAction_RefID =
    hec_act_performedactions.HEC_ACT_PerformedActionID AND hec_act_plannedactions.Tenant_RefID = @TenantID AND
    hec_act_plannedactions.IsDeleted = 0
  INNER JOIN hec_cas_case_relevantplannedactions ON hec_cas_case_relevantplannedactions.PlannedAction_RefID =
    hec_act_plannedactions.HEC_ACT_PlannedActionID AND hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID AND
    hec_cas_case_relevantplannedactions.IsDeleted = 0
WHERE
  hec_act_performedactions.Tenant_RefID = @TenantID AND
  hec_act_performedactions.IsDeleted = 0)
UNION ALL
(SELECT
  hec_act_plannedactions.PlannedFor_Date AS TreatmentDate,
  hec_act_plannedactions.Patient_RefID AS PatientID,
  1 AS IsOp,
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code AS Localization,
  hec_act_plannedactions.IsPerformed AS IsOpPerformed,
  hec_cas_case_relevantperformedactions.Case_RefID AS CaseID,
  hec_act_plannedactions.HEC_ACT_PlannedActionID As ActionID
FROM
  hec_cas_case_relevantperformedactions
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
  hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID AND
  hec_cas_case_relevantperformedactions.IsDeleted = 0)
ORDER BY
  TreatmentDate
	