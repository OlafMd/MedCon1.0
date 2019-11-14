
    Select
      hec_cas_cases.CaseNumber,
      hec_cas_cases.HEC_CAS_CaseID,
      hec_act_plannedactions.HEC_ACT_PlannedActionID
    From
      hec_cas_cases Inner Join
      hec_cas_case_relevantplannedactions
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantplannedactions.Case_RefID Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And hec_act_plannedactions.IsPerformed = 1 And
        hec_act_plannedactions.Tenant_RefID = @TenantID And hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID Inner Join
      hec_act_actiontype
        On hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = hec_act_actiontype.HEC_ACT_ActionTypeID And hec_act_actiontype.GlobalPropertyMatchingID =
        'mm.docconect.doc.app.planned.action.aftercare' And hec_act_actiontype.Tenant_RefID = @TenantID And hec_act_actiontype.IsDeleted = 0
    Where
      hec_cas_cases.Tenant_RefID = @TenantID And
      hec_cas_cases.IsDeleted = 1
	