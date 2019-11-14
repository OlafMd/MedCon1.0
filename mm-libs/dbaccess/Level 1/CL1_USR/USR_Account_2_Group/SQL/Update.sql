UPDATE 
	usr_account_2_group
SET 
	USR_Account_RefID=@USR_Account_RefID,
	USR_Group_RefID=@USR_Group_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID