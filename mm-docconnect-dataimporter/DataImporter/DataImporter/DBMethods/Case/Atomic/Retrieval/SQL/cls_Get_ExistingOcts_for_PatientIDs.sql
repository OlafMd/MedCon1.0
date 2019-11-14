
    Select
      hec_act_plannedactions.Patient_RefID As patient_id,
      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As localization
    From
      hec_act_plannedactions Inner Join
      hec_cas_case_relevantplannedactions       
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And 
        hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
        hec_cas_case_relevantplannedactions.IsDeleted = 0  Inner Join
      hec_cas_case_relevantperformedactions
        On hec_cas_case_relevantplannedactions.Case_RefID = hec_cas_case_relevantperformedactions.Case_RefID And hec_cas_case_relevantperformedactions.Tenant_RefID
        = @TenantID And hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdates
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdate_localizations
        On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
        hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
        hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
      Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
  	    hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @OctPlannedActionTypeID And
  	    hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
  	    hec_act_plannedaction_2_actiontype.IsDeleted = 0
    Where      
      hec_act_plannedactions.Patient_RefID = @PatientIDs And 
      hec_act_plannedactions.Tenant_RefID = @TenantID And 
      hec_act_plannedactions.IsDeleted = 0
	