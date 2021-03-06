
Select
  hec_cas_case_relevantplannedactions.PlannedAction_RefID As PlannedActionID,
  hec_cas_case_relevantplannedactions.IsDeleted,
  hec_cas_case_relevantplannedactions.Creation_Timestamp As CreationTimestamp,
  hec_cas_case_relevantplannedactions.Case_RefID As CaseID,
  hec_act_plannedactions.IsCancelled,
  hec_act_plannedactions.IsPerformed,
  hec_act_plannedactions.Patient_RefID as PatientID
From
  hec_cas_case_relevantplannedactions Inner Join
  hec_act_plannedaction_2_actiontype
    On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
    hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @ActionTypeID And hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
    hec_act_plannedaction_2_actiontype.IsDeleted = 0 Inner Join
  hec_act_plannedactions
    On hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And 
    (hec_act_plannedactions.IsPerformed = 1 Or hec_act_plannedactions.IsPerformed = @IsPerformed) And hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0
Where
  hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID
	