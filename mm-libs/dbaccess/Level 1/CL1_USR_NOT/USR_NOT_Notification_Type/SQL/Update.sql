UPDATE 
	usr_not_notification_types
SET 
	NotificationType_Label=@NotificationType_Label,
	NotificationType_Key=@NotificationType_Key,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	USR_NOT_Notification_TypeID = @USR_NOT_Notification_TypeID