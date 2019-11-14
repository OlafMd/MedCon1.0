
Select
  hec_act_performedaction_diagnosisupdate_localizations.HEC_DIA_Diagnosis_Localization_RefID,
  hec_act_performedaction_diagnosisupdates.HEC_Patient_Diagnosis_RefID,
  hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID,
  hec_act_performedaction_diagnosisupdate_localizations.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID
From
  hec_act_plannedactions Inner Join
  hec_act_performedaction_diagnosisupdates
    On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdate_localizations
    On
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID = hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And 
    hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And 
    hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 
Where
  hec_act_plannedactions.HEC_ACT_PlannedActionID = @PlannedActionID And
  hec_act_plannedactions.Tenant_RefID = @TenantID And
  hec_act_plannedactions.IsDeleted = 0 And
  hec_act_plannedactions.IsCancelled = 0
	