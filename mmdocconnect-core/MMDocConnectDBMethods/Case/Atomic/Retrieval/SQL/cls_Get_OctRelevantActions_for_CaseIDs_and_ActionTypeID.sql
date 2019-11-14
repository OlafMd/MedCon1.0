
    SELECT
      hec_cas_case_relevantplannedactions.Case_RefID AS CaseID,
      hec_cas_case_relevantplannedactions.PlannedAction_RefID AS ActionID,
      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code AS LocalizationCode,
      hec_act_plannedactions.Patient_RefID AS PatientID
    FROM
      hec_cas_case_relevantplannedactions
      INNER JOIN hec_act_plannedactions ON hec_cas_case_relevantplannedactions.PlannedAction_RefID =
        hec_act_plannedactions.HEC_ACT_PlannedActionID AND hec_act_plannedactions.IsPerformed = 1 AND
        hec_act_plannedactions.IsCancelled = 0 AND hec_act_plannedactions.Tenant_RefID = @TenantID AND
        hec_act_plannedactions.IsDeleted = 0
      INNER JOIN hec_act_performedaction_2_actiontype ON hec_act_plannedactions.IfPerformed_PerformedAction_RefID =
        hec_act_performedaction_2_actiontype.HEC_ACT_PerformedAction_RefID AND
        hec_act_performedaction_2_actiontype.HEC_ACT_ActionType_RefID = @ActionTypeID AND
        hec_act_performedaction_2_actiontype.Tenant_RefID = @TenantID AND hec_act_performedaction_2_actiontype.IsDeleted = 0
      INNER JOIN hec_act_performedaction_diagnosisupdates
        ON hec_act_performedaction_2_actiontype.HEC_ACT_PerformedAction_RefID =
        hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID AND
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID AND
        hec_act_performedaction_diagnosisupdates.IsDeleted = 0
      INNER JOIN hec_act_performedaction_diagnosisupdate_localizations
        ON hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
        hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID AND
        hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID AND
        hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
    WHERE
      hec_act_plannedactions.Patient_RefID = @PatientIDs AND
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID AND
      hec_cas_case_relevantplannedactions.IsDeleted = 0
    ORDER BY
      hec_cas_case_relevantplannedactions.Creation_Timestamp
	