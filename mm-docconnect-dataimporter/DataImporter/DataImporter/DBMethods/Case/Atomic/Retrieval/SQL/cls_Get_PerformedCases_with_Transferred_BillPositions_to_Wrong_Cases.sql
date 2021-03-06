
    Select
      hec_cas_cases.HEC_CAS_CaseID,
      hec_cas_cases.Creation_Timestamp
    From
      hec_cas_cases Inner Join
      hec_cas_case_relevantperformedactions
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID And
        hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
        hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
        hec_act_plannedactions.IsPerformed = 1 And
        hec_act_plannedactions.Tenant_RefID = @TenantID And
        hec_act_plannedactions.IsDeleted = 0 Left Join
      hec_cas_case_billcodes
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_billcodes.HEC_CAS_Case_RefID And hec_cas_case_billcodes.Tenant_RefID = @TenantID And
        hec_cas_case_billcodes.IsDeleted = 0 Inner Join
      hec_cas_case_universalpropertyvalue
        On hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID = hec_cas_cases.HEC_CAS_CaseID And
        hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID Inner Join
      hec_cas_case_universalproperties
        On hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID = hec_cas_case_universalproperties.HEC_CAS_Case_UniversalPropertyID And
        hec_cas_case_universalproperties.GlobalPropertyMatchingID = @AutoGeneratedIvomGpmID And hec_cas_case_universalproperties.Tenant_RefID = @TenantID And
        hec_cas_case_universalproperties.IsDeleted = 0
    Where
      hec_cas_cases.Tenant_RefID = @TenantID And
      hec_cas_cases.IsDeleted = 0 And
      hec_cas_case_billcodes.HEC_CAS_Case_BillCodeID Is Null
	