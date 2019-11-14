    
Select
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As LocalizationCode,
  hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID As DiagnoseID,
  hec_act_plannedactions.PlannedFor_Date  As TreatmentDate,
  hec_cas_cases.Patient_RefID As PatientID
From
  hec_act_performedactions Inner Join
  hec_act_performedaction_diagnosisupdates
    On hec_act_performedactions.HEC_ACT_PerformedActionID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID =
    @TenantID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdate_localizations
    On
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID = hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 Inner Join
  hec_cas_case_relevantperformedactions
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_performedactions.HEC_ACT_PerformedActionID And
    hec_cas_case_relevantperformedactions.Tenant_RefID =
    @TenantID And
    hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
  hec_cas_cases
    On hec_cas_case_relevantperformedactions.Case_RefID =
    hec_cas_cases.HEC_CAS_CaseID And hec_cas_cases.Tenant_RefID =
    @TenantID And hec_cas_cases.IsDeleted = 0
  Inner Join
  hec_act_plannedactions
    On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID =
    hec_cas_case_relevantperformedactions.PerformedAction_RefID Left Join
  hec_cas_case_universalpropertyvalue
    On hec_cas_cases.HEC_CAS_CaseID =
    hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID And
    hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID And
    hec_cas_case_universalpropertyvalue.IsDeleted = 0 and
    hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID = @CaseUniversalPID

Where
  hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalPropertyValueID Is Null And
  hec_act_performedactions.Tenant_RefID = @TenantID And
  hec_act_performedactions.IsDeleted = 0   
	