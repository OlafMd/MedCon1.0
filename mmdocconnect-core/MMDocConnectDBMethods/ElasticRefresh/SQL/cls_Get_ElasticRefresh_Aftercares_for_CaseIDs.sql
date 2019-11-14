
    Select
      hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID As performed_by_bpt_id,
      hec_act_plannedactions.IsCancelled As cancelled,
      hec_act_plannedactions.HEC_ACT_PlannedActionID As action_id,
      hec_cas_case_relevantplannedactions.Case_RefID As case_id,
      hec_act_plannedactions.IsPerformed as performed
    From
      hec_cas_case_relevantplannedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And
        hec_act_plannedactions.Tenant_RefID = @TenantID And hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
        hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @AftercarePlannedActionTypeID And hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID
        And hec_act_plannedaction_2_actiontype.IsDeleted = 0
    Where
      hec_cas_case_relevantplannedactions.Case_RefID = @CaseIDs And
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID
    Order by
      hec_cas_case_relevantplannedactions.Creation_Timestamp desc
	