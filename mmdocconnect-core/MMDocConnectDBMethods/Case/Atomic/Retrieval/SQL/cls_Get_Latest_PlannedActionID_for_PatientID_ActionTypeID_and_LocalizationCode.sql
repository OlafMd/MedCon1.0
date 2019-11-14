
    Select
      hec_cas_case_relevantplannedactions.PlannedAction_RefID As PlannedActionID,
      hec_cas_case_relevantplannedactions.Case_RefID as CaseID,
      hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID as DoctorBptID,
      hec_act_plannedactions1.PlannedFor_Date as OpDate
    From
      hec_cas_case_relevantplannedactions Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
        hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @ActionTypeID And hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
        hec_act_plannedaction_2_actiontype.IsDeleted = 0 Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And
        hec_act_plannedactions.Patient_RefID = @PatientID And
        hec_act_plannedactions.IsPerformed = 0 And
        hec_act_plannedactions.IsCancelled = 0 And 
        hec_act_plannedactions.Tenant_RefID = @TenantID And 
        hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_cas_case_relevantperformedactions
        On hec_cas_case_relevantplannedactions.Case_RefID = hec_cas_case_relevantperformedactions.Case_RefID And
        hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
        hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdates
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
        hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdate_localizations
        On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
        hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
 	      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code = @LocalizationCode And
 	      hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And
 	      hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 Inner Join
      hec_act_plannedactions hec_act_plannedactions1
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions1.IfPlannedFollowup_PreviousAction_RefID And
  	    hec_act_plannedactions1.IsCancelled = 0 And
  	    hec_act_plannedactions1.Tenant_RefID = @TenantID And
  	    hec_act_plannedactions1.IsDeleted = 0
    Where
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantplannedactions.IsDeleted = 0 
    Order By
      hec_cas_case_relevantplannedactions.Creation_Timestamp desc
	