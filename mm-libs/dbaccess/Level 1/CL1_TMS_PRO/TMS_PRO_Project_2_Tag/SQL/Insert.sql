INSERT INTO 
	tms_pro_project_2_tag
	(
		AssignmentID,
		Tag_RefID,
		Project_RefID,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@Tag_RefID,
		@Project_RefID,
		@Tenant_RefID,
		@IsDeleted
	)