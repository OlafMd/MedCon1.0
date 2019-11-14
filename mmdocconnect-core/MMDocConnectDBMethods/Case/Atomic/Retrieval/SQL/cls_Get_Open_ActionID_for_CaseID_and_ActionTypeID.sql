
    SELECT
      hec_cas_case_relevantplannedactions.PlannedAction_RefID AS ActionID
    FROM
      hec_cas_case_relevantplannedactions
      INNER JOIN hec_act_plannedactions ON hec_cas_case_relevantplannedactions.PlannedAction_RefID =
        hec_act_plannedactions.HEC_ACT_PlannedActionID AND hec_act_plannedactions.IsPerformed = 0 AND
        hec_act_plannedactions.IsCancelled = 0
      INNER JOIN hec_act_plannedaction_2_actiontype ON hec_act_plannedactions.HEC_ACT_PlannedActionID =
        hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID AND
        hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @ActionTypeID AND
        hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID AND hec_act_plannedaction_2_actiontype.IsDeleted = 0
    WHERE
      hec_cas_case_relevantplannedactions.Case_RefID = @CaseID AND
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID AND
      hec_cas_case_relevantplannedactions.IsDeleted = 0
	