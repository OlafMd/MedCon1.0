    
    Select
      hec_cas_case_relevantplannedactions.PlannedAction_RefID as action_id,
      hec_cas_case_relevantplannedactions.Case_RefID as case_id
    From
      hec_cas_case_relevantplannedactions
    Where
      hec_cas_case_relevantplannedactions.PlannedAction_RefID = @ActionIDs And
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantplannedactions.IsDeleted = 0
	