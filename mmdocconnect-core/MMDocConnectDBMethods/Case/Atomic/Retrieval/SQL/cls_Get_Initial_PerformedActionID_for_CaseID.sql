
    Select
      hec_cas_case_relevantperformedactions.PerformedAction_RefID as initial_performed_action_id
    From
      hec_cas_cases Inner Join
      hec_cas_case_relevantperformedactions On hec_cas_cases.HEC_CAS_CaseID =
        hec_cas_case_relevantperformedactions.Case_RefID And
        hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
        hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
      hec_act_performedaction_2_actiontype
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
        hec_act_performedaction_2_actiontype.HEC_ACT_PerformedAction_RefID
        And hec_act_performedaction_2_actiontype.Tenant_RefID = @TenantID And
        hec_act_performedaction_2_actiontype.IsDeleted = 0 Inner Join
      hec_act_actiontype
        On hec_act_performedaction_2_actiontype.HEC_ACT_ActionType_RefID =
        hec_act_actiontype.HEC_ACT_ActionTypeID And
        hec_act_actiontype.GlobalPropertyMatchingID =
        'mm.docconect.doc.app.performed.action.initial' And
        hec_act_actiontype.Tenant_RefID = @TenantID And
        hec_act_actiontype.IsDeleted = 0
    Where
      hec_cas_cases.HEC_CAS_CaseID = @CaseID And
      hec_cas_cases.Tenant_RefID = @TenantID And
      hec_cas_cases.IsDeleted = 0
	