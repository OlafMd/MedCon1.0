UPDATE 
	tms_pro_businesstask_status
SET 
	Label_DictID=@Label,
	Description_DictID=@Description,
	IsPersistent=@IsPersistent,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_BusinessTask_StatusID = @TMS_PRO_BusinessTask_StatusID