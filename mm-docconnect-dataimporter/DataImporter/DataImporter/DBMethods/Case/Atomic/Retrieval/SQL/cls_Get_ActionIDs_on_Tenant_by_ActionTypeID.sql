
    SELECT
      hec_cas_case_relevantplannedactions.PlannedAction_RefID AS ActionID
    FROM
      hec_cas_cases
      INNER JOIN hec_cas_case_relevantplannedactions
        ON hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantplannedactions.Case_RefID
      INNER JOIN hec_act_plannedaction_2_actiontype ON hec_cas_case_relevantplannedactions.PlannedAction_RefID =
        hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID
    WHERE
      hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @ActionTypeID AND
      hec_cas_cases.Tenant_RefID = @TenantID AND
      hec_cas_cases.IsDeleted = 0 AND
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID AND
      hec_cas_case_relevantplannedactions.IsDeleted = 0 AND
      hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID AND
      hec_act_plannedaction_2_actiontype.IsDeleted = 0
	