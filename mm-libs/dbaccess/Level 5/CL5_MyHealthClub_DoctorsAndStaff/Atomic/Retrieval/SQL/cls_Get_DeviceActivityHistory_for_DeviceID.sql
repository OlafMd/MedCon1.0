
Select
  usr_devices.DeviceName,
  usr_accounts.Username,
  usr_device_activityhistory.ActivityComment,
  usr_device_activityhistory.Device_RefID,
  usr_device_activityhistory.USR_Device_ActivityHistoryID,
  usr_devices.DeviceVendor,
  usr_device_activityhistory.Creation_Timestamp,
  usr_device_activityhistory.AccountComment
From
  usr_device_activityhistory Inner Join
  usr_devices On usr_device_activityhistory.Device_RefID =
    usr_devices.USR_DeviceID And usr_devices.Tenant_RefID = @TenantID And
    usr_devices.IsDeleted = 0 Left Join
  usr_accounts On usr_device_activityhistory.Performing_Account_RefID =
    usr_accounts.USR_AccountID And usr_accounts.Tenant_RefID = @TenantID And
    usr_accounts.IsDeleted = 0
Where
  usr_device_activityhistory.Device_RefID = @DeviceID And
  usr_device_activityhistory.Tenant_RefID = @TenantID And
  usr_device_activityhistory.IsDeleted = 0
  