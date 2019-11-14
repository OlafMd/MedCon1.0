UPDATE 
	pps_tsk_bok_deviceresources
SET 
	AvailableResourceCombination_RefID=@AvailableResourceCombination_RefID,
	PPS_DEV_Device_Instance_RefID=@PPS_DEV_Device_Instance_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	PPS_TSK_BOK_DeviceResourceID = @PPS_TSK_BOK_DeviceResourceID