UPDATE 
	cmn_loc_region_calendartemplates
SET 
	CalendarInstance_RefID=@CalendarInstance_RefID,
	Region_RefID=@Region_RefID,
	Label_DictID=@Label,
	Description_DictID=@Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_LOC_Region_CalendarTemplateID = @CMN_LOC_Region_CalendarTemplateID