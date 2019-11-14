
    Select
      hec_cas_cases.HEC_CAS_CaseID As CaseID,
      hec_cas_cases.CaseNumber,
      hec_act_plannedactions.HEC_ACT_PlannedActionID As TreatmentActionID,
      hec_cas_case_relevantplannedactions.PlannedAction_RefID As AftercareActionID
    From
      hec_cas_cases Left Join
      hec_cas_case_relevantplannedactions
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantplannedactions.Case_RefID And hec_cas_case_relevantplannedactions.IsDeleted = 0 Inner Join
      hec_cas_case_relevantperformedactions
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID And hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
        hec_act_plannedactions.IsDeleted = 0 And
        hec_act_plannedactions.IsPerformed = 1
    Where
      hec_cas_cases.Tenant_RefID = @TenantID And
      hec_cas_cases.IsDeleted = 0 And
      (Cast(hec_cas_cases.CaseNumber As Unsigned) < 10000 Or
        hec_cas_cases.Creation_Timestamp between '2016-02-01' and now())
	