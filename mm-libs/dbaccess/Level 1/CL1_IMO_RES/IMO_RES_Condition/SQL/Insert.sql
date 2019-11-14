INSERT INTO 
	imo_res_conditions
	(
		IMO_RES_ConditionID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@IMO_RES_ConditionID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)