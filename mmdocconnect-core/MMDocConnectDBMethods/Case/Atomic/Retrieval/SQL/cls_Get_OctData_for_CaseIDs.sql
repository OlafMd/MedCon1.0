
    Select
      hec_act_plannedactions.HEC_ACT_PlannedActionID As id,
      hec_doctors.HEC_DoctorID As doctor_id,
      hec_act_performedactions.IfPerfomed_DateOfAction As date,
      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code as localization
    From
      hec_cas_case_relevantplannedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And hec_act_plannedactions.Tenant_RefID =
        @TenantID And hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
        hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @ActionTypeID And hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
        hec_act_plannedaction_2_actiontype.IsDeleted = 0 Inner Join
      hec_act_performedactions
        On hec_act_plannedactions.IfPerformed_PerformedAction_RefID = hec_act_performedactions.HEC_ACT_PerformedActionID And hec_act_performedactions.Tenant_RefID =
        @TenantID And hec_act_performedactions.IsDeleted = 0 Inner Join
      hec_doctors
        On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID = hec_doctors.BusinessParticipant_RefID And hec_doctors.Tenant_RefID = @TenantID And
        hec_doctors.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdates
        On hec_act_performedactions.HEC_ACT_PerformedActionID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
        hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdate_localizations
        On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
        hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
        hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And
        hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
    Where
      hec_cas_case_relevantplannedactions.Case_RefID = @CaseIDs And
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantplannedactions.IsDeleted = 0
    Order by
      hec_cas_case_relevantplannedactions.Creation_Timestamp
	