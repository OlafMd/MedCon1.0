INSERT INTO 
	tms_pro_projectmember_targetworkloads
	(
		TMS_PRO_ProjectMember_TargetWorkloadID,
		RequiredWorkTime_in_sec,
		Valid_From,
		Valid_Through,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@TMS_PRO_ProjectMember_TargetWorkloadID,
		@RequiredWorkTime_in_sec,
		@Valid_From,
		@Valid_Through,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)