UPDATE 
	pps_tsk_task_devicebookings
SET 
	PPS_TSK_Task_RefID=@PPS_TSK_Task_RefID,
	PPS_DEV_Device_Instance_RefID=@PPS_DEV_Device_Instance_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_TSK_Task_DeviceBookingID = @PPS_TSK_Task_DeviceBookingID