UPDATE 
	tms_pro_developertask_involvements
SET 
	ProjectMember_RefID=@ProjectMember_RefID,
	DeveloperTask_RefID=@DeveloperTask_RefID,
	OrderSequence=@OrderSequence,
	IsActive=@IsActive,
	IsArchived=@IsArchived,
	R_InvestedWorkingTime_min=@R_InvestedWorkingTime_min,
	Developer_CompletionTimeEstimation_min=@Developer_CompletionTimeEstimation_min,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_DeveloperTask_InvolvementID = @TMS_PRO_DeveloperTask_InvolvementID