UPDATE 
	cmn_com_companyinfo_types
SET 
	CompanyType_Name_DictID=@CompanyType_Name,
	CompanyType_Description_DictID=@CompanyType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_COM_CompanyInfo_TypeID = @CMN_COM_CompanyInfo_TypeID