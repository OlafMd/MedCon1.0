
    Select
      hec_cas_case_relevantplannedactions.Case_RefID As CaseID,
      hec_cas_case_relevantplannedactions.PlannedAction_RefID As ActionID,
      hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID As PerformingBptID,
      hec_act_performedactions.IfPerfomed_DateOfAction As PerformedOnDate,
      hec_act_performedactions.Creation_Timestamp as PerformedActionCreationTime,
      hec_act_performedaction_2_actiontype.HEC_ACT_ActionType_RefID As PerformedActionTypeID
    From
      hec_cas_case_relevantplannedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And
        hec_act_plannedactions.IsPerformed = 1 And
        hec_act_plannedactions.IsCancelled = 0 And
        hec_act_plannedactions.Tenant_RefID = @TenantID And
        hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_act_performedactions
        On hec_act_plannedactions.IfPerformed_PerformedAction_RefID = hec_act_performedactions.HEC_ACT_PerformedActionID And
        hec_act_performedactions.Tenant_RefID = @TenantID And
        hec_act_performedactions.IsDeleted = 0 Inner Join
      hec_act_performedaction_2_actiontype
        On hec_act_performedactions.HEC_ACT_PerformedActionID = hec_act_performedaction_2_actiontype.HEC_ACT_PerformedAction_RefID And
        hec_act_performedaction_2_actiontype.Tenant_RefID = @TenantID And
        hec_act_performedaction_2_actiontype.IsDeleted = 0
    Where
      hec_cas_case_relevantplannedactions.PlannedAction_RefID = @ActionIDs And
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantplannedactions.IsDeleted = 0 
	