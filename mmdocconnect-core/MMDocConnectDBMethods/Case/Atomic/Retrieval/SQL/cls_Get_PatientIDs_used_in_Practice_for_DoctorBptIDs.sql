
    select distinct 
      acs_and_octs.patient_id as patient_id from (
    (Select Distinct
      hec_act_plannedactions.Patient_RefID As patient_id
    From
      hec_act_plannedactions Left Join
      hec_patient_medicalpractices
        On hec_act_plannedactions.Patient_RefID = hec_patient_medicalpractices.HEC_Patient_RefID And hec_patient_medicalpractices.HEC_MedicalPractices_RefID =
        @PracticeID And hec_patient_medicalpractices.Tenant_RefID = @TenantID And hec_patient_medicalpractices.IsDeleted = 0 Inner Join
      hec_cas_case_relevantplannedactions
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_cas_case_relevantplannedactions.PlannedAction_RefID Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
  	    hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @AftercarePlannedActionTypeID And
  	    hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
  	    hec_act_plannedaction_2_actiontype.IsDeleted = 0 Inner Join
      hec_cas_case_relevantperformedactions
        On hec_cas_case_relevantplannedactions.Case_RefID = hec_cas_case_relevantperformedactions.Case_RefID And
        hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
        hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
      hec_act_plannedactions hec_act_plannedactions1
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions1.IfPlannedFollowup_PreviousAction_RefID And
  	    hec_act_plannedactions1.IsPerformed = 1 And
  	    hec_act_plannedactions1.Tenant_RefID = @TenantID And
  	    hec_act_plannedactions1.IsDeleted = 0
    Where
      hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID = @DoctorBptIDs And
      hec_patient_medicalpractices.HEC_Patient_MedicalPracticeID Is Null And
      hec_act_plannedactions.Tenant_RefID = @TenantID And
      hec_act_plannedactions.IsDeleted = 0)
    union all
    (Select Distinct
      hec_act_plannedactions.Patient_RefID As patient_id
    From
      hec_act_plannedactions Left Join
      hec_patient_medicalpractices
        On hec_act_plannedactions.Patient_RefID = hec_patient_medicalpractices.HEC_Patient_RefID And hec_patient_medicalpractices.HEC_MedicalPractices_RefID =
        @PracticeID And hec_patient_medicalpractices.Tenant_RefID = @TenantID And hec_patient_medicalpractices.IsDeleted = 0 Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID  And
  	    hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @OctPlannedActionTypeID And
  	    hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
  	    hec_act_plannedaction_2_actiontype.IsDeleted = 0
    Where
      hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID = @DoctorBptIDs And
      hec_patient_medicalpractices.HEC_Patient_MedicalPracticeID Is Null And
      hec_act_plannedactions.Tenant_RefID = @TenantID And
      hec_act_plannedactions.IsDeleted = 0) ) acs_and_octs
	