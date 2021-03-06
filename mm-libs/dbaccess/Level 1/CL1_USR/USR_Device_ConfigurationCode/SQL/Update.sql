UPDATE 
	usr_device_configurationcodes
SET 
	DeviceConfigurationCode=@DeviceConfigurationCode,
	DateOfExpiry=@DateOfExpiry,
	IsMultipleUsagesAllowed=@IsMultipleUsagesAllowed,
	Exclusively_UsableBy_Device_RefID=@Exclusively_UsableBy_Device_RefID,
	Preconfigured_ApplicationBaseURL=@Preconfigured_ApplicationBaseURL,
	Preconfigured_OtherConfigurationInformation=@Preconfigured_OtherConfigurationInformation,
	Preconfigured_PrimaryUser_RefID=@Preconfigured_PrimaryUser_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	USR_Device_ConfigurationCodeID = @USR_Device_ConfigurationCodeID