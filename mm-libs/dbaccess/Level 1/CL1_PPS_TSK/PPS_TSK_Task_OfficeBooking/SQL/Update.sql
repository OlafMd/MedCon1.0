UPDATE 
	pps_tsk_task_officebookings
SET 
	PPS_TSK_Task_RefID=@PPS_TSK_Task_RefID,
	CMN_STR_Office_RefID=@CMN_STR_Office_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_TSK_Task_OfficeBookingID = @PPS_TSK_Task_OfficeBookingID