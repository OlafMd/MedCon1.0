
    Select
      hec_cas_cases.CaseNumber As case_number,
      hec_cas_cases.Creation_Timestamp as creation_date,
      hec_cas_cases.HEC_CAS_CaseID As case_id,
      hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID As op_doctor_bpt_id,
      hec_cas_cases.Patient_RefID As patient_id,
      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As localization,
      hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID As diagnose_id,
      hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID as drug_id,      
      hec_act_plannedactions.PlannedFor_Date as op_date
    From
      hec_cas_cases Inner Join
      hec_cas_case_relevantperformedactions
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID And hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
        hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
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
      hec_cas_cases.Patient_RefID = @PatientIDs And
      hec_cas_cases.Tenant_RefID = @TenantID And
      hec_cas_cases.IsDeleted = 0
	