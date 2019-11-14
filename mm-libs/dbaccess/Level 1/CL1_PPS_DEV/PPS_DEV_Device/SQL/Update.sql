UPDATE 
	pps_dev_devices
SET 
	DeviceType_RefID=@DeviceType_RefID,
	DeviceDisplayName=@DeviceDisplayName,
	DeviceName_DictID=@DeviceName,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_DEV_DeviceID = @PPS_DEV_DeviceID