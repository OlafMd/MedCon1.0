UPDATE 
	tms_accountprofile_notificationconfiguration
SET 
	AccountProfile_RefID=@AccountProfile_RefID,
	IsEveryNotification=@IsEveryNotification,
	IsDaily=@IsDaily,
	IsWeekly=@IsWeekly,
	IsDisabled=@IsDisabled,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_SubscriptionNotificationFrequencyID = @TMS_SubscriptionNotificationFrequencyID