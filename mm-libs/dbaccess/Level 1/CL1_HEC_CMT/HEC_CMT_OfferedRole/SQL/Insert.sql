INSERT INTO 
	hec_cmt_offeredroles
	(
		HEC_CMT_OfferedRoleID,
		CommunityRoleITL,
		GlobalPropertyMatchingID,
		Community_RefID,
		RoleName_DictID,
		IsUniqueOverAllGroupsPerSubscriber,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_CMT_OfferedRoleID,
		@CommunityRoleITL,
		@GlobalPropertyMatchingID,
		@Community_RefID,
		@RoleName,
		@IsUniqueOverAllGroupsPerSubscriber,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)