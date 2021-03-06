INSERT INTO 
	tms_pro_project_groups
	(
		TMS_PRO_Project_GroupID,
		ProjectGroup_Parent_RefID,
		ProjectGroup_Label,
		ProjectGroup_Name_DictID,
		ProjectGroup_Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@TMS_PRO_Project_GroupID,
		@ProjectGroup_Parent_RefID,
		@ProjectGroup_Label,
		@ProjectGroup_Name,
		@ProjectGroup_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)