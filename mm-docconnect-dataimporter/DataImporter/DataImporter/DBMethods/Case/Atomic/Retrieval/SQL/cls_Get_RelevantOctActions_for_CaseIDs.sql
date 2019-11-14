
    Select
      hec_cas_case_relevantplannedactions.Case_RefID as case_id
    From
      hec_cas_case_relevantplannedactions Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And    
  	    hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @OctPlannedActionTypeID And
  	    hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
  	    hec_act_plannedaction_2_actiontype.IsDeleted = 0
    Where
	    hec_cas_case_relevantplannedactions.Case_RefID = @CaseIDs And
	    hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
	    hec_cas_case_relevantplannedactions.IsDeleted = 0
	