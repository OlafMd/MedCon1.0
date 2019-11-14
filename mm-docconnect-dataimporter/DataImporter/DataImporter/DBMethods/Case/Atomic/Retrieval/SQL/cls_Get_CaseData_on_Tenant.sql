
    Select
      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code,
      hec_act_plannedactions.Patient_RefID,
      hec_act_plannedactions.PlannedFor_Date,
      hec_act_plannedactions.IsPerformed,
      hec_cas_case_relevantperformedactions.Case_RefID,
      hec_cas_cases.CaseNumber,
      hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID,
      hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID
    From
      hec_cas_case_relevantperformedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
        hec_act_plannedactions.Tenant_RefID = @TenantID And hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdates
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdate_localizations
        On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
        hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
        hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
      Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
        hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And hec_act_plannedaction_2_actiontype.IsDeleted = 0 Inner Join
      hec_act_actiontype
        On hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = hec_act_actiontype.HEC_ACT_ActionTypeID And hec_act_actiontype.GlobalPropertyMatchingID =
        'mm.docconect.doc.app.planned.action.treatment' And hec_act_actiontype.Tenant_RefID = @TenantID And hec_act_actiontype.IsDeleted = 0 Inner Join
      hec_cas_cases
        On hec_cas_case_relevantperformedactions.Case_RefID = hec_cas_cases.HEC_CAS_CaseID And hec_cas_cases.Tenant_RefID = @TenantID And hec_cas_cases.IsDeleted =
        0 Inner Join
      hec_act_plannedaction_potentialprocedures
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_potentialprocedures.PlannedAction_RefID And
        hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID And
        hec_act_plannedaction_potentialprocedures.IsDeleted = 0 Inner Join
      hec_act_plannedaction_potentialprocedure_requiredproduct
        On hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID =
        hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID And
        hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID And
        hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0
    Where
      hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantperformedactions.IsDeleted = 0
	