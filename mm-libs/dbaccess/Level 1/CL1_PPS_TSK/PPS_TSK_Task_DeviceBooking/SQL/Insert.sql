INSERT INTO 
	pps_tsk_task_devicebookings
	(
		PPS_TSK_Task_DeviceBookingID,
		PPS_TSK_Task_RefID,
		PPS_DEV_Device_Instance_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@PPS_TSK_Task_DeviceBookingID,
		@PPS_TSK_Task_RefID,
		@PPS_DEV_Device_Instance_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)