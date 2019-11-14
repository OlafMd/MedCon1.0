
SELECT
  hec_act_plannedactions.IsPerformed,
  hec_cas_case_relevantplannedactions.Case_RefID,
  hec_act_plannedactions.HEC_ACT_PlannedActionID,
  hec_cas_case_relevantplannedactions.HEC_CAS_Case_RelevantPlannedActionID,
  hec_act_performedactions.Creation_Timestamp,
  hec_act_performedactions.IfPerfomed_DateOfAction
FROM
  hec_cas_case_relevantplannedactions
  INNER JOIN hec_act_plannedactions ON hec_cas_case_relevantplannedactions.PlannedAction_RefID =
    hec_act_plannedactions.HEC_ACT_PlannedActionID AND
    hec_act_plannedactions.IsCancelled = 0 AND
    hec_act_plannedactions.Tenant_RefID = @TenantID AND
    hec_act_plannedactions.IsDeleted = 0
  INNER JOIN hec_act_plannedaction_2_actiontype ON hec_act_plannedactions.HEC_ACT_PlannedActionID =
    hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID
  INNER JOIN hec_act_actiontype ON hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID =
    hec_act_actiontype.HEC_ACT_ActionTypeID AND
    hec_act_actiontype.GlobalPropertyMatchingID LIKE '%aftercare%' AND
    hec_act_actiontype.Tenant_RefID = @TenantID AND
    hec_act_actiontype.IsDeleted = FALSE
  LEFT JOIN hec_act_performedactions ON hec_act_plannedactions.IfPerformed_PerformedAction_RefID =
    hec_act_performedactions.HEC_ACT_PerformedActionID AND
    hec_act_performedactions.Tenant_RefID = @TenantID AND
    hec_act_performedactions.IsDeleted = 0
WHERE
  hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID AND
  (hec_cas_case_relevantplannedactions.IsDeleted = 0 OR
    hec_cas_case_relevantplannedactions.IsDeleted = @IncludeDeleted)
	