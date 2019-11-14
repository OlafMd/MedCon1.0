UPDATE 
	cmn_str_profession_calendartemplates
SET 
	Profession_RefID=@Profession_RefID,
	CalendarInstance_RefID=@CalendarInstance_RefID,
	Label_DictID=@Label,
	Description_DictID=@Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_Profession_CalendarTemplateID = @CMN_STR_Profession_CalendarTemplateID