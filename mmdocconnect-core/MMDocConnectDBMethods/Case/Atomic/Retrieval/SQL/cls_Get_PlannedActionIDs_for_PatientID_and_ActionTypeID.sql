
SELECT
  hec_cas_case_relevantplannedactions.PlannedAction_RefID AS action_id,
  hec_act_plannedactions.IsPerformed as performed
FROM
  hec_act_plannedactions
  INNER JOIN hec_act_plannedaction_2_actiontype ON hec_act_plannedactions.HEC_ACT_PlannedActionID =
    hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID AND
    hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @ActionTypeID AND
    hec_act_plannedaction_2_actiontype.IsDeleted = 0
  INNER JOIN hec_cas_case_relevantplannedactions ON hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID =
    hec_cas_case_relevantplannedactions.PlannedAction_RefID
WHERE
  hec_act_plannedactions.Patient_RefID = @PatientID AND
  hec_act_plannedactions.IsDeleted = 0
ORDER BY
  hec_cas_case_relevantplannedactions.Creation_Timestamp
	