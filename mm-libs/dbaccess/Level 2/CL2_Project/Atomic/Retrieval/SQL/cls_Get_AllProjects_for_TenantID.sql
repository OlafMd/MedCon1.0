
	Select
	  tms_pro_projects.TMS_PRO_ProjectID,
	  tms_pro_projects.Name_DictID,
	  tms_pro_projects.Description_DictID,
	  tms_pro_projects.IsArchived,
	  tms_pro_projects.IsDeleted,
	  tms_pro_projects.Tenant_RefID
	From
	  tms_pro_projects
	Where
	  tms_pro_projects.IsDeleted = 0 And
	  tms_pro_projects.Tenant_RefID = @TenantID
  