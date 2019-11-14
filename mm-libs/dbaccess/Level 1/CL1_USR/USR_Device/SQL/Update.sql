UPDATE 
	usr_devices
SET 
	DeviceName=@DeviceName,
	MACAddress=@MACAddress,
	IMEI=@IMEI,
	SerialNumber=@SerialNumber,
	SecurityVerificationToken=@SecurityVerificationToken,
	DeviceSecurityCode=@DeviceSecurityCode,
	ExclusivelyUsableWith_Account_RefID=@ExclusivelyUsableWith_Account_RefID,
	IsBanned=@IsBanned,
	DeviceVendor=@DeviceVendor,
	DeviceOperatingSystem=@DeviceOperatingSystem,
	DeviceOperatingSystem_Version=@DeviceOperatingSystem_Version,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	USR_DeviceID = @USR_DeviceID