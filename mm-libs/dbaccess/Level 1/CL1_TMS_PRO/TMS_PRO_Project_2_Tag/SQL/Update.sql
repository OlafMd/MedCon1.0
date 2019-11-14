UPDATE 
	tms_pro_project_2_tag
SET 
	Tag_RefID=@Tag_RefID,
	Project_RefID=@Project_RefID,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID