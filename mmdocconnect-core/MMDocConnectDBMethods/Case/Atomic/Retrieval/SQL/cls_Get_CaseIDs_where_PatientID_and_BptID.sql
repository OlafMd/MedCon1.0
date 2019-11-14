
    Select
      hec_cas_case_relevantperformedactions.Case_RefID As case_id
    From
      hec_act_plannedactions Inner Join
      hec_cas_case_relevantperformedactions
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
        hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And hec_cas_case_relevantperformedactions.IsDeleted = 0
    Where
      (hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID = @BptIDs Or
        hec_act_plannedactions.MedicalPractice_RefID = @PracticeID) And
      hec_act_plannedactions.Patient_RefID = @PatientID And
      hec_act_plannedactions.Tenant_RefID = @TenantID And
      hec_act_plannedactions.IsDeleted = 0
	