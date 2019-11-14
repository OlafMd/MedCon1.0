
    Select
      hec_act_performedactions.IfPerfomed_DateOfAction as aftercare_performed_date
    From
      hec_act_plannedactions Inner Join
      hec_act_performedactions
        On hec_act_plannedactions.IfPerformed_PerformedAction_RefID =
        hec_act_performedactions.HEC_ACT_PerformedActionID And
        hec_act_performedactions.IsDeleted = 0 And
        hec_act_performedactions.Tenant_RefID = @TenantID
    Where
      hec_act_plannedactions.HEC_ACT_PlannedActionID = @AftercarePlannedActionID And
      hec_act_plannedactions.Tenant_RefID = @TenantID And
      hec_act_plannedactions.IsDeleted = 0 And
      hec_act_plannedactions.IsCancelled = 0
	