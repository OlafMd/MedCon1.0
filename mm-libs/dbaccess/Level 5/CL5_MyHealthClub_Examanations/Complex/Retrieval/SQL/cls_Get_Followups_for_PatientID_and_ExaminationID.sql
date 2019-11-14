
Select
  hec_act_plannedactions.PlannedFor_Date As date,
  hec_act_plannedaction_2_plannedactionfollowupreasons.FollowupReason,
  hec_act_plannedactions.HEC_ACT_PlannedActionID
From
  hec_act_plannedactions Inner Join
  hec_act_plannedaction_2_plannedactionfollowupreasons
    On hec_act_plannedactions.HEC_ACT_PlannedActionID =
    hec_act_plannedaction_2_plannedactionfollowupreasons.HEC_ACT_PlannedAction_RefID And hec_act_plannedaction_2_plannedactionfollowupreasons.Tenant_RefID = @TenantID And hec_act_plannedaction_2_plannedactionfollowupreasons.IsDeleted = 0
Where
  hec_act_plannedactions.Patient_RefID = @PatientID And
  hec_act_plannedactions.IsDeleted = 0 And
  hec_act_plannedactions.Tenant_RefID = @TenantID And
  hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID = @ExaminationID
  