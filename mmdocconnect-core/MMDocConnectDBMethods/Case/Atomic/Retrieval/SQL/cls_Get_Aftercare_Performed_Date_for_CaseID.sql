
    Select
      hec_act_performedactions.IfPerfomed_DateOfAction as aftercare_date
    From
      hec_cas_case_relevantplannedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID =
        hec_act_plannedactions.HEC_ACT_PlannedActionID And
        hec_act_plannedactions.Tenant_RefID = @TenantID And
        hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_act_performedactions
        On hec_act_plannedactions.IfPerformed_PerformedAction_RefID =
        hec_act_performedactions.HEC_ACT_PerformedActionID And
        hec_act_performedactions.Tenant_RefID = @TenantID And
        hec_act_performedactions.IsDeleted = 0
    Where
      hec_cas_case_relevantplannedactions.Case_RefID = @CaseID And
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantplannedactions.IsDeleted = 0
	