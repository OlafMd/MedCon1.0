UPDATE 
	hec_act_performedaction_doctors
SET 
	HEC_ACT_PerformedAction_RefID=@HEC_ACT_PerformedAction_RefID,
	HEC_Doctor_RefID=@HEC_Doctor_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ACT_PerformedAction_DoctorID = @HEC_ACT_PerformedAction_DoctorID