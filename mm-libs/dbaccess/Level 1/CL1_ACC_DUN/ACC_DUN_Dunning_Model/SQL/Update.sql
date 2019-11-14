UPDATE 
	acc_dun_dunning_models
SET 
	IsDefaultCustomerModel=@IsDefaultCustomerModel,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_DUN_Dunning_ModelID = @ACC_DUN_Dunning_ModelID