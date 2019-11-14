UPDATE 
	usr_not_notifications
SET 
	NotificationSubscription_RefID=@NotificationSubscription_RefID,
	R_Account_RefID=@R_Account_RefID,
	R_NotificationKey=@R_NotificationKey,
	Notification_Link=@Notification_Link,
	Notification_Text=@Notification_Text,
	IsViewed=@IsViewed,
	ViewedOn_Date=@ViewedOn_Date,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	USR_NOT_NotificationID = @USR_NOT_NotificationID