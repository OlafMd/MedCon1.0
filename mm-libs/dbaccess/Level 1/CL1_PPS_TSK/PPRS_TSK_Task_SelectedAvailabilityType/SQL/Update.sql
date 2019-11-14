UPDATE 
	pprs_tsk_task_selectedavailabilitytypes
SET 
	PPS_TSK_Task_RefID=@PPS_TSK_Task_RefID,
	CMN_CAL_AVA_Availability_Type_RefID=@CMN_CAL_AVA_Availability_Type_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPRS_TSK_Task_SelectedAvailabilityTypeID = @PPRS_TSK_Task_SelectedAvailabilityTypeID