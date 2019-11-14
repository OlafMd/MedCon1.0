UPDATE 
	pps_tsk_task_template_requireddevices
SET 
	TaskTemplate_RefID=@TaskTemplate_RefID,
	DEV_Device_RefID=@DEV_Device_RefID,
	RequiredQuantity=@RequiredQuantity,
	OrderSequence=@OrderSequence,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_TSK_Task_Template_RequiredDeviceID = @PPS_TSK_Task_Template_RequiredDeviceID