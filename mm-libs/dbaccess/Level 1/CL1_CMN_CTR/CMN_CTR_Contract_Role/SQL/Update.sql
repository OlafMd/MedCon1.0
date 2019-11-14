UPDATE 
	cmn_ctr_contract_roles
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	RoleName=@RoleName,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_CTR_Contract_RoleID = @CMN_CTR_Contract_RoleID