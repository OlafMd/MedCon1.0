
    Select
      hec_act_plannedactions.HEC_ACT_PlannedActionID As planned_action_id,
      hec_act_plannedactions.PlannedFor_Date as treatment_date,
      hec_act_plannedactions.IsPerformed as is_treatment_performed
    From
      hec_cas_case_relevantperformedactions Inner Join
      hec_act_plannedactions
        On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID =
        hec_cas_case_relevantperformedactions.PerformedAction_RefID And
        hec_act_plannedactions.IsDeleted = 0 And hec_act_plannedactions.Tenant_RefID
        = @TenantID And hec_act_plannedactions.IsCancelled = 0
    Where
      hec_cas_case_relevantperformedactions.Case_RefID = @CaseID And
      hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantperformedactions.IsDeleted = 0
	