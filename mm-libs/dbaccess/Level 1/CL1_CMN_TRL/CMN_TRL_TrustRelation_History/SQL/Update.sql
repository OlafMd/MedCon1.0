UPDATE 
	cmn_trl_trustrelation_history
SET 
	TrustRelation_RefID=@TrustRelation_RefID,
	StatusType=@StatusType,
	StatusChangeReason=@StatusChangeReason,
	Performed_ByAccount_RefID=@Performed_ByAccount_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_TRL_TrustRelation_HistoryID = @CMN_TRL_TrustRelation_HistoryID