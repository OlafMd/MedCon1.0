UPDATE 
	cmn_str_office_spokenlanguages
SET 
	Office_RefID=@Office_RefID,
	Language_RefID=@Language_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_STR_Office_SpokenLanguageID = @CMN_STR_Office_SpokenLanguageID