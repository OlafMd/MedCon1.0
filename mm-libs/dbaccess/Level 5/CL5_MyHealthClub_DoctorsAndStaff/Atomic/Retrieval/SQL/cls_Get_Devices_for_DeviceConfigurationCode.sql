
Select
  usr_devices.USR_DeviceID,
  usr_devices.DeviceName,
  usr_devices.IsBanned,
  usr_devices.DeviceVendor
From
  usr_devices Inner Join
  usr_device_activityhistory On usr_device_activityhistory.Device_RefID =
    usr_devices.USR_DeviceID And usr_device_activityhistory.Tenant_RefID =
    @TenantID And usr_device_activityhistory.IsDeleted = 0 Inner Join
  usr_device_configurationcodes
    On
    usr_device_activityhistory.WasDevice_Configured_WithConfigurationCode_RefID
    = usr_device_configurationcodes.USR_Device_ConfigurationCodeID And
    usr_device_configurationcodes.Tenant_RefID = @TenantID And
    usr_device_configurationcodes.IsDeleted = 0
Where
  usr_devices.Tenant_RefID = @TenantID And
  usr_devices.IsDeleted = 0 And
  usr_device_configurationcodes.DeviceConfigurationCode =
  @DeviceConfigurationCode
  