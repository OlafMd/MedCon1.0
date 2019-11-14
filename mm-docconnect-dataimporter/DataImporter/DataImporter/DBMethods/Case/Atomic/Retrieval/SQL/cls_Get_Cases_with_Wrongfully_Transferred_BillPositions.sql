
Select
  hec_cas_cases.HEC_CAS_CaseID,
  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID,
  hec_cas_case_billcodes.HEC_CAS_Case_BillCodeID,
  hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID,
  hec_bil_billpositions.HEC_BIL_BillPositionID,
  hec_bil_billpositions.Ext_BIL_BillPosition_RefID,
  hec_cas_case_billcodes.Creation_Timestamp
From
  hec_cas_cases Inner Join
  hec_cas_case_relevantperformedactions
    On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID And hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
  hec_act_plannedactions
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
    hec_act_plannedactions.IsPerformed = 0 And hec_act_plannedactions.Tenant_RefID = @TenantID And hec_act_plannedactions.IsDeleted = 0 Inner Join
  hec_cas_case_billcodes
    On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_billcodes.HEC_CAS_Case_RefID And hec_cas_case_billcodes.Tenant_RefID = @TenantID And
    hec_cas_case_billcodes.IsDeleted = 0 Inner Join
  hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And hec_bil_billposition_billcodes.IsDeleted = 0 Inner Join
  hec_bil_billpositions
    On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And hec_bil_billpositions.Tenant_RefID = @TenantID And
    hec_bil_billpositions.IsDeleted = 0 Inner Join
  bil_billposition_transmitionstatuses
    On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.TransmitionCode = 13 And bil_billposition_transmitionstatuses.TransmitionStatusKey = 'treatment' And
    hec_bil_billpositions.Tenant_RefID = @TenantID And hec_bil_billpositions.IsDeleted = 0
Where
  hec_cas_cases.Tenant_RefID = @TenantID And
  hec_cas_cases.IsDeleted = 0
	