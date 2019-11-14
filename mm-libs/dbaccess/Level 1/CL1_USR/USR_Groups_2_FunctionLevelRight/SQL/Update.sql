UPDATE 
	usr_groups_2_functionlevelright
SET 
	USR_Account_FunctionLevelRight_RefID=@USR_Account_FunctionLevelRight_RefID,
	USR_Group_RefID=@USR_Group_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID