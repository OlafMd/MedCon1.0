
Select
  bil_billposition_transmitionstatuses.TransmitionCode as fs_status,
  hec_cas_case_billcodes.HEC_CAS_Case_RefID as case_id
From
  hec_act_performedactions Inner Join
  hec_act_plannedactions
    On hec_act_performedactions.HEC_ACT_PerformedActionID =
    hec_act_plannedactions.IfPerformed_PerformedAction_RefID And
    hec_act_plannedactions.IsDeleted = 0 And hec_act_plannedactions.Tenant_RefID
    = @TenantID Inner Join
  hec_cas_case_relevantplannedactions
    On hec_act_plannedactions.HEC_ACT_PlannedActionID =
    hec_cas_case_relevantplannedactions.PlannedAction_RefID And
    hec_cas_case_relevantplannedactions.IsDeleted = 0 And
    hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID Inner Join
  hec_act_performedaction_2_actiontype
    On hec_act_performedactions.HEC_ACT_PerformedActionID =
    hec_act_performedaction_2_actiontype.HEC_ACT_PerformedAction_RefID
    And hec_act_performedaction_2_actiontype.Tenant_RefID = @TenantID And
    hec_act_performedaction_2_actiontype.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdates
    On hec_act_performedactions.HEC_ACT_PerformedActionID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdate_localizations
    On
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID = hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And 
    hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 And
    hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And
    hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code = @LocalizationCode Inner Join
  hec_cas_case_billcodes
    On hec_cas_case_relevantplannedactions.Case_RefID =
    hec_cas_case_billcodes.HEC_CAS_Case_RefID And
    hec_cas_case_billcodes.Tenant_RefID = @TenantID And
    hec_cas_case_billcodes.IsDeleted = 0 Inner Join
  hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
    hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And
    hec_bil_billposition_billcodes.IsDeleted = 0 Inner Join
  hec_bil_billpositions
    On hec_bil_billposition_billcodes.BillPosition_RefID =
    hec_bil_billpositions.HEC_BIL_BillPositionID And
    hec_bil_billpositions.IsDeleted = 0 And hec_bil_billpositions.Tenant_RefID =
    @TenantID Inner Join
  bil_billposition_transmitionstatuses
    On hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
    bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.TransmitionStatusKey = 'oct' And
    bil_billposition_transmitionstatuses.IsDeleted = 0 And
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
    bil_billposition_transmitionstatuses.IsActive = 1
Where
  hec_act_performedactions.Patient_RefID = @PatientID And
  hec_act_performedactions.Tenant_RefID = @TenantID And
  hec_act_performedactions.IsDeleted = 0 And
  hec_act_performedactions.IfPerfomed_DateOfAction between @DateFrom AND @DateTo
Group By
  hec_act_performedactions.HEC_ACT_PerformedActionID
Order By
  hec_bil_billpositions.Creation_Timestamp
	