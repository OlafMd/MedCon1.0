UPDATE 
	hec_cmt_communitygroups
SET 
	HealthcareCommunityGroupITL=@HealthcareCommunityGroupITL,
	Community_RefID=@Community_RefID,
	CommunityGroup_Name_DictID=@CommunityGroup_Name,
	CommunityGroup_Description_DictID=@CommunityGroup_Description,
	CommunityGroupCode=@CommunityGroupCode,
	IsPrivate=@IsPrivate,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CMT_CommunityGroupID = @HEC_CMT_CommunityGroupID