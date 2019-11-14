UPDATE 
	tms_pro_projectmember_targetworkloads
SET 
	RequiredWorkTime_in_sec=@RequiredWorkTime_in_sec,
	Valid_From=@Valid_From,
	Valid_Through=@Valid_Through,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	TMS_PRO_ProjectMember_TargetWorkloadID = @TMS_PRO_ProjectMember_TargetWorkloadID