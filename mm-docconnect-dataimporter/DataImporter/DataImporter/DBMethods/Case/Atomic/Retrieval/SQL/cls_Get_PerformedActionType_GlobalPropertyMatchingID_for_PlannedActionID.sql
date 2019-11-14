
Select
  hec_act_actiontype.GlobalPropertyMatchingID
From
  hec_act_actiontype Inner Join
  hec_act_performedaction_2_actiontype
    On hec_act_performedaction_2_actiontype.HEC_ACT_ActionType_RefID =
    hec_act_actiontype.HEC_ACT_ActionTypeID And
    hec_act_performedaction_2_actiontype.Tenant_RefID = @TenantID And
    hec_act_performedaction_2_actiontype.IsDeleted = 0 Inner Join
  hec_act_plannedactions
    On hec_act_plannedactions.IfPerformed_PerformedAction_RefID =
    hec_act_performedaction_2_actiontype.HEC_ACT_PerformedAction_RefID
    And hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0 And
    hec_act_plannedactions.HEC_ACT_PlannedActionID = @PlannedActionID
Where
  hec_act_actiontype.Tenant_RefID = @TenantID And
  hec_act_actiontype.IsDeleted = 0
	