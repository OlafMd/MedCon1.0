UPDATE 
	hec_cmt_groupsubscriptions
SET 
	Membership_RefID=@Membership_RefID,
	CommunityGroup_RefID=@CommunityGroup_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CMT_GroupSubscriptionID = @HEC_CMT_GroupSubscriptionID