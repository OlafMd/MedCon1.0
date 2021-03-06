INSERT INTO 
	pps_tsk_tasks
	(
		PPS_TSK_TaskID,
		TaskIdentifier,
		DisplayName,
		PlannedStartDate,
		PlannedDuration_in_sec,
		InstantiatedFrom_TaskTemplate_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@PPS_TSK_TaskID,
		@TaskIdentifier,
		@DisplayName,
		@PlannedStartDate,
		@PlannedDuration_in_sec,
		@InstantiatedFrom_TaskTemplate_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)