INSERT INTO 
	tms_pro_project_targetworkloads
	(
		TMS_PRO_Project_TargetWorkloadID,
		RequiredWorktime_in_sec,
		Valid_From,
		Valid_Through,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@TMS_PRO_Project_TargetWorkloadID,
		@RequiredWorktime_in_sec,
		@Valid_From,
		@Valid_Through,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)