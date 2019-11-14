UPDATE 
	tms_pro_developertask_types
SET 
	Label_DictID=@Label,
	Description_DictID=@Description,
	IconLocationURL=@IconLocationURL,
	IsPersistent=@IsPersistent,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_DeveloperTask_TypeID = @TMS_PRO_DeveloperTask_TypeID