
	Select
  tms_pro_projects.Name_DictID,
  tms_pro_projects.Description_DictID,
  tms_pro_projects.TMS_PRO_ProjectID,
  tms_pro_projects.IsArchived,
  tms_pro_project_2_projectgroup.AssignmentID,
  tms_pro_project_2_projectgroup.TMS_PRO_Project_Group_RefID,
  tms_pro_projects.Default_CostCenter_RefID
From
  tms_pro_projects Left Join
  tms_pro_project_2_projectgroup On tms_pro_projects.TMS_PRO_ProjectID =
    tms_pro_project_2_projectgroup.TMS_PRO_Project_RefID And
    tms_pro_project_2_projectgroup.IsDeleted = 0
Where
  tms_pro_projects.Tenant_RefID = @TenantID And
  tms_pro_projects.IsDeleted = 0
  