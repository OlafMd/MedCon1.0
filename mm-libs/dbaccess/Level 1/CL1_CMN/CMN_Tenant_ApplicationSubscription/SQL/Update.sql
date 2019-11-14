UPDATE 
	cmn_tenant_applicationsubscriptions
SET 
	Tenant_RefID=@Tenant_RefID,
	Application_RefID=@Application_RefID,
	UpdatedOn=@UpdatedOn,
	IsDisabled=@IsDisabled,
	IfDisabled_Reason=@IfDisabled_Reason,
	Configuration=@Configuration,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted
WHERE 
	CMN_Tenant_ApplicationSubscriptionID = @CMN_Tenant_ApplicationSubscriptionID