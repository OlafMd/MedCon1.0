UPDATE 
	pps_tsk_task_requiredstaff
SET 
	TaskTemplate_RefID=@TaskTemplate_RefID,
	StaffQuantity=@StaffQuantity,
	Required_Employee_RefID=@Required_Employee_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_TSK_Task_RequiredStaffID = @PPS_TSK_Task_RequiredStaffID