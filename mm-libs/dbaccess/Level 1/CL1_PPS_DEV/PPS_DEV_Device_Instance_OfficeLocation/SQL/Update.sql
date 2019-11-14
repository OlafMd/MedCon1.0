UPDATE 
	pps_dev_device_instance_officelocations
SET 
	IsCurrentLocation=@IsCurrentLocation,
	DeviceInstance_RefID=@DeviceInstance_RefID,
	CMN_STR_Office_RefID=@CMN_STR_Office_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_DEV_Device_Instance_OfficeLocationID = @PPS_DEV_Device_Instance_OfficeLocationID