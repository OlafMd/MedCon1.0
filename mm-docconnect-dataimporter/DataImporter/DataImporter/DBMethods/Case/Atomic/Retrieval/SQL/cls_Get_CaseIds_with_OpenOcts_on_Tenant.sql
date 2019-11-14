
SELECT
  hec_cas_cases.HEC_CAS_CaseID
FROM
  hec_cas_cases
  INNER JOIN hec_cas_case_relevantplannedactions
    ON hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantplannedactions.Case_RefID
  INNER JOIN hec_act_plannedactions ON hec_cas_case_relevantplannedactions.PlannedAction_RefID =
    hec_act_plannedactions.HEC_ACT_PlannedActionID
  INNER JOIN hec_act_plannedaction_2_actiontype ON hec_act_plannedactions.HEC_ACT_PlannedActionID =
    hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID
  INNER JOIN hec_act_actiontype ON hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID =
    hec_act_actiontype.HEC_ACT_ActionTypeID
WHERE
  hec_act_actiontype.GlobalPropertyMatchingID LIKE '%oct%' AND
  hec_cas_cases.Tenant_RefID = @TenantID AND
  hec_cas_cases.IsDeleted = 0 AND
  hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID AND
  hec_cas_case_relevantplannedactions.IsDeleted = 0 AND
  hec_act_plannedactions.IsPerformed = 0 AND
  hec_act_plannedactions.IsCancelled = 0 AND
  hec_act_plannedactions.Tenant_RefID = @TenantID AND
  hec_act_plannedactions.IsDeleted = 0 AND
  hec_act_actiontype.Tenant_RefID = @TenantID AND
  hec_act_actiontype.IsDeleted = 0
	