INSERT INTO 
	isv_ext_perpl_tenants
	(
		ISV_EXT_PERPL_TenantID,
		Tenant_RefID,
		Creation_Timestamp,
		IsDeleted
	)
VALUES 
	(
		@ISV_EXT_PERPL_TenantID,
		@Tenant_RefID,
		@Creation_Timestamp,
		@IsDeleted
	)