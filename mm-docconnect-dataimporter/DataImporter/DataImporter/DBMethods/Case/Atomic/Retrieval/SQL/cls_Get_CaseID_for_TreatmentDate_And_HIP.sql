
    Select
      hec_cas_cases.HEC_CAS_CaseID As case_id
    From
      hec_cas_cases Inner Join
      hec_cas_case_relevantperformedactions On hec_cas_cases.HEC_CAS_CaseID =
        hec_cas_case_relevantperformedactions.Case_RefID And
        hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
        hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
        hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
        hec_act_plannedactions.Tenant_RefID = @TenantID And
        hec_act_plannedactions.IsDeleted = 0 And
        hec_act_plannedactions.PlannedFor_Date = @TreatmentDate Inner Join
      hec_patient_healthinsurances On hec_cas_cases.Patient_RefID =
        hec_patient_healthinsurances.Patient_RefID And
        hec_patient_healthinsurances.Tenant_RefID = @TenantID And
        hec_patient_healthinsurances.IsDeleted = 0 And
        hec_patient_healthinsurances.HealthInsurance_Number = @HIPNumber Inner Join
      hec_act_performedaction_diagnosisupdates
        On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID =
        hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
        hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdate_localizations
        On
        hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID = hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
        hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code = @Localization And
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
        hec_act_performedaction_diagnosisupdates.IsDeleted = 0
    Where
      hec_cas_cases.Tenant_RefID = @TenantID And
      hec_cas_cases.IsDeleted = 0 
	