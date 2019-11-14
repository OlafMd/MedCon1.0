UPDATE 
	acc_dun_dunning_model_2_customer
SET 
	ACC_DUN_DunningModel_RefID=@ACC_DUN_DunningModel_RefID,
	CMN_BPT_CTM_Customer_RefID=@CMN_BPT_CTM_Customer_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID