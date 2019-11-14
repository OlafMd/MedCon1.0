
	Select
	  tms_pro_project_status.TMS_PRO_Project_StatusID,
	  tms_pro_project_status.Label_DictID
	From
	  tms_pro_project_status
	Where
	  tms_pro_project_status.GlobalPropertyMatchingID = @GlobalPropertyMatchingID
	  And
	  tms_pro_project_status.Tenant_RefID = @TenantID And
	  tms_pro_project_status.IsDeleted = 0
  