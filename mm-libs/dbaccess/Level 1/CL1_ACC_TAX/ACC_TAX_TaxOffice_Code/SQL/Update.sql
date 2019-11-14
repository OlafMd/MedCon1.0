UPDATE 
	acc_tax_taxoffice_codes
SET 
	TaxOffice_RefID=@TaxOffice_RefID,
	CMN_EconomicRegion_RefID=@CMN_EconomicRegion_RefID,
	TaxOfficeCode=@TaxOfficeCode,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_TAX_TaxOffice_CodeID = @ACC_TAX_TaxOffice_CodeID