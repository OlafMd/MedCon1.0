    Select
      hec_act_plannedactions.HEC_ACT_PlannedActionID as planned_action_id
    From
      hec_act_plannedactions
    Where
      hec_act_plannedactions.HEC_ACT_PlannedActionID=@PlannedActionIDs And
      hec_act_plannedactions.Tenant_RefID = @TenantID And
      hec_act_plannedactions.IsDeleted = 0 And
      hec_act_plannedactions.IsPerformed = 1