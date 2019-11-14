UPDATE 
	pps_tsk_task_workareabookings
SET 
	PPS_TSK_Task_RefID=@PPS_TSK_Task_RefID,
	CMN_STR_Workarea_RefID=@CMN_STR_Workarea_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_TSK_Task_WorkareaBookingsID = @PPS_TSK_Task_WorkareaBookingsID