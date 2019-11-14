
    Select
      hec_cas_case_relevantplannedactions.Case_RefID as case_id
    From
      hec_act_plannedactions Inner Join
      hec_cas_case_relevantplannedactions
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_cas_case_relevantplannedactions.PlannedAction_RefID And
        hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID 
    Where
      hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID = @BptIDs And
      hec_act_plannedactions.Patient_RefID = @PatientID And
      hec_act_plannedactions.Tenant_RefID = @TenantID And
      hec_act_plannedactions.IsDeleted = 0
	