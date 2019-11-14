INSERT INTO 
	tms_pro_developertask_types
	(
		TMS_PRO_DeveloperTask_TypeID,
		GlobalPropertyMatchingID,
		Label_DictID,
		Description_DictID,
		IconLocationURL,
		IsPersistent,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@TMS_PRO_DeveloperTask_TypeID,
		@GlobalPropertyMatchingID,
		@Label,
		@Description,
		@IconLocationURL,
		@IsPersistent,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)