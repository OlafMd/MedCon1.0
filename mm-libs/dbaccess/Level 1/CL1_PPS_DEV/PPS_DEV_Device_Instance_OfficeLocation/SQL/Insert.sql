INSERT INTO 
	pps_dev_device_instance_officelocations
	(
		PPS_DEV_Device_Instance_OfficeLocationID,
		IsCurrentLocation,
		DeviceInstance_RefID,
		CMN_STR_Office_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@PPS_DEV_Device_Instance_OfficeLocationID,
		@IsCurrentLocation,
		@DeviceInstance_RefID,
		@CMN_STR_Office_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)