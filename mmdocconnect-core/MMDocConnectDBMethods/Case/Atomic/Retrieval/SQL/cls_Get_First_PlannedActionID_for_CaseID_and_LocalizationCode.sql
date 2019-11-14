
    Select
      hec_cas_case_relevantplannedactions.PlannedAction_RefID As action_id
    From
      hec_cas_case_relevantplannedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And hec_act_plannedactions.Tenant_RefID =
        @TenantID And hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdates
        On hec_act_plannedactions.IfPerformed_PerformedAction_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdate_localizations
        On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
        hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
	      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code = @LocalizationCode And 
	      hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And
	      hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
        hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @PlannedActionTypeID And 
        hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And 
        hec_act_plannedaction_2_actiontype.IsDeleted = 0
    Where 
      hec_cas_case_relevantplannedactions.Case_RefID = @CaseID And
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantplannedactions.IsDeleted = 0
    Order By
      hec_cas_case_relevantplannedactions.Creation_Timestamp
    Limit 1
	