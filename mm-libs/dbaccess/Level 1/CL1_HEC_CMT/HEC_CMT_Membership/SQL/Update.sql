UPDATE 
	hec_cmt_memberships
SET 
	CommunityMembershipITL=@CommunityMembershipITL,
	Community_RefID=@Community_RefID,
	BusinessParticipant_RefID=@BusinessParticipant_RefID,
	MembershipType_RefID=@MembershipType_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CMT_MembershipID = @HEC_CMT_MembershipID