
    Select
      hec_cas_case_relevantplannedactions.PlannedAction_RefID As planned_action_id,
      hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID As to_be_performed_by_bpt_id,
      hec_act_performedactions.IfPerfomed_DateOfAction As performed_on_date
    From
      hec_cas_case_relevantplannedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And
        hec_act_plannedactions.Tenant_RefID = @TenantID And 
        hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
        hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
        hec_act_plannedaction_2_actiontype.IsDeleted = 0 Inner Join
      hec_act_actiontype
        On hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = hec_act_actiontype.HEC_ACT_ActionTypeID And
 	      hec_act_actiontype.GlobalPropertyMatchingID = @ActionTypeGpmID And
 	      hec_act_actiontype.Tenant_RefID = @TenantID And hec_act_actiontype.IsDeleted = 0 Left Join
      hec_act_performedactions
        On hec_act_plannedactions.IfPerformed_PerformedAction_RefID = hec_act_performedactions.HEC_ACT_PerformedActionID And
        hec_act_performedactions.Tenant_RefID = @TenantID And
        hec_act_performedactions.IsDeleted = 0 
    Where
      hec_cas_case_relevantplannedactions.Case_RefID = @CaseID And
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantplannedactions.IsDeleted = 0 
    Order by  hec_act_plannedactions.Creation_Timestamp desc 
    Limit 1
	