
    Select
      hec_act_plannedactions.IsPerformed As is_aftercare_submitted,  
      hec_cas_case_relevantplannedactions.Case_RefID as case_id
    From
      hec_cas_case_relevantplannedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And hec_act_plannedactions.Tenant_RefID =
        @TenantID And hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
  	    hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @AftercarePlannedActionTypeID And
  	    hec_act_plannedactions.Tenant_RefID = @TenantID And
  	    hec_act_plannedactions.IsDeleted = 0
    Where
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantplannedactions.IsDeleted = 0 
	