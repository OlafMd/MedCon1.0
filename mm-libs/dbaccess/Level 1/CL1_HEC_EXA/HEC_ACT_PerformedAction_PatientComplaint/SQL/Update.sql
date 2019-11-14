UPDATE 
	hec_act_performedaction_patientcomplaints
SET 
	Action_RefID=@Action_RefID,
	ComplaintText=@ComplaintText,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ACT_PerformedAction_PatientComplaintID = @HEC_ACT_PerformedAction_PatientComplaintID