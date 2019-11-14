UPDATE 
	tms_pro_project_targetworkloads
SET 
	RequiredWorktime_in_sec=@RequiredWorktime_in_sec,
	Valid_From=@Valid_From,
	Valid_Through=@Valid_Through,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	TMS_PRO_Project_TargetWorkloadID = @TMS_PRO_Project_TargetWorkloadID