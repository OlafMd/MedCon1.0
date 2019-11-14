
    Select
      hec_doctors.HEC_DoctorID as treatment_doctor_id
    From
      hec_cas_case_relevantperformedactions Inner Join
      hec_act_plannedactions
        On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID =
        hec_cas_case_relevantperformedactions.PerformedAction_RefID And
        hec_act_plannedactions.Tenant_RefID = @TenantID And
        hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_doctors On hec_doctors.BusinessParticipant_RefID =
        hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID And
        hec_doctors.Tenant_RefID = @TenantID And hec_doctors.IsDeleted = 0
    Where
      hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantperformedactions.IsDeleted = 0 And
      hec_cas_case_relevantperformedactions.Case_RefID = @CaseID
	