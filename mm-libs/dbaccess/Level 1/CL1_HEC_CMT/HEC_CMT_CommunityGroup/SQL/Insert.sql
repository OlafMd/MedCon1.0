INSERT INTO 
	hec_cmt_communitygroups
	(
		HEC_CMT_CommunityGroupID,
		HealthcareCommunityGroupITL,
		Community_RefID,
		CommunityGroup_Name_DictID,
		CommunityGroup_Description_DictID,
		CommunityGroupCode,
		IsPrivate,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_CMT_CommunityGroupID,
		@HealthcareCommunityGroupITL,
		@Community_RefID,
		@CommunityGroup_Name,
		@CommunityGroup_Description,
		@CommunityGroupCode,
		@IsPrivate,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)