
    SELECT
      hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID AS diagnose_id,
      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code AS localization,
      hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID AS op_doctor_bpt_id,
      hec_cas_case_relevantperformedactions.Case_RefID AS case_id
    FROM
      hec_cas_case_relevantperformedactions
      INNER JOIN hec_act_plannedactions ON hec_cas_case_relevantperformedactions.PerformedAction_RefID =
        hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID AND hec_act_plannedactions.Tenant_RefID = @TenantID
        AND hec_act_plannedactions.IsDeleted = 0
      INNER JOIN hec_act_performedaction_diagnosisupdates ON hec_cas_case_relevantperformedactions.PerformedAction_RefID =
        hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID AND
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID AND
        hec_act_performedaction_diagnosisupdates.IsDeleted = 0
      INNER JOIN hec_act_performedaction_diagnosisupdate_localizations
        ON hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
        hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID AND
        hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID AND
        hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
    WHERE
      hec_cas_case_relevantperformedactions.Case_RefID = @CaseIDs AND
      hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID AND
      hec_cas_case_relevantperformedactions.IsDeleted = 0
    GROUP BY
      hec_cas_case_relevantperformedactions.Case_RefID
    ORDER BY
      NULL
	