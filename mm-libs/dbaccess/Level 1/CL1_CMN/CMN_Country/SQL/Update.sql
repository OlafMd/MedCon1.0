UPDATE 
	cmn_countries
SET 
	Default_Language_RefID=@Default_Language_RefID,
	Default_Currency_RefID=@Default_Currency_RefID,
	Country_Name_DictID=@Country_Name,
	Country_ISOCode_Alpha2=@Country_ISOCode_Alpha2,
	Country_ISOCode_Alpha3=@Country_ISOCode_Alpha3,
	Country_ISOCode_Numeric=@Country_ISOCode_Numeric,
	IsActive=@IsActive,
	IsDefault=@IsDefault,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_CountryID = @CMN_CountryID