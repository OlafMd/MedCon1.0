
Select
  hec_act_plannedactions.IsPerformed as is_aftercare_performed,
  hec_cas_case_relevantplannedactions.Case_RefID as case_id
From
  hec_cas_case_relevantplannedactions Inner Join
  hec_act_plannedactions
    On hec_cas_case_relevantplannedactions.PlannedAction_RefID =
    hec_act_plannedactions.HEC_ACT_PlannedActionID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0 And
    hec_act_plannedactions.IsCancelled = 0 
Where
  hec_cas_case_relevantplannedactions.Case_RefID = @CaseIDs And
  hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
  hec_cas_case_relevantplannedactions.IsDeleted = 0
	