INSERT INTO 
	usr_not_notification_subscriptions
	(
		USR_NOT_Notification_SubscriptionID,
		Account_RefID,
		NotificationType_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@USR_NOT_Notification_SubscriptionID,
		@Account_RefID,
		@NotificationType_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)