
Select
   hec_act_performedactions.IfPerfomed_DateOfAction as TreatmentDate
From
  hec_cas_case_relevantplannedactions Inner Join
  hec_act_plannedactions
    On hec_cas_case_relevantplannedactions.PlannedAction_RefID =
    hec_act_plannedactions.HEC_ACT_PlannedActionID And
    hec_act_plannedactions.IsDeleted = 0 And hec_act_plannedactions.Tenant_RefID
    =@TenantID Inner Join
  hec_act_performedactions
    On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID =
    hec_act_performedactions.HEC_ACT_PerformedActionID
Where
  hec_act_performedactions.IsDeleted = 0 And
  hec_act_performedactions.Tenant_RefID =@TenantID
  And
  hec_cas_case_relevantplannedactions.Case_RefID =
  @CaseID
	