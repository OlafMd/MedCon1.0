UPDATE 
	pps_tsk_tasks
SET 
	TaskIdentifier=@TaskIdentifier,
	DisplayName=@DisplayName,
	PlannedStartDate=@PlannedStartDate,
	PlannedDuration_in_sec=@PlannedDuration_in_sec,
	InstantiatedFrom_TaskTemplate_RefID=@InstantiatedFrom_TaskTemplate_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_TSK_TaskID = @PPS_TSK_TaskID