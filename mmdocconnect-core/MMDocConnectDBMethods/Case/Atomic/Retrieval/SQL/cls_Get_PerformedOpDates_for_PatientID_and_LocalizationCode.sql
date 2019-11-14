
    Select
      hec_act_plannedactions.PlannedFor_Date As treatment_date,
      1 As is_op,
      hec_act_plannedactions.Creation_Timestamp As creation_timestamp,
      hec_cas_case_relevantperformedactions.Case_RefID as case_id
    From
      hec_act_plannedactions Inner Join
      hec_cas_case_relevantperformedactions
        On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID = hec_cas_case_relevantperformedactions.PerformedAction_RefID And
        hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdates
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdate_localizations
        On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
        hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
        hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code = @LocalizationCode And
        hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
      Inner Join
      hec_cas_case_billcodes
        On hec_cas_case_relevantperformedactions.Case_RefID = hec_cas_case_billcodes.HEC_CAS_Case_RefID And hec_cas_case_billcodes.Tenant_RefID = @TenantID And
        hec_cas_case_billcodes.IsDeleted = 0 Inner Join
      hec_bil_billposition_billcodes
        On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
        hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And hec_bil_billposition_billcodes.IsDeleted = 0 Inner Join
      hec_bil_billpositions
        On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And hec_bil_billpositions.Tenant_RefID = @TenantID And
        hec_bil_billpositions.IsDeleted = 0 Inner Join
      bil_billposition_transmitionstatuses
        On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID And
        bil_billposition_transmitionstatuses.TransmitionStatusKey = 'treatment' And bil_billposition_transmitionstatuses.IsActive = 1 And
        bil_billposition_transmitionstatuses.TransmitionCode Not In (8, 11, 17) And bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
        bil_billposition_transmitionstatuses.IsDeleted = 0
    Where
      hec_act_plannedactions.Patient_RefID = @PatientID And
      hec_act_plannedactions.IsPerformed = 1 And
      hec_act_plannedactions.IsCancelled = 0 And
      hec_act_plannedactions.Tenant_RefID = @TenantID And
      hec_act_plannedactions.IsDeleted = 0
    Group by 	
      hec_cas_case_relevantperformedactions.Case_RefID
    Order by 
      hec_act_plannedactions.PlannedFor_Date desc
	