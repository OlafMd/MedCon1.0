
	Select
	  tms_pro_developertasks.PercentageComplete,
	  tms_pro_projects.TMS_PRO_ProjectID,
	  tms_pro_developertasks.TMS_PRO_DeveloperTaskID,
	  tms_pro_projects.IsDeleted,
	  tms_pro_projects.IsArchived
	From
	  tms_pro_projects Inner Join
	  tms_pro_developertasks On tms_pro_projects.TMS_PRO_ProjectID =
	    tms_pro_developertasks.Project_RefID
	Where
	  tms_pro_projects.IsDeleted = 0 And
	  tms_pro_projects.Tenant_RefID = @TenantID
  