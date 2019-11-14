UPDATE 
	ocl_ordercollective_members
SET 
	OrderCollective_RefID=@OrderCollective_RefID,
	OrderCollectiveMemberITL=@OrderCollectiveMemberITL,
	IsOrderCollectiveLead=@IsOrderCollectiveLead,
	BusinessParticipant_RefID=@BusinessParticipant_RefID,
	MemberSince=@MemberSince,
	EndOfMembership=@EndOfMembership,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	OCL_OrderCollective_MemberID = @OCL_OrderCollective_MemberID