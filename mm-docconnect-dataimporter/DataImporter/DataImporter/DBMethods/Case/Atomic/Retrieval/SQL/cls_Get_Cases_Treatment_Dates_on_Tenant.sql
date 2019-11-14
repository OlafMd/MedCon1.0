
Select
  hec_act_plannedactions.PlannedFor_Date As TreatmentPlannedActionDate,
  hec_cas_case_relevantperformedactions.Case_RefID As CaseID,
  hec_act_plannedactions.HEC_ACT_PlannedActionID As TreatmentPlannedActionID
From
  hec_cas_case_relevantperformedactions
  Inner Join hec_act_plannedactions
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And 
    hec_act_plannedactions.IsDeleted = 0 
    Inner Join hec_cas_cases
    On hec_cas_case_relevantperformedactions.Case_RefID = hec_cas_cases.HEC_CAS_CaseID And
	Cast(hec_cas_cases.CaseNumber As Unsigned) <= 10000 And
    hec_cas_cases.IsDeleted = 0 ANd 
    hec_cas_cases.Tenant_RefID = @TenantID
Where 
hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
hec_cas_case_relevantperformedactions.IsDeleted = 0
	