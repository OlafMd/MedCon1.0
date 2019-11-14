
    Select
      hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID As DiagnoseID,
      hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID As DrugID,
      hec_cas_cases.HEC_CAS_CaseID as CaseID
    From
      hec_cas_cases
      Inner Join hec_cas_case_relevantperformedactions On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID
      Inner Join hec_act_performedaction_diagnosisupdates On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
        hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID
      Inner Join hec_act_plannedactions On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID
      Inner Join hec_act_plannedaction_potentialprocedures On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_potentialprocedures.PlannedAction_RefID
      Inner Join hec_act_plannedaction_potentialprocedure_requiredproduct On hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID =
        hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID
    Where
      hec_cas_cases.Tenant_RefID = @TenantID And
      hec_cas_cases.IsDeleted = 0
    Group by
    hec_cas_cases.HEC_CAS_CaseID
	