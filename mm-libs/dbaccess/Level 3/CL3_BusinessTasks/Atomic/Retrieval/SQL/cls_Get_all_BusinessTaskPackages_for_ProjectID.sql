
Select
  tms_pro_projects.TMS_PRO_ProjectID,
  tms_pro_businesstaskpackages.Project_RefID,
  tms_pro_businesstaskpackages.Label,
  tms_pro_businesstaskpackages.IsDeleted,
  tms_pro_businesstaskpackages.Parent_RefID,
  tms_pro_businesstaskpackages.TMS_PRO_BusinessTaskPackageID
From
  tms_pro_projects Inner Join
  tms_pro_businesstaskpackages On tms_pro_projects.TMS_PRO_ProjectID =
    tms_pro_businesstaskpackages.Project_RefID
Where
  tms_pro_businesstaskpackages.IsDeleted = 0 and
  tms_pro_businesstaskpackages.Tenant_RefID = @TenantID 
 
  