UPDATE 
	cmn_str_office_calendartemplate
SET 
	Office_RefID=@Office_RefID,
	CalendarInstance_RefID=@CalendarInstance_RefID,
	Label_DictID=@Label,
	Description_DictID=@Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_Office_CalendarTemplateID = @CMN_STR_Office_CalendarTemplateID