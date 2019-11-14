INSERT INTO 
	acc_dun_dunning_models
	(
		ACC_DUN_Dunning_ModelID,
		IsDefaultCustomerModel,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ACC_DUN_Dunning_ModelID,
		@IsDefaultCustomerModel,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)