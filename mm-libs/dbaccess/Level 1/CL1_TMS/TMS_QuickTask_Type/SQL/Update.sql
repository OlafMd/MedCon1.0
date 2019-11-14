UPDATE 
	tms_quicktask_type
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	QuickTaskType_ExternalID=@QuickTaskType_ExternalID,
	QuickTaskType_Name_DictID=@QuickTaskType_Name,
	QuickTaskType_Description_DictID=@QuickTaskType_Description,
	IsPersistent=@IsPersistent,
	Tenant_RefID=@Tenant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted
WHERE 
	TMS_QuickTask_TypeID = @TMS_QuickTask_TypeID