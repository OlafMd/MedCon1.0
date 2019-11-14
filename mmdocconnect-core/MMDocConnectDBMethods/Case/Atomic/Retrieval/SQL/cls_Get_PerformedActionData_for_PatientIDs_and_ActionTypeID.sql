    
Select
  hec_act_performedactions.Patient_RefID As patient_id,
  hec_act_performedactions.IfPerfomed_DateOfAction As treatment_date,
  hec_cas_case_relevantperformedactions.Case_RefID as case_id
From
  hec_act_performedactions Inner Join
  hec_act_performedaction_2_actiontype
    On hec_act_performedactions.HEC_ACT_PerformedActionID = hec_act_performedaction_2_actiontype.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_2_actiontype.HEC_ACT_ActionType_RefID = @ActionTypeID And hec_act_performedaction_2_actiontype.Tenant_RefID = @TenantID And
    hec_act_performedaction_2_actiontype.IsDeleted = 0 Inner Join
  hec_act_plannedactions
    On hec_act_performedactions.HEC_ACT_PerformedActionID = hec_act_plannedactions.IfPerformed_PerformedAction_RefID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0 Inner Join
  hec_cas_case_relevantperformedactions
    On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID = hec_cas_case_relevantperformedactions.PerformedAction_RefID And
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantperformedactions.IsDeleted = 0
Where
  hec_act_performedactions.Patient_RefID = @PatientIDs And
  hec_act_performedactions.Tenant_RefID = @TenantID And
  hec_act_performedactions.IsDeleted = 0
Order By
  treatment_date Desc
	