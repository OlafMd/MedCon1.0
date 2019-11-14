UPDATE 
	cmn_com_companyinfo_addresses
SET 
	CompanyInfo_RefID=@CompanyInfo_RefID,
	IsDefault=@IsDefault,
	IsBilling=@IsBilling,
	IsShipping=@IsShipping,
	IsContact=@IsContact,
	Address_Description=@Address_Description,
	Address_UCD_RefID=@Address_UCD_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_COM_CompanyInfo_AddressID = @CMN_COM_CompanyInfo_AddressID