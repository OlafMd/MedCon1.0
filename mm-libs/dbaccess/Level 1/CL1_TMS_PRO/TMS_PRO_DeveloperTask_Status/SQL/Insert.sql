INSERT INTO 
	tms_pro_developertask_statuses
	(
		TMS_PRO_DeveloperTask_StatusID,
		Label_DictID,
		Description_DictID,
		IsPersistent,
		GlobalPropertyMatchingID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@TMS_PRO_DeveloperTask_StatusID,
		@Label,
		@Description,
		@IsPersistent,
		@GlobalPropertyMatchingID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)