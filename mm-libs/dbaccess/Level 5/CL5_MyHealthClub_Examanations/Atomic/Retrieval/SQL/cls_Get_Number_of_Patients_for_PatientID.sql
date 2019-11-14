
	Select
	  COUNT(hec_act_performedactions.HEC_ACT_PerformedActionID) as number_of_treatments
	From
	  hec_act_performedactions
	Where
	  hec_act_performedactions.Tenant_RefID = @TenantID And
	  hec_act_performedactions.IsDeleted = 0 And
	  hec_act_performedactions.Patient_RefID = @PatientID
	Group By
	  hec_act_performedactions.HEC_ACT_PerformedActionID,
	  hec_act_performedactions.Patient_RefID
  