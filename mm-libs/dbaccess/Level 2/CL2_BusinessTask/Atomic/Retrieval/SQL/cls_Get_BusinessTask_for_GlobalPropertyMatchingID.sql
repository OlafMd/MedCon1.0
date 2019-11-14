
	Select
	  tms_pro_businesstask_status.TMS_PRO_BusinessTask_StatusID,
	  tms_pro_businesstask_status.Label_DictID,
	  tms_pro_businesstask_status.IsPersistent
	From
	  tms_pro_businesstask_status
	Where
	  tms_pro_businesstask_status.IsDeleted = 0 And
	  tms_pro_businesstask_status.Tenant_RefID = @TenantID And
	  tms_pro_businesstask_status.GlobalPropertyMatchingID =
	  @GlobalPropertyMatchingID
  