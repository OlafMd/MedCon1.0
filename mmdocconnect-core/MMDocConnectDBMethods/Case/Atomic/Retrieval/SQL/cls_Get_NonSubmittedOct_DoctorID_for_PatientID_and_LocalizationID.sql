
SELECT
  hec_doctors.HEC_DoctorID AS OctDoctorID,
  Concat_Ws(' ', cmn_per_personinfo.Title, cmn_per_personinfo.FirstName, cmn_per_personinfo.LastName) AS OctDoctorName
FROM
  hec_cas_cases
  INNER JOIN hec_cas_case_relevantperformedactions ON
    hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID AND
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID AND hec_cas_case_relevantperformedactions.IsDeleted =
    0
  INNER JOIN hec_act_plannedactions hec_act_plannedactions1 ON
    hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_plannedactions1.IfPlannedFollowup_PreviousAction_RefID AND hec_act_plannedactions1.IsCancelled = 0
    AND hec_act_plannedactions1.Tenant_RefID = @TenantID AND hec_act_plannedactions1.IsDeleted = 0
  INNER JOIN hec_act_performedaction_diagnosisupdates ON hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID AND
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID AND
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0
  INNER JOIN hec_act_performedaction_diagnosisupdate_localizations ON
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
    hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID AND
    hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code = @LocalizationCode AND
    hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID AND
    hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
  INNER JOIN hec_cas_case_relevantplannedactions ON
    hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantplannedactions.Case_RefID AND
    hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID AND hec_cas_case_relevantplannedactions.IsDeleted = 0
  INNER JOIN hec_act_plannedactions ON hec_cas_case_relevantplannedactions.PlannedAction_RefID =
    hec_act_plannedactions.HEC_ACT_PlannedActionID AND hec_act_plannedactions.IsPerformed = 0 AND
    hec_act_plannedactions.IsCancelled = 0 AND hec_act_plannedactions.Tenant_RefID = @TenantID AND
    hec_act_plannedactions.IsDeleted = 0
  INNER JOIN hec_doctors ON hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
    hec_doctors.BusinessParticipant_RefID AND hec_doctors.Tenant_RefID = @TenantID AND hec_doctors.IsDeleted = 0
  INNER JOIN hec_act_plannedaction_2_actiontype ON hec_act_plannedactions.HEC_ACT_PlannedActionID =
    hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID AND
    hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @OctActionTypeID AND
    hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID AND hec_act_plannedaction_2_actiontype.IsDeleted = 0
  INNER JOIN cmn_bpt_businessparticipants ON hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID AND cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
    AND cmn_bpt_businessparticipants.IsDeleted = 0
  INNER JOIN cmn_per_personinfo ON cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID AND cmn_per_personinfo.Tenant_RefID = @TenantID AND
    cmn_per_personinfo.IsDeleted = 0
WHERE
  hec_cas_cases.Patient_RefID = @PatientID AND
  hec_cas_cases.Tenant_RefID = @TenantID AND
  hec_cas_cases.IsDeleted = 0
ORDER BY
  hec_act_plannedactions.Creation_Timestamp DESC
	