
    Select
      hec_cas_case_relevantplannedactions.PlannedAction_RefID as action_id
    From
      hec_cas_case_relevantplannedactions Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
        hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @ActionTypeID And hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
        hec_act_plannedaction_2_actiontype.IsDeleted = 0
    Where
      hec_cas_case_relevantplannedactions.Case_RefID = @CaseID And
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantplannedactions.IsDeleted = 0
    Order by 
      hec_cas_case_relevantplannedactions.Creation_Timestamp
	