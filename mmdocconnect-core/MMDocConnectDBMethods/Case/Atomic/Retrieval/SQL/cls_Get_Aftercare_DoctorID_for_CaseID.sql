
    Select
      hec_doctors.HEC_DoctorID As aftercare_doctor_id
    From
      hec_act_plannedactions Inner Join
      hec_doctors
        On hec_doctors.BusinessParticipant_RefID = hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID And hec_doctors.Tenant_RefID = @TenantID And
        hec_doctors.IsDeleted = 0 Inner Join
      hec_cas_case_relevantplannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And
        hec_cas_case_relevantplannedactions.Case_RefID = @CaseID And hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
        hec_cas_case_relevantplannedactions.IsDeleted = 0 Inner Join
      hec_act_plannedaction_2_actiontype 
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
  	    hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @PlannedActionTypeID And
  	    hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
  	    hec_act_plannedaction_2_actiontype.IsDeleted = 0
    Where
      hec_act_plannedactions.Tenant_RefID = @TenantID And
      hec_act_plannedactions.IsCancelled = 0 And
      hec_act_plannedactions.IsPerformed = 0 And
      hec_act_plannedactions.IsDeleted = 0 
	