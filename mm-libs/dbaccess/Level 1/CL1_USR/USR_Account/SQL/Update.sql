UPDATE 
	usr_accounts
SET 
	DefaultLanguage_RefID=@DefaultLanguage_RefID,
	AccountType=@AccountType,
	Username=@Username,
	BusinessParticipant_RefID=@BusinessParticipant_RefID,
	RemoveViewedNotificationAfterDays=@RemoveViewedNotificationAfterDays,
	AccountSignInEmailAddress=@AccountSignInEmailAddress,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	USR_AccountID = @USR_AccountID