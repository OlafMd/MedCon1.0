UPDATE 
	pps_dev_device_instance_availabilities
SET 
	DeviceInstance_RefID=@DeviceInstance_RefID,
	CMN_CAL_AVA_Availability_RefID=@CMN_CAL_AVA_Availability_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_DEV_Device_Instance_AvailabilityID = @PPS_DEV_Device_Instance_AvailabilityID