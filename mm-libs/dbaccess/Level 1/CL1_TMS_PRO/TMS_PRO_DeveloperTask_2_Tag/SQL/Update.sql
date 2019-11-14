UPDATE 
	tms_pro_developertask_2_tag
SET 
	Tag_RefID=@Tag_RefID,
	DeveloperTask_RefID=@DeveloperTask_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID