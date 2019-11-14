
Select
  hec_cas_cases.HEC_CAS_CaseID As case_id,
  hec_cas_cases.CaseNumber as case_number,
  hec_act_performedactions.IfPerfomed_DateOfAction as performed_date
From
  hec_cas_case_relevantplannedactions
  Inner Join hec_act_plannedactions
    On hec_cas_case_relevantplannedactions.PlannedAction_RefID =
    hec_act_plannedactions.HEC_ACT_PlannedActionID And
    hec_act_plannedactions.IsPerformed = 1 And
    hec_act_plannedactions.IsDeleted = 0 And
    hec_act_plannedactions.IsCancelled = 0 And
    hec_act_plannedactions.Tenant_RefID = @TenantID
  Inner Join hec_cas_cases On hec_cas_cases.HEC_CAS_CaseID =
    hec_cas_case_relevantplannedactions.Case_RefID And
    hec_cas_cases.IsDeleted = 0 And
    hec_cas_cases.Tenant_RefID = @TenantID And
  CAST(hec_cas_cases.CaseNumber as unsigned) >= 10000 
  Inner Join hec_act_performedactions
    On hec_act_plannedactions.IfPerformed_PerformedAction_RefID =
    hec_act_performedactions.HEC_ACT_PerformedActionID And
    hec_act_performedactions.Tenant_RefID = @TenantID And
    hec_act_performedactions.IsDeleted = 0 
Where
  hec_cas_case_relevantplannedactions.IsDeleted = 0 And
  hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID 
	