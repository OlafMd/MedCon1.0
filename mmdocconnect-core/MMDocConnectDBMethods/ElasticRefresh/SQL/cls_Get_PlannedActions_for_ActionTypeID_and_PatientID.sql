
    Select
      hec_act_plannedactions.HEC_ACT_PlannedActionID,
      hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID,
      hec_act_plannedactions.MedicalPractice_RefID
    From
      hec_act_plannedactions Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
        hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @ActionTypeID And hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
        hec_act_plannedaction_2_actiontype.IsDeleted = 0
    Where
      hec_act_plannedactions.Patient_RefID = @PatientID And
      hec_act_plannedactions.Tenant_RefID = @TenantID And
      hec_act_plannedactions.IsDeleted = 0
	