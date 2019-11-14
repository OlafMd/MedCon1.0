
Select
  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID as StatusID,
  hec_cas_cases.HEC_CAS_CaseID as CaseID
From
  bil_billposition_transmitionstatuses
  Inner Join hec_bil_billpositions On bil_billposition_transmitionstatuses.BillPosition_RefID = hec_bil_billpositions.Ext_BIL_BillPosition_RefID
  Inner Join hec_bil_billposition_billcodes On hec_bil_billpositions.HEC_BIL_BillPositionID = hec_bil_billposition_billcodes.BillPosition_RefID
  Inner Join hec_cas_case_billcodes On hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID = hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID
  Inner Join hec_cas_cases On hec_cas_case_billcodes.HEC_CAS_Case_RefID = hec_cas_cases.HEC_CAS_CaseID
Where
  bil_billposition_transmitionstatuses.TransmitionStatusKey = 'aftercare' And
  hec_cas_case_billcodes.HEC_CAS_Case_RefID In (Select
    hec_cas_case_relevantplannedactions.Case_RefID
  From
    hec_cas_cases Inner Join
    hec_cas_case_billcodes On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_billcodes.HEC_CAS_Case_RefID Inner Join
    hec_bil_billposition_billcodes On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID Inner Join
    hec_bil_billpositions On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID Inner Join
    bil_billposition_transmitionstatuses On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID Inner Join
    hec_cas_case_relevantplannedactions On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantplannedactions.Case_RefID Inner Join
    hec_act_plannedactions On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID
  Where
    bil_billposition_transmitionstatuses.IsActive = 1 And
    bil_billposition_transmitionstatuses.TransmitionStatusKey = 'aftercare' And 
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
    Cast(hec_cas_cases.CaseNumber As Unsigned) >= 10000 And
    hec_cas_case_billcodes.IsDeleted = 0
  Group By
    hec_cas_case_relevantplannedactions.Case_RefID
  Having
    Count(Distinct hec_cas_case_relevantplannedactions.HEC_CAS_Case_RelevantPlannedActionID) = 1 And
    Count(bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID) > 1) And
  bil_billposition_transmitionstatuses.IsActive = 1
Order By
  Cast(hec_cas_cases.CaseNumber As Unsigned), 
  bil_billposition_transmitionstatuses.TransmitionCode desc
	