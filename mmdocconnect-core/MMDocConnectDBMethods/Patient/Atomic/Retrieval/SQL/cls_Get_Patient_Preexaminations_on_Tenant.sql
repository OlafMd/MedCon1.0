
Select
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As Localization,
  hec_cas_cases.Patient_RefID As PatientID,
  bil_billposition_transmitionstatuses.TransmittedOnDate As PreexaminationDate
From
  hec_cas_cases
  Inner Join hec_cas_case_relevantperformedactions On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID And
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And hec_cas_case_relevantperformedactions.IsDeleted = 0
  Inner Join hec_act_performedaction_diagnosisupdates On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And 
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0
  Inner Join hec_act_performedaction_diagnosisupdate_localizations On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
    hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
    hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
  Inner Join hec_cas_case_billcodes On hec_cas_case_relevantperformedactions.Case_RefID = hec_cas_case_billcodes.HEC_CAS_Case_RefID And
    hec_cas_case_billcodes.Tenant_RefID = @TenantID And hec_cas_case_billcodes.IsDeleted = 0
  Inner Join hec_bil_billposition_billcodes On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And hec_bil_billposition_billcodes.IsDeleted = 0
  Inner Join hec_bil_billpositions On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And
    hec_bil_billpositions.Tenant_RefID = @TenantID And 
    hec_bil_billpositions.IsDeleted = 0
  Inner Join bil_billposition_transmitionstatuses On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID And 
    bil_billposition_transmitionstatuses.IsDeleted = 0 And bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And 
    bil_billposition_transmitionstatuses.TransmitionStatusKey = 'preexamination' And bil_billposition_transmitionstatuses.IsActive = 1 And
    (bil_billposition_transmitionstatuses.TransmitionCode != 8 And bil_billposition_transmitionstatuses.TransmitionCode != 11)
Where
  hec_cas_cases.IsDeleted = 0 And
  hec_cas_cases.Tenant_RefID = @TenantID
Group By
  hec_cas_cases.HEC_CAS_CaseID  
  