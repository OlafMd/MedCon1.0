UPDATE 
	hec_cmt_opt_privatecommunitygroup_visibility
SET 
	Member_RefID=@Member_RefID,
	CommunityGroup_RefID=@CommunityGroup_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CMT_OPT_CommunityGroupVisibilityID = @HEC_CMT_OPT_CommunityGroupVisibilityID