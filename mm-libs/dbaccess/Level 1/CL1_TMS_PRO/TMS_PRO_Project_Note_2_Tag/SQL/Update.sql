UPDATE 
	tms_pro_project_note_2_tag
SET 
	Tag_RefID=@Tag_RefID,
	Project_Note_RefID=@Project_Note_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID