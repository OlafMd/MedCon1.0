INSERT INTO 
	cmn_com_companyinfo
	(
		CMN_COM_CompanyInfoID,
		CompanyLogo_Document_RefID,
		Contact_UCD_RefID,
		CompanyType_RefID,
		NumberOfEmployees,
		CompanyInfo_EstablishmentNumber,
		AnnualRevenueAmountValue_RefID,
		VATIdentificationNumber,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_COM_CompanyInfoID,
		@CompanyLogo_Document_RefID,
		@Contact_UCD_RefID,
		@CompanyType_RefID,
		@NumberOfEmployees,
		@CompanyInfo_EstablishmentNumber,
		@AnnualRevenueAmountValue_RefID,
		@VATIdentificationNumber,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)