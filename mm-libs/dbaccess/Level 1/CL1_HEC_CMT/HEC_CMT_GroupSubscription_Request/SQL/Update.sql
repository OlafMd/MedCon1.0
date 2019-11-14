UPDATE 
	hec_cmt_groupsubscription_requests
SET 
	Membership_RefID=@Membership_RefID,
	CommunityGroup_RefID=@CommunityGroup_RefID,
	RequestComment=@RequestComment,
	IsRequested=@IsRequested,
	IsRejected=@IsRejected,
	IfRejected_ByMember_RefID=@IfRejected_ByMember_RefID,
	IfRejected_Reason=@IfRejected_Reason,
	IsApproved=@IsApproved,
	IfApproved_GroupSubscription_RefID=@IfApproved_GroupSubscription_RefID,
	IfApproved_ByMember_RefID=@IfApproved_ByMember_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CMT_GroupSubscription_RequestID = @HEC_CMT_GroupSubscription_RequestID