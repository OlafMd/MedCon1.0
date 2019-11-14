UPDATE 
	cmn_unit_groups
SET 
	PrimaryUnit_RefID=@PrimaryUnit_RefID,
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Name_DictID=@Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_Unit_GroupID = @CMN_Unit_GroupID