UPDATE 
	usr_not_notification_subscriptions
SET 
	Account_RefID=@Account_RefID,
	NotificationType_RefID=@NotificationType_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	USR_NOT_Notification_SubscriptionID = @USR_NOT_Notification_SubscriptionID