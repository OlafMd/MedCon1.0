UPDATE 
	pps_dev_device_instances
SET 
	Device_RefID=@Device_RefID,
	DeviceSerialNumber=@DeviceSerialNumber,
	DeviceInventoryNumber=@DeviceInventoryNumber,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_DEV_Device_InstanceID = @PPS_DEV_Device_InstanceID