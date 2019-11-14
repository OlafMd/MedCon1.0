
    (Select
      hec_act_performedactions.IfPerfomed_DateOfAction As TreatmentDate,
      0 As IsOp,
      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As Localization,
      0 As IsOpPerformed,
      hec_doctors.HEC_DoctorID As DoctorID,
      hec_cas_cases.HEC_CAS_CaseID As CaseID,
      hec_act_plannedactions.HEC_ACT_PlannedActionID As ActionID
    From
      hec_cas_cases Inner Join
      hec_cas_case_relevantplannedactions
        On hec_cas_cases.HEC_CAS_CaseID =
        hec_cas_case_relevantplannedactions.Case_RefID And
        hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
        hec_cas_case_relevantplannedactions.IsDeleted = 0 Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID =
        hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
        hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
        hec_act_plannedaction_2_actiontype.IsDeleted = 0 Inner Join
      hec_act_actiontype
        On hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID =
        hec_act_actiontype.HEC_ACT_ActionTypeID And
        hec_act_actiontype.GlobalPropertyMatchingID Like '%oct%' And
        hec_act_actiontype.Tenant_RefID = @TenantID And
        hec_act_actiontype.IsDeleted = 0 Inner Join
      hec_act_plannedactions
        On hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID =
        hec_act_plannedactions.HEC_ACT_PlannedActionID And
        hec_act_plannedactions.Tenant_RefID = @TenantID And
        hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_act_performedactions
        On hec_act_plannedactions.IfPerformed_PerformedAction_RefID =
        hec_act_performedactions.HEC_ACT_PerformedActionID And
        hec_act_performedactions.Tenant_RefID = @TenantID And
        hec_act_performedactions.IsDeleted = 0 Inner Join
      hec_cas_case_relevantperformedactions
        On hec_cas_cases.HEC_CAS_CaseID =
        hec_cas_case_relevantperformedactions.Case_RefID And
        hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
        hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdates
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
        hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
        hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdate_localizations
        On
        hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID = hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
        hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID =
        @TenantID And
        hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
      Inner Join
      hec_doctors
        On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
        hec_doctors.BusinessParticipant_RefID And
        hec_doctors.Tenant_RefID = @TenantID And
        hec_doctors.IsDeleted = 0
    Where
      hec_cas_cases.Patient_RefID = @PatientID And
      hec_cas_cases.Tenant_RefID = @TenantID)
    UNION ALL
    (SELECT
      hec_act_plannedactions.PlannedFor_Date AS TreatmentDate,
      1 AS IsOp,
      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code AS Localization,
      hec_act_plannedactions.IsPerformed AS IsOpPerformed,
      hec_doctors.HEC_DoctorID AS DoctorID,
      hec_cas_case_relevantperformedactions.Case_RefID AS CaseID,
      hec_act_plannedactions.HEC_ACT_PlannedActionID AS ActionID
    FROM
      hec_cas_case_relevantperformedactions
      INNER JOIN hec_act_performedaction_diagnosisupdates ON hec_cas_case_relevantperformedactions.PerformedAction_RefID =
        hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID AND
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID AND
        hec_act_performedaction_diagnosisupdates.IsDeleted = 0
      INNER JOIN hec_act_performedaction_diagnosisupdate_localizations
        ON hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
        hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID AND
        hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID AND
        hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
      INNER JOIN hec_act_plannedactions ON hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID =
        hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID AND hec_act_plannedactions.Patient_RefID = @PatientID
        AND hec_act_plannedactions.Tenant_RefID = @TenantID AND hec_act_plannedactions.IsDeleted = 0
      INNER JOIN hec_doctors ON hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
        hec_doctors.BusinessParticipant_RefID AND hec_doctors.Tenant_RefID = @TenantID AND hec_doctors.IsDeleted = 0
    WHERE
      hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID AND
      hec_cas_case_relevantperformedactions.IsDeleted = 0)
    ORDER BY
      TreatmentDate
	