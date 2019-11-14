UPDATE 
	cmn_trl_trustrelation_types
SET 
	TrustRelationTypeITL=@TrustRelationTypeITL,
	TrustRelation_Name_DictID=@TrustRelation_Name,
	TrustRelation_Description_DictID=@TrustRelation_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_TRL_TrustRelation_TypeID = @CMN_TRL_TrustRelation_TypeID