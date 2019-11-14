UPDATE 
	cmn_com_companyinfo
SET 
	CompanyLogo_Document_RefID=@CompanyLogo_Document_RefID,
	Contact_UCD_RefID=@Contact_UCD_RefID,
	CompanyType_RefID=@CompanyType_RefID,
	NumberOfEmployees=@NumberOfEmployees,
	CompanyInfo_EstablishmentNumber=@CompanyInfo_EstablishmentNumber,
	AnnualRevenueAmountValue_RefID=@AnnualRevenueAmountValue_RefID,
	VATIdentificationNumber=@VATIdentificationNumber,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_COM_CompanyInfoID = @CMN_COM_CompanyInfoID