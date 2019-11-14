
  Select
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As localization,
  hec_act_performedactions.IfPerfomed_DateOfAction As date,
  hec_act_plannedactions.Patient_RefID As patient_id,
  hec_act_plannedactions.HEC_ACT_PlannedActionID As id
From
  hec_act_plannedactions Inner Join
  hec_act_plannedaction_2_actiontype
    On hec_act_plannedactions.HEC_ACT_PlannedActionID =
    hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
    hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID =
    @PlannedActionTypeID And hec_act_plannedaction_2_actiontype.Tenant_RefID =
    @TenantID And hec_act_plannedaction_2_actiontype.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdates
    On hec_act_plannedactions.IfPerformed_PerformedAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdate_localizations
    On
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID = hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 Inner Join
  hec_act_performedactions
    On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID =
    hec_act_performedactions.HEC_ACT_PerformedActionID And
    hec_act_performedactions.Tenant_RefID = @TenantID And
    hec_act_performedactions.IsDeleted = 0
Where
  hec_act_plannedactions.Patient_RefID = @PatientID And
  hec_act_plannedactions.Tenant_RefID = @TenantID And
  hec_act_plannedactions.IsPerformed = 1 And
  hec_act_plannedactions.IsDeleted = 0 And
  hec_act_plannedactions.IsCancelled = 0
Order By
  hec_act_plannedactions.Creation_Timestamp Desc
	