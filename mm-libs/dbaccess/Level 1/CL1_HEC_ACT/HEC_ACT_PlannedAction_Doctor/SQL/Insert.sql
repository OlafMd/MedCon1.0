INSERT INTO 
	hec_act_plannedaction_doctors
	(
		HEC_ACT_PlannedAction_DoctorID,
		HEC_ACT_PlannedAction_RefID,
		HEC_Doctor_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_ACT_PlannedAction_DoctorID,
		@HEC_ACT_PlannedAction_RefID,
		@HEC_Doctor_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)