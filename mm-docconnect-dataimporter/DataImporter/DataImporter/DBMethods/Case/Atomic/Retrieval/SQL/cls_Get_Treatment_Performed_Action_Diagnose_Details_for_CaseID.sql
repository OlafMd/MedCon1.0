
Select
  hec_dia_diagnosis_localizations.LocalizationCode as localization,
  hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID as diagnose_id
From
  hec_cas_case_relevantperformedactions Inner Join
  hec_act_plannedactions
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0 And
    hec_act_plannedactions.IsCancelled = 0
     Inner Join
  hec_act_performedaction_diagnosisupdates
    On hec_act_plannedactions.IfPerformed_PerformedAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0    
  Inner Join
  hec_act_performedaction_diagnosisupdate_localizations
    On
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID = hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
    hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And
    hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
     Inner Join
  hec_dia_diagnosis_localizations
    On
    hec_act_performedaction_diagnosisupdate_localizations.HEC_DIA_Diagnosis_Localization_RefID = hec_dia_diagnosis_localizations.HEC_DIA_Diagnosis_LocalizationID And
    hec_dia_diagnosis_localizations.Tenant_RefID = @TenantID And
    hec_dia_diagnosis_localizations.IsDeleted = 0 
Where
  hec_cas_case_relevantperformedactions.Case_RefID = @CaseID And
  hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
  hec_cas_case_relevantperformedactions.IsDeleted = 0
	