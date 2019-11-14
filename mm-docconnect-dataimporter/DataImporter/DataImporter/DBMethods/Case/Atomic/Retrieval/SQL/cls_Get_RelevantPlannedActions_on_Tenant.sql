
    Select
      hec_act_plannedactions.Patient_RefID As patient_id,
      hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID As performing_bpt_id,
      hec_act_plannedactions.IsCancelled as is_cancelled
    From
      hec_cas_case_relevantplannedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And hec_act_plannedactions.Tenant_RefID =
        @TenantID And hec_act_plannedactions.IsDeleted = 0
    Where
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantplannedactions.IsDeleted = 0
	