
Select
  hec_cas_case_relevantplannedactions.Case_RefID As CaseID,
  hec_cas_case_relevantplannedactions.PlannedAction_RefID As AftercareActionID,
  hec_cas_case_relevantplannedactions.Creation_Timestamp,
  hec_cas_case_relevantplannedactions.IsDeleted,
  hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID As AftercareDoctorPracticeBptID,
  hec_act_plannedactions.IsPerformed,
  hec_act_plannedactions.IsCancelled
From
  hec_cas_case_relevantplannedactions Inner Join
  hec_act_plannedactions
    On hec_cas_case_relevantplannedactions.PlannedAction_RefID =
    hec_act_plannedactions.HEC_ACT_PlannedActionID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0
Where
	hec_cas_case_relevantplannedactions.Case_RefID = @CaseIDs And
	hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID 
	