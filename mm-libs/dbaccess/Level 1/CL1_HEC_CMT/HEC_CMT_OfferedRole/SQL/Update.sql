UPDATE 
	hec_cmt_offeredroles
SET 
	CommunityRoleITL=@CommunityRoleITL,
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Community_RefID=@Community_RefID,
	RoleName_DictID=@RoleName,
	IsUniqueOverAllGroupsPerSubscriber=@IsUniqueOverAllGroupsPerSubscriber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CMT_OfferedRoleID = @HEC_CMT_OfferedRoleID