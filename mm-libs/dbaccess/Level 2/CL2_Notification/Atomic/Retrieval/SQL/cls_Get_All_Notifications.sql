
Select
  usr_not_notifications.USR_NOT_NotificationID,
  usr_not_notifications.R_NotificationKey,
  usr_not_notifications.NotificationSubscription_RefID,
  usr_not_notifications.Notification_Link,
  usr_not_notifications.Notification_Text
From
  usr_not_notifications
Where
  usr_not_notifications.R_Account_RefID = @AccountID And
  usr_not_notifications.IsDeleted = 0 And
  usr_not_notifications.Tenant_RefID = @TenantID And
  usr_not_notifications.IsViewed = 0
  