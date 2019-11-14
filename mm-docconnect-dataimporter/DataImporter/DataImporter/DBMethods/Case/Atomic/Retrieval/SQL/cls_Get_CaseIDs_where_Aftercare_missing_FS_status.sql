
Select
  hec_cas_cases.CaseNumber,
  hec_cas_cases.HEC_CAS_CaseID
From
  hec_cas_cases Inner Join
  hec_cas_case_relevantplannedactions
    On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantplannedactions.Case_RefID And hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantplannedactions.IsDeleted = 0 Inner Join
  hec_act_plannedactions
    On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And hec_act_plannedactions.IsPerformed = 1 And
    hec_act_plannedactions.IsCancelled = 0 And hec_act_plannedactions.Tenant_RefID = @TenantID And hec_act_plannedactions.IsDeleted = 0 Inner Join
  hec_act_plannedaction_2_actiontype
    On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
    hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And hec_act_plannedaction_2_actiontype.IsDeleted = 0 Inner Join
  hec_act_actiontype
    On hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = hec_act_actiontype.HEC_ACT_ActionTypeID And hec_act_actiontype.GlobalPropertyMatchingID
    Like '%after%' And hec_act_actiontype.Tenant_RefID = @TenantID And hec_act_actiontype.IsDeleted = 0
Where
  hec_cas_cases.HEC_CAS_CaseID In (Select
    hec_cas_case_billcodes.HEC_CAS_Case_RefID
  From
    hec_cas_case_billcodes Inner Join
    hec_bil_billposition_billcodes
      On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
      hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And hec_bil_billposition_billcodes.IsDeleted = 0 Inner Join
    hec_bil_billpositions
      On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And hec_bil_billpositions.Tenant_RefID = @TenantID And
      hec_bil_billpositions.IsDeleted = 0 Inner Join
    bil_billposition_transmitionstatuses
      On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID And
      bil_billposition_transmitionstatuses.IsActive = 1 And bil_billposition_transmitionstatuses.TransmitionStatusKey = 'aftercare' And
      bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And bil_billposition_transmitionstatuses.IsDeleted = 0
  Where
    hec_cas_case_billcodes.Tenant_RefID = @TenantID And
    hec_cas_case_billcodes.IsDeleted = 0
  Group By
    hec_cas_case_billcodes.HEC_CAS_Case_RefID
  Having
    count(*) < 2)
Group By
  hec_cas_cases.HEC_CAS_CaseID
Having
  count(*) > 1
	