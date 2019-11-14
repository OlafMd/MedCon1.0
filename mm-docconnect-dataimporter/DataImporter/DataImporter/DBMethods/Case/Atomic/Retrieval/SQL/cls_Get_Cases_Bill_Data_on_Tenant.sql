
      Select
        hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID As DrugID,
        hec_bil_billposition_billcodes.PotentialCode_RefID As GposID,
        hec_cas_cases.HEC_CAS_CaseID As CaseID,
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID as InsuranceToBrokerContractID,
        hec_cas_cases.Patient_RefID As PatientID
      From
        hec_cas_case_billcodes
        Left Join hec_cas_cases On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_billcodes.HEC_CAS_Case_RefID And hec_cas_cases.Tenant_RefID = @TenantID And hec_cas_cases.IsDeleted = 0
        Left Join hec_cas_case_relevantperformedactions On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID And
          hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And hec_cas_case_relevantperformedactions.IsDeleted = 0
        Left Join hec_act_plannedactions On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
          hec_act_plannedactions.Tenant_RefID = @TenantID And hec_act_plannedactions.IsDeleted = 0 And hec_act_plannedactions.IsCancelled = 0
        Left Join hec_act_plannedaction_potentialprocedures On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_potentialprocedures.PlannedAction_RefID And
          hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID And hec_act_plannedaction_potentialprocedures.IsDeleted = 0
        Left Join hec_act_plannedaction_potentialprocedure_requiredproduct On hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID =
          hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID And hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID =
          @TenantID And hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0
        Left Join hec_bil_billposition_billcodes On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID
          And hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And hec_bil_billposition_billcodes.IsDeleted = 0
        Left Join hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes On hec_bil_billposition_billcodes.PotentialCode_RefID =
          hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID And
          hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID ANd
          hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0
      Where
        hec_cas_case_billcodes.Tenant_RefID = @TenantID And
        hec_cas_case_billcodes.IsDeleted = 0
	