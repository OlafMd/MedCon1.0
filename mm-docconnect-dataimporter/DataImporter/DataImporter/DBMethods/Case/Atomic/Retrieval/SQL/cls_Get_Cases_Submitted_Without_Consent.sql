
    Select
      hec_cas_cases.CaseNumber,
      hec_cas_cases.Creation_Timestamp,
      hec_cas_cases.HEC_CAS_CaseID,
      hec_act_plannedactions.HEC_ACT_PlannedActionID
    From
      hec_cas_cases Inner Join
      hec_cas_case_relevantperformedactions
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID Left Join
      hec_cas_case_billcodes
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_billcodes.HEC_CAS_Case_RefID And hec_cas_case_billcodes.IsDeleted = 0
    Where
      hec_act_plannedactions.IsPerformed = 1 And
      hec_cas_case_billcodes.HEC_CAS_Case_BillCodeID Is Null And
      hec_cas_cases.Tenant_RefID = @TenantID And
      hec_cas_cases.IsDeleted = 0
	