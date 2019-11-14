
	Select
	  tms_pro_businesstaskpackages.TMS_PRO_BusinessTaskPackageID,
	  tms_pro_businesstaskpackages.Parent_RefID,
	  tms_pro_businesstaskpackages.Project_RefID,
	  tms_pro_businesstaskpackages.Label
	From
	  tms_pro_businesstaskpackages Inner Join
	  tms_pro_projects On tms_pro_projects.TMS_PRO_ProjectID =
	    tms_pro_businesstaskpackages.Project_RefID
	Where
	  tms_pro_projects.TMS_PRO_ProjectID = @ProjectID And
	  tms_pro_projects.IsDeleted = 0 And
	  tms_pro_projects.Tenant_RefID = @TenantID And
	  tms_pro_projects.IsArchived = 0 And
	  tms_pro_businesstaskpackages.IsDeleted = 0
  