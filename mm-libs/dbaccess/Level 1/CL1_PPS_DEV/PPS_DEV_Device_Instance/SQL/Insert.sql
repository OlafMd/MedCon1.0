INSERT INTO 
	pps_dev_device_instances
	(
		PPS_DEV_Device_InstanceID,
		Device_RefID,
		DeviceSerialNumber,
		DeviceInventoryNumber,
		Comment,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@PPS_DEV_Device_InstanceID,
		@Device_RefID,
		@DeviceSerialNumber,
		@DeviceInventoryNumber,
		@Comment,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)