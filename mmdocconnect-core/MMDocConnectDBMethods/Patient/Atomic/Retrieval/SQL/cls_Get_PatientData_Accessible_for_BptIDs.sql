
    Select
      hec_act_plannedactions.HEC_ACT_PlannedActionID
    From
      hec_act_plannedactions
    Where
      hec_act_plannedactions.Patient_RefID = @PatientID And
      hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID = @BptIDs And
      hec_act_plannedactions.Tenant_RefID = @TenantID And
      hec_act_plannedactions.IsDeleted = 0
    Limit 1
	