UPDATE 
	tms_pro_businesstask_2_feature
SET 
	BusinessTask_RefID=@BusinessTask_RefID,
	Feature_RefID=@Feature_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID