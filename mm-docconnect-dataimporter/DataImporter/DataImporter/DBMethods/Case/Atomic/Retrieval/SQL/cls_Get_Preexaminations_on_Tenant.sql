
    Select
      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code,
      hec_act_plannedactions.Patient_RefID,
      hec_act_plannedactions.HEC_ACT_PlannedActionID,
      hec_act_plannedactions.PlannedFor_Date,
      hec_cas_case_billcodes.HEC_CAS_Case_BillCodeID,
      bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID,
      hec_cas_case_relevantperformedactions.Case_RefID,
      hec_cas_case_relevantperformedactions.HEC_CAS_Case_RelevantPerformedActionID,
      hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID,
      hec_act_performedaction_diagnosisupdate_localizations.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID,
      hec_act_plannedactions.IfPerformed_PerformedAction_RefID,
      hec_cas_cases.CaseNumber,
      hec_doctors.HEC_DoctorID,
      bil_billposition_transmitionstatuses.IsActive,
      bil_billposition_transmitionstatuses.TransmitionCode
    From
      hec_cas_case_relevantperformedactions Inner Join
      hec_act_performedaction_diagnosisupdates
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdate_localizations
        On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
        hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
        hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
      Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
        hec_act_plannedactions.Tenant_RefID = @TenantID And hec_act_plannedactions.IsDeleted = 0 Inner Join
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
        bil_billposition_transmitionstatuses.TransmitionStatusKey = 'preexamination' And bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
        bil_billposition_transmitionstatuses.IsDeleted = 0 Inner Join
      hec_cas_cases
        On hec_cas_case_relevantperformedactions.Case_RefID = hec_cas_cases.HEC_CAS_CaseID And hec_cas_cases.Tenant_RefID = @TenantID And hec_cas_cases.IsDeleted =
        0 Inner Join
      hec_doctors
        On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID = hec_doctors.BusinessParticipant_RefID And hec_doctors.Tenant_RefID = @TenantID And
        hec_doctors.IsDeleted = 0
    Where
      hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantperformedactions.IsDeleted = 0
	