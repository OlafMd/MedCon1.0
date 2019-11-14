UPDATE 
	tms_pro_project_groups
SET 
	ProjectGroup_Parent_RefID=@ProjectGroup_Parent_RefID,
	ProjectGroup_Label=@ProjectGroup_Label,
	ProjectGroup_Name_DictID=@ProjectGroup_Name,
	ProjectGroup_Description_DictID=@ProjectGroup_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_Project_GroupID = @TMS_PRO_Project_GroupID