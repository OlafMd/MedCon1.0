INSERT INTO 
	hec_cmt_offeredroles_2_groupsubscription
	(
		AssignmentID,
		HEC_CMT_OfferedRole_RefID,
		HEC_CMT_GroupSubscription_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@AssignmentID,
		@HEC_CMT_OfferedRole_RefID,
		@HEC_CMT_GroupSubscription_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)