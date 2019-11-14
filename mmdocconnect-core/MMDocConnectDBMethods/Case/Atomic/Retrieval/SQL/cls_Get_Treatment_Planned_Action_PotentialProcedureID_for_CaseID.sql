
Select
  hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID as potential_procedure_id
From
  hec_cas_case_relevantperformedactions Inner Join
  hec_act_plannedactions
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0
    Inner Join
  hec_act_plannedaction_potentialprocedures
    On hec_act_plannedaction_potentialprocedures.PlannedAction_RefID =
    hec_act_plannedactions.HEC_ACT_PlannedActionID And
    hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID And
    hec_act_plannedaction_potentialprocedures.IsDeleted = 0    
Where
  hec_cas_case_relevantperformedactions.Case_RefID = @CaseID And
  hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
  hec_cas_case_relevantperformedactions.IsDeleted = 0
	