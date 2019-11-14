
    Select
      hec_act_actiontype.GlobalPropertyMatchingID
    From
      hec_act_plannedaction_2_actiontype Inner Join
      hec_act_actiontype
        On hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID =
        hec_act_actiontype.HEC_ACT_ActionTypeID And 
        hec_act_actiontype.Tenant_RefID = @TenantID And
        hec_act_actiontype.IsDeleted = 0       
    Where
      hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID = @PlannedActionID And
      hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
      hec_act_plannedaction_2_actiontype.IsDeleted = 0
	