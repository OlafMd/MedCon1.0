UPDATE 
	cmn_languages
SET 
	ISO_639_1=@ISO_639_1,
	ISO_639_2=@ISO_639_2,
	Label=@Label,
	Name_DictID=@Name,
	Icon_Document_RefID=@Icon_Document_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_LanguageID = @CMN_LanguageID