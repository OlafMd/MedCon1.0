
Select
  hec_act_plannedactions.PlannedFor_Date as op_date
From
  hec_cas_case_relevantperformedactions Inner Join
  hec_act_plannedactions
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
	  hec_act_plannedactions.Patient_RefID = @PatientID And
	  hec_act_plannedactions.PlannedFor_Date between @MinDate and @MaxDate And
	  hec_act_plannedactions.IsPerformed = 1 And
	  hec_act_plannedactions.IsCancelled = 0 And
	  hec_act_plannedactions.Tenant_RefID = @TenantID And
	  hec_act_plannedactions.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdates
    On hec_act_plannedactions.IfPerformed_PerformedAction_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdate_localizations
    On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
    hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
 	 hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code = @LocalizationCode And
 	 hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And
 	 hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
Where
	hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
	hec_cas_case_relevantperformedactions.IsDeleted = 0
Limit 1
	