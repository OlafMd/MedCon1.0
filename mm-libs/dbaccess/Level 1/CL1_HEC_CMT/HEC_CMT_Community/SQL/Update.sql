UPDATE 
	hec_cmt_communities
SET 
	HealthcareCommunityITL=@HealthcareCommunityITL,
	CommunityName_DictID=@CommunityName,
	CommunityServicesBaseURL=@CommunityServicesBaseURL,
	IsCommunityOperatedByThisTenant=@IsCommunityOperatedByThisTenant,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CMT_CommunityID = @HEC_CMT_CommunityID