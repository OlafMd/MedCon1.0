UPDATE 
	pps_tsk_task_staffbookings
SET 
	PPS_TSK_Task_RefID=@PPS_TSK_Task_RefID,
	CMN_BPT_EMP_Employee_RefID=@CMN_BPT_EMP_Employee_RefID,
	CreatedFrom_TaskTemplate_RequiredStaff_RefID=@CreatedFrom_TaskTemplate_RequiredStaff_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_TSK_Task_StaffBookingsID = @PPS_TSK_Task_StaffBookingsID