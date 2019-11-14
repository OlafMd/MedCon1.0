UPDATE 
	usr_group_2_functionlevelrightgroup
SET 
	USR_Account_FunctionLevelRightGroup_RefID=@USR_Account_FunctionLevelRightGroup_RefID,
	USR_Group_RefID=@USR_Group_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID