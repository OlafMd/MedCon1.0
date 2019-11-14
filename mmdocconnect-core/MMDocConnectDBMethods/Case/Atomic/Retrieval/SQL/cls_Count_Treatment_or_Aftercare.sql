
    Select
      Count(hec_act_plannedactions.HEC_ACT_PlannedActionID) as NumberOfActions
    From
      hec_act_plannedactions Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_act_plannedactions.HEC_ACT_PlannedActionID =
        hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID and
        hec_act_plannedaction_2_actiontype.IsDeleted=0 and 
        hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID Inner Join
      hec_act_actiontype
        On hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID =
        hec_act_actiontype.HEC_ACT_ActionTypeID And
        hec_act_actiontype.Tenant_RefID = @TenantID And
        hec_act_actiontype.IsDeleted = 0 And 
        hec_act_actiontype.GlobalPropertyMatchingID =
        @typeOfAction
    Where 
      hec_act_plannedactions.Tenant_RefID = @TenantID and 
      hec_act_plannedactions.IsDeleted=0 And
      hec_act_plannedactions.IsCancelled = 0 And
      hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID !=
      x'00000000000000000000000000000000'
	