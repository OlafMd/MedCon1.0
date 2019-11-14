    
    Select
      hec_doctors.HEC_DoctorID as doctor_id,
      count(hec_act_plannedactions.HEC_ACT_PlannedActionID) as count
    From
      hec_act_plannedactions Inner Join
      hec_doctors
        On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID = hec_doctors.BusinessParticipant_RefID And
        hec_doctors.Tenant_RefID = @TenantID And
        hec_doctors.IsDeleted = 0
    Where
	    hec_act_plannedactions.HEC_ACT_PlannedActionID = @ActionIDs And
	    hec_act_plannedactions.Tenant_RefID = @TenantID And
	    hec_act_plannedactions.IsDeleted = 0
    Group by 
      hec_doctors.HEC_DoctorID
	