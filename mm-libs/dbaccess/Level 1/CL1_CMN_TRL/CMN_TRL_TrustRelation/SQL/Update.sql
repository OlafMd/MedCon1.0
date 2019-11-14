UPDATE 
	cmn_trl_trustrelation
SET 
	CMN_TRL_TrustRelation_Type_RefID=@CMN_TRL_TrustRelation_Type_RefID,
	CMN_BPT_BusinessParticpant_RefID=@CMN_BPT_BusinessParticpant_RefID,
	CreatedFrom_TrustRelationRequest_RefID=@CreatedFrom_TrustRelationRequest_RefID,
	IsPaused=@IsPaused,
	IsValid=@IsValid,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_TRL_TrustRelationID = @CMN_TRL_TrustRelationID