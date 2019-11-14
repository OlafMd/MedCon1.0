
	Select
  tms_pro_project_groups.TMS_PRO_Project_GroupID,
  tms_pro_project_groups.ProjectGroup_Name_DictID,
  tms_pro_project_groups.ProjectGroup_Description_DictID
From
  tms_pro_project_groups
Where
  tms_pro_project_groups.Tenant_RefID = @TenantID And
  tms_pro_project_groups.IsDeleted = 0
  