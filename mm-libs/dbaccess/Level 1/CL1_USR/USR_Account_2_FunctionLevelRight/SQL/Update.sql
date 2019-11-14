UPDATE 
	usr_account_2_functionlevelright
SET 
	FunctionLevelRight_RefID=@FunctionLevelRight_RefID,
	Account_RefID=@Account_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID