UPDATE 
	cmn_trl_trustrelationrequests
SET 
	RequestFor_TrustRelationType_RefID=@RequestFor_TrustRelationType_RefID,
	Requesting_BusinessParticipant_RefID=@Requesting_BusinessParticipant_RefID,
	TrustRelationRequestITL=@TrustRelationRequestITL,
	Title=@Title,
	Comment=@Comment,
	IsApproved=@IsApproved,
	IsRejected=@IsRejected,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_TRL_TrustRelationRequestID = @CMN_TRL_TrustRelationRequestID