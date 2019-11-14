
   Select
      hec_act_plannedactions1.IsPerformed as is_performed,
      hec_act_plannedactions.PlannedFor_Date As op_date,
      hec_act_performedactions.IfPerfomed_DateOfAction As performed_on_date
    From
      hec_cas_case_relevantperformedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
  	    hec_act_plannedactions.IsPerformed = 1 And 
  	    hec_act_plannedactions.Tenant_RefID = @TenantID And
  	    hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_cas_case_relevantplannedactions
        On hec_cas_case_relevantperformedactions.Case_RefID = hec_cas_case_relevantplannedactions.Case_RefID And
        hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
        hec_cas_case_relevantplannedactions.IsDeleted = 0 Inner Join
      hec_act_plannedactions hec_act_plannedactions1
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions1.HEC_ACT_PlannedActionID And
        hec_act_plannedactions1.Tenant_RefID = @TenantID And
        hec_act_plannedactions1.IsDeleted = 0 Left Join
      hec_act_performedactions
        On hec_act_plannedactions1.IfPerformed_PerformedAction_RefID = hec_act_performedactions.HEC_ACT_PerformedActionID And
        hec_act_performedactions.Tenant_RefID = @TenantID And
        hec_act_performedactions.IsDeleted = 0
    Where
      hec_cas_case_relevantperformedactions.Case_RefID = @CaseIDs And
      hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantperformedactions.IsDeleted = 0
	