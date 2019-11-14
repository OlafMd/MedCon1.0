
Select
  hec_cas_cases.CaseNumber,
  hec_cas_cases.HEC_CAS_CaseID As CaseID,
  hec_cas_cases.Patient_RefID As PatientID,
  hec_doctors.HEC_DoctorID As TreatmentDoctorID,
  hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID As DrugID,
  hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID As
  DiagnoseID,
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As Localization,
  hec_act_plannedactions.PlannedFor_Date As TreatmentDate,
  hec_cas_cases.Modification_Timestamp As CaseCreationDate,
  hec_act_plannedactions.HEC_ACT_PlannedActionID As TreatmentPlannedActionID
From
  hec_cas_cases Inner Join
  hec_cas_case_relevantperformedactions
    On hec_cas_cases.HEC_CAS_CaseID =
    hec_cas_case_relevantperformedactions.Case_RefID And
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
  hec_act_plannedactions
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0 Inner Join
  hec_doctors
    On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
    hec_doctors.BusinessParticipant_RefID And hec_doctors.Tenant_RefID =
    @TenantID And hec_doctors.IsDeleted = 0 Left Join
  hec_act_plannedaction_potentialprocedures
    On hec_act_plannedactions.HEC_ACT_PlannedActionID =
    hec_act_plannedaction_potentialprocedures.PlannedAction_RefID And
    hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID
    And hec_act_plannedaction_potentialprocedures.IsDeleted = 0 Left Join
  hec_act_plannedaction_potentialprocedure_requiredproduct
    On
    hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID = hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID And hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID And hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdates
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdate_localizations
    On
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID = hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
Where
  hec_cas_cases.HEC_CAS_CaseID = @CaseIDs And
  hec_cas_cases.Tenant_RefID = @TenantID
Group By
  hec_cas_cases.HEC_CAS_CaseID
	