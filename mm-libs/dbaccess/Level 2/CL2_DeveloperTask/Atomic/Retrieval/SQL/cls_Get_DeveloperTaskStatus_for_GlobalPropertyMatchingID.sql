
	Select
	  tms_pro_developertask_statuses.TMS_PRO_DeveloperTask_StatusID,
	  tms_pro_developertask_statuses.Label_DictID,
	  tms_pro_developertask_statuses.IsPersistent
	From
	  tms_pro_developertask_statuses
	Where
	  tms_pro_developertask_statuses.IsDeleted = 0 And
	  tms_pro_developertask_statuses.Tenant_RefID = @TenantID And
	  tms_pro_developertask_statuses.GlobalPropertyMatchingID =
	  @GlobalPropertyMatchingID
  