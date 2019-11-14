
   Select
  hec_act_plannedactions.Patient_RefID As patient_id,
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As localization,
  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID As
  fs_status_id,
  hec_act_plannedactions1.PlannedFor_Date As op_date,
  hec_act_performedactions.IfPerfomed_DateOfAction As oct_date
From
  hec_cas_case_relevantplannedactions Inner Join
  hec_act_plannedactions
    On hec_cas_case_relevantplannedactions.PlannedAction_RefID =
    hec_act_plannedactions.HEC_ACT_PlannedActionID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0 Inner Join
  hec_act_plannedaction_2_actiontype
    On hec_act_plannedactions.HEC_ACT_PlannedActionID =
    hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
    hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID =
    @PlannedOctActionTypeID And hec_act_plannedaction_2_actiontype.Tenant_RefID
    = @TenantID And hec_act_plannedaction_2_actiontype.IsDeleted = 0 Inner Join
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
    hec_bil_billpositions.Tenant_RefID = @TenantID And
    hec_bil_billpositions.IsDeleted = 0 Inner Join
  bil_billposition_transmitionstatuses
    On hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
    bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.TransmitionStatusKey = 'oct' And
    bil_billposition_transmitionstatuses.IsActive = 1 And
    bil_billposition_transmitionstatuses.TransmitionCode Not In (8, 11, 17) And
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
    bil_billposition_transmitionstatuses.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdates
    On hec_act_plannedactions.IfPerformed_PerformedAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdate_localizations
    On
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID = hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 Inner Join
  hec_cas_case_relevantperformedactions
    On hec_cas_case_relevantplannedactions.Case_RefID =
    hec_cas_case_relevantperformedactions.Case_RefID And
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
  hec_act_plannedactions hec_act_plannedactions1
    On hec_act_plannedactions1.IfPlannedFollowup_PreviousAction_RefID =
    hec_cas_case_relevantperformedactions.PerformedAction_RefID And
    hec_act_plannedactions1.Tenant_RefID = @TenantID And
    hec_act_plannedactions1.IsDeleted = 0 Inner Join
  hec_act_performedactions
    On hec_act_plannedactions.IfPerformed_PerformedAction_RefID =
    hec_act_performedactions.HEC_ACT_PerformedActionID And
    hec_act_performedactions.Tenant_RefID = @TenantID And
    hec_act_performedactions.IsDeleted = 0
Where
  hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
  hec_cas_case_relevantplannedactions.IsDeleted = 0
Group By
  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID
Order By
  Null
	