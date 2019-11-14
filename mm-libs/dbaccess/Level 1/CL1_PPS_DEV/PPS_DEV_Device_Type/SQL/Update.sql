UPDATE 
	pps_dev_device_types
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	DeviceTypeDisplayName=@DeviceTypeDisplayName,
	DeviceTypeName_DictID=@DeviceTypeName,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_DEV_Device_TypeID = @PPS_DEV_Device_TypeID