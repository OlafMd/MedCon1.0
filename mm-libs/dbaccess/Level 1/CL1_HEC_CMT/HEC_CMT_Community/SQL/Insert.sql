INSERT INTO 
	hec_cmt_communities
	(
		HEC_CMT_CommunityID,
		HealthcareCommunityITL,
		CommunityName_DictID,
		CommunityServicesBaseURL,
		IsCommunityOperatedByThisTenant,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_CMT_CommunityID,
		@HealthcareCommunityITL,
		@CommunityName,
		@CommunityServicesBaseURL,
		@IsCommunityOperatedByThisTenant,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)