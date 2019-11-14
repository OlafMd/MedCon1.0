
    Select
      Count(hec_cas_case_relevantplannedactions.PlannedAction_RefID) As AftercareCount
    From
      hec_cas_case_relevantplannedactions Inner Join
      hec_cas_case_relevantperformedactions
        On hec_cas_case_relevantplannedactions.Case_RefID = hec_cas_case_relevantperformedactions.Case_RefID And hec_cas_case_relevantperformedactions.IsDeleted = 0
        And hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
        hec_act_plannedactions.IsPerformed = 1 And hec_act_plannedactions.IsDeleted = 0 And hec_act_plannedactions.IsCancelled = 0 And
        hec_act_plannedactions.Tenant_RefID = @TenantID Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
        hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
        hec_act_plannedaction_2_actiontype.IsDeleted = 0 Inner Join
      hec_act_actiontype
        On hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = hec_act_actiontype.HEC_ACT_ActionTypeID And
        hec_act_actiontype.GlobalPropertyMatchingID = @ActionTypeGpmID And
        hec_act_actiontype.Tenant_RefID = @TenantID And
        hec_act_actiontype.IsDeleted = 0
    Where 
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantplannedactions.IsDeleted = 0
	