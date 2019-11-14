
    Select
      hec_cas_case_relevantperformedactions.Case_RefID As CaseID,
      hec_doctors.HEC_DoctorID As DoctorID,
      hec_act_plannedactions.HEC_ACT_PlannedActionID As TreatmentPlannedActionID,
      hec_act_plannedactions.PlannedFor_Date As TreatmentDate,
      hec_act_plannedactions.IsPerformed,
      hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID As DrugID,
      hec_act_plannedaction_potentialprocedure_requiredproduct.BoundTo_HealthcareProcurementOrderPosition_RefID As OrderID
    From
      hec_cas_case_relevantperformedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
        hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
        hec_act_plannedactions.Tenant_RefID = @TenantID And
        hec_act_plannedactions.IsCancelled = 0 And
        hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_doctors
        On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
        hec_doctors.BusinessParticipant_RefID And
        hec_doctors.Tenant_RefID = @TenantID And
        hec_doctors.IsDeleted = 0 Inner Join
      hec_act_plannedaction_potentialprocedures
        On hec_act_plannedactions.HEC_ACT_PlannedActionID =
        hec_act_plannedaction_potentialprocedures.PlannedAction_RefID And
        hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID And
        hec_act_plannedaction_potentialprocedures.IsDeleted = 0 Inner Join
      hec_act_plannedaction_potentialprocedure_requiredproduct
        On
        hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID = hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID And
        hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID And
        hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0
    Where 
      hec_cas_case_relevantperformedactions.Case_RefID = @CaseIDs And
      hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantperformedactions.IsDeleted = 0
	