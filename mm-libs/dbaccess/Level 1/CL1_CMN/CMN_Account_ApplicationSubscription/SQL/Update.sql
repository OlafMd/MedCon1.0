UPDATE 
	cmn_account_applicationsubscriptions
SET 
	Application_RefID=@Application_RefID,
	Account_RefID=@Account_RefID,
	UpdatedOn=@UpdatedOn,
	IsDisabled=@IsDisabled,
	IfDisabled_Reason=@IfDisabled_Reason,
	Configuration=@Configuration,
	Tenant_RefID=@Tenant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted
WHERE 
	CMN_Account_ApplicationSubscriptionID = @CMN_Account_ApplicationSubscriptionID