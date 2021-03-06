INSERT INTO 
	cmn_trl_trustrelation
	(
		CMN_TRL_TrustRelationID,
		CMN_TRL_TrustRelation_Type_RefID,
		CMN_BPT_BusinessParticpant_RefID,
		CreatedFrom_TrustRelationRequest_RefID,
		IsPaused,
		IsValid,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_TRL_TrustRelationID,
		@CMN_TRL_TrustRelation_Type_RefID,
		@CMN_BPT_BusinessParticpant_RefID,
		@CreatedFrom_TrustRelationRequest_RefID,
		@IsPaused,
		@IsValid,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)