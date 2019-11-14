
	Select
	  tms_pro_project_status.TMS_PRO_Project_StatusID AS ProjectStatus_ID,
	  tms_pro_project_status.Label_DictID,
    tms_pro_project_status.GlobalPropertyMatchingID AS ProjectStatus_GlobalPropertyMatchingID
	From
	  tms_pro_project_status
	Where
	  tms_pro_project_status.IsDeleted = 0 And
	  tms_pro_project_status.Tenant_RefID = @TenantID
  