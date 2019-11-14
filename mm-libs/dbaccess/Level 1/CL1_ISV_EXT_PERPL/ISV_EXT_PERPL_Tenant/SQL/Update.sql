UPDATE 
	isv_ext_perpl_tenants
SET 
	Tenant_RefID=@Tenant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted
WHERE 
	ISV_EXT_PERPL_TenantID = @ISV_EXT_PERPL_TenantID