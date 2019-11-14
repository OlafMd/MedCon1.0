
Select
  hec_cas_cases.HEC_CAS_CaseID As CaseID,
  hec_act_plannedactions.PlannedFor_Date As TreatmentDate,
  hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID As TreatmentDoctorBptID
From
  hec_cas_cases
  Inner Join hec_cas_case_relevantperformedactions On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID And
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And hec_cas_case_relevantperformedactions.IsDeleted = 0
  Inner Join hec_act_plannedactions On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And hec_act_plannedactions.IsDeleted = 0 And hec_act_plannedactions.IsPerformed = 0 And hec_act_plannedactions.IsCancelled = 0
  Inner Join hec_act_performedaction_diagnosisupdates On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0
Where
  hec_cas_cases.Tenant_RefID = @TenantID And
  hec_cas_cases.IsDeleted = 0 And
  hec_cas_cases.Patient_RefID = @PatientID
	