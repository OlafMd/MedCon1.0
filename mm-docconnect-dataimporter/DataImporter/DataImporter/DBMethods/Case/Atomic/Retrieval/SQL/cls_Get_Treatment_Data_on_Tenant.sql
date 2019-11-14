
SELECT
  hec_cas_cases.Patient_RefID,
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code,
  hec_cas_cases.CaseNumber,
  hec_cas_cases.HEC_CAS_CaseID,
  hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID,
  hec_act_plannedactions.PlannedFor_Date,
  hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID
FROM
  hec_cas_cases
  INNER JOIN hec_cas_case_relevantperformedactions
    ON hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID
  INNER JOIN hec_act_performedaction_diagnosisupdates ON hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID
  INNER JOIN hec_act_performedaction_diagnosisupdate_localizations
    ON hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
    hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID
  INNER JOIN hec_act_plannedactions ON hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID
  INNER JOIN hec_act_plannedaction_potentialprocedures ON hec_act_plannedactions.HEC_ACT_PlannedActionID =
    hec_act_plannedaction_potentialprocedures.PlannedAction_RefID
  INNER JOIN hec_act_plannedaction_potentialprocedure_requiredproduct
    ON hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID =
    hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID
WHERE
  hec_cas_cases.Tenant_RefID = @TenantID AND
  hec_cas_cases.IsDeleted = 0 AND
  hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID AND
  hec_cas_case_relevantperformedactions.IsDeleted = 0 AND
  hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID AND
  hec_act_performedaction_diagnosisupdates.IsDeleted = 0 AND
  hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID AND
  hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 AND
  hec_act_plannedactions.Tenant_RefID = @TenantID AND
  hec_act_plannedactions.IsDeleted = 0 AND
  hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID AND
  hec_act_plannedaction_potentialprocedures.IsDeleted = 0 AND
  hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID AND
  hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0
	