UPDATE 
	tms_pro_developertask_priorities
SET 
	Label_DictID=@Label,
	Description_DictID=@Description,
	IconLocationURL=@IconLocationURL,
	Priority_Colour=@Priority_Colour,
	Groups=@Groups,
	PriorityLevel=@PriorityLevel,
	IsPersistent=@IsPersistent,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_DeveloperTask_PriorityID = @TMS_PRO_DeveloperTask_PriorityID