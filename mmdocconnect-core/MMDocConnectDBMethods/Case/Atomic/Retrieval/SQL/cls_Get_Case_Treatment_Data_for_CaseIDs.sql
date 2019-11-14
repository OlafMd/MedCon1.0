
Select
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As localization,
  hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID As
  diagnose_id,
  hec_act_performedaction_diagnosisupdates.IsDiagnosisConfirmed As is_confirmed,
  hec_doctors.HEC_DoctorID As op_doctor_id,
  hec_act_plannedactions.Patient_RefID As patient_id,
  hec_cas_case_relevantperformedactions.Case_RefID As case_id,
  hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID As drug_id,
  hec_act_plannedactions.PlannedFor_Date As treatment_date,
  hec_act_plannedactions.IsPerformed As is_performed,
  hec_act_plannedactions.HEC_ACT_PlannedActionID As planned_action_id
From
  hec_cas_case_relevantperformedactions Inner Join
  hec_act_performedaction_diagnosisupdates
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdate_localizations
    On
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID = hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 Inner Join
  hec_act_plannedactions
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0 Left Join
  hec_doctors
    On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
    hec_doctors.BusinessParticipant_RefID And hec_doctors.Tenant_RefID =
    @TenantID And hec_doctors.IsDeleted = 0 Inner Join
  hec_act_plannedaction_potentialprocedures
    On hec_act_plannedactions.HEC_ACT_PlannedActionID =
    hec_act_plannedaction_potentialprocedures.PlannedAction_RefID And
    hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID
    And hec_act_plannedaction_potentialprocedures.IsDeleted = 0 Inner Join
  hec_act_plannedaction_potentialprocedure_requiredproduct
    On
    hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID = hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID And hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID And hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0
Where
  hec_cas_case_relevantperformedactions.Case_RefID = @CaseIDs And
  hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
  hec_cas_case_relevantperformedactions.IsDeleted = 0
Group By
  hec_cas_case_relevantperformedactions.Case_RefID
Order By
  treatment_date
	