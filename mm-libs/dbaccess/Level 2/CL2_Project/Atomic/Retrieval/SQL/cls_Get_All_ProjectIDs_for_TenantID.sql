
Select
  tms_pro_projects.TMS_PRO_ProjectID
From
  tms_pro_projects
Where
  tms_pro_projects.IsDeleted = 0 And
  tms_pro_projects.Tenant_RefID = @TenantID
  