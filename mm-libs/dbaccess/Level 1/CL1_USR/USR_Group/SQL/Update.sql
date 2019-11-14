UPDATE 
	usr_groups
SET 
	Group_Name_DictID=@Group_Name,
	Group_Description_DictID=@Group_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	USR_GroupID = @USR_GroupID