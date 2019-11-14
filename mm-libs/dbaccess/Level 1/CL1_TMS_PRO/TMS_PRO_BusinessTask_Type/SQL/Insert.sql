INSERT INTO 
	tms_pro_businesstask_types
	(
		TMS_PRO_BusinessTask_TypeID,
		GlobalPropertyMatchingID,
		Label_DictID,
		Description_DictID,
		IsPersistent,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@TMS_PRO_BusinessTask_TypeID,
		@GlobalPropertyMatchingID,
		@Label,
		@Description,
		@IsPersistent,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)