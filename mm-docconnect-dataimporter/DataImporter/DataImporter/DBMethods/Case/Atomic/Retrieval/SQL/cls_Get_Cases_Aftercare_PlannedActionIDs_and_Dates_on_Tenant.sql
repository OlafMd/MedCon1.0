
    Select
      hec_cas_case_relevantplannedactions.Case_RefID As CaseID,
      hec_act_plannedactions.PlannedFor_Date As PlannedActionDate,
      hec_act_performedactions.IfPerfomed_DateOfAction As PerformedActionDate,
      hec_act_plannedactions.IfPerformed_PerformedAction_RefID As PerformedActionID, 
      hec_cas_cases.CaseNumber
    From
      hec_cas_cases
      Inner Join hec_cas_case_relevantplannedactions
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantplannedactions.Case_RefID And hec_cas_case_relevantplannedactions.IsDeleted = 0
      Inner Join hec_act_plannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And hec_act_plannedactions.IsDeleted = 0
      Inner Join hec_act_performedactions
        On hec_act_plannedactions.IfPerformed_PerformedAction_RefID = hec_act_performedactions.HEC_ACT_PerformedActionID And hec_act_performedactions.IsDeleted = 0 And
        hec_act_plannedactions.IsPerformed = 1
    Where
      hec_cas_cases.IsDeleted = 0 And
      hec_cas_cases.Tenant_RefID = @TenantID And
      Cast(hec_cas_cases.CaseNumber As Unsigned) <= 10000
	