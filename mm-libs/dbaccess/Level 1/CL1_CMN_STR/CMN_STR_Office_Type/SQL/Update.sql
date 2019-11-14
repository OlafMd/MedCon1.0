UPDATE 
	cmn_str_office_types
SET 
	OfficeType_Name_DictID=@OfficeType_Name,
	OfficeType_Description_DictID=@OfficeType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_Office_TypeID = @CMN_STR_Office_TypeID