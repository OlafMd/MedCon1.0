
Select
  hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID AS DrugID
From
  hec_cas_case_relevantperformedactions
  Inner Join hec_act_plannedactions
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID
  Inner Join hec_act_plannedaction_potentialprocedures
    On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_potentialprocedures.PlannedAction_RefID
  Inner Join hec_act_plannedaction_potentialprocedure_requiredproduct
    On hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID =
    hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID
Where
  hec_cas_case_relevantperformedactions.Case_RefID = @CaseID And
  hec_cas_case_relevantperformedactions.IsDeleted = 0 And
  hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID
	