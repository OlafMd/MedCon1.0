
Select
  hec_act_plannedactions.PlannedFor_Date As TreatmentDate,
  hec_cas_case_relevantperformedactions.Case_RefID As CaseID,
  hec_act_plannedactions.IsPerformed,
  bil_billposition_transmitionstatuses.TransmitionCode As FsStatus,
  hec_cas_cases.IsDeleted,
  hec_cas_case_billcodes.HEC_CAS_Case_BillCodeID as CaseBillCodeID
From
  hec_act_plannedactions Inner Join
  hec_cas_case_relevantperformedactions
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
  hec_cas_cases
    On hec_cas_case_relevantperformedactions.Case_RefID = hec_cas_cases.HEC_CAS_CaseID And 
    hec_cas_cases.Tenant_RefID = @TenantID Inner Join
  hec_act_performedaction_diagnosisupdates
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID Inner Join
  hec_act_performedaction_diagnosisupdate_localizations
    On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
    hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
    hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code = @LocalizationCode And
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
  hec_cas_case_billcodes
    On hec_cas_case_relevantperformedactions.Case_RefID = hec_cas_case_billcodes.HEC_CAS_Case_RefID And
    hec_cas_case_billcodes.Tenant_RefID = @TenantID And
    hec_cas_case_billcodes.IsDeleted = 0 Inner Join
  hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And
    hec_bil_billposition_billcodes.IsDeleted = 0 Inner Join
  hec_bil_billpositions
    On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And
    hec_bil_billpositions.Tenant_RefID = @TenantID And
    hec_bil_billpositions.IsDeleted = 0 Left Join
  bil_billposition_transmitionstatuses
    On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.TransmitionStatusKey = 'treatment' And
    bil_billposition_transmitionstatuses.IsActive = 1 And
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
    bil_billposition_transmitionstatuses.IsDeleted = 0 Inner Join
  hec_bil_potentialcodes
    On hec_bil_billposition_billcodes.PotentialCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And
    hec_bil_potentialcodes.Tenant_RefID = @TenantID And
    hec_bil_potentialcodes.IsDeleted = 0 Inner Join
  hec_bil_potentialcode_catalogs
    On hec_bil_potentialcodes.PotentialCode_Catalog_RefID = hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
    hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID = 'mm.docconnect.gpos.catalog.operation' And
    hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID And
    hec_bil_potentialcode_catalogs.IsDeleted = 0
Where
  hec_act_plannedactions.Patient_RefID = @PatientID And
  hec_act_plannedactions.PlannedFor_Date Between @TreatmentYearStartDate And @TreatmentYearEndDate And
  hec_act_plannedactions.Tenant_RefID = @TenantID And
  hec_act_plannedactions.IsDeleted = 0
Order by
  hec_cas_cases.Creation_Timestamp desc
	