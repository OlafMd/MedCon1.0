
	Select
	  usr_device_configurationcodes.USR_Device_ConfigurationCodeID,
	  usr_device_configurationcodes.DeviceConfigurationCode,
	  usr_device_configurationcodes.Preconfigured_PrimaryUser_RefID
	From
	  usr_device_configurationcodes
	Where
	  usr_device_configurationcodes.Tenant_RefID = @TenantID And
	  usr_device_configurationcodes.IsDeleted = 0 And
	  usr_device_configurationcodes.Preconfigured_PrimaryUser_RefID = @AccountRefID
  