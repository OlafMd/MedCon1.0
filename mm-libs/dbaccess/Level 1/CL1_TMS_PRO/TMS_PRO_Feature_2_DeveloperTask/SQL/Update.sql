UPDATE 
	tms_pro_feature_2_developertask
SET 
	Feature_RefID=@Feature_RefID,
	DeveloperTask_RefID=@DeveloperTask_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID