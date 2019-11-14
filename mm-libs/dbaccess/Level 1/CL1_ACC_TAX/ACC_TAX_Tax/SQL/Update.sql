UPDATE 
	acc_tax_taxes
SET 
	EconomicRegion_RefID=@EconomicRegion_RefID,
	TaxName_DictID=@TaxName,
	TaxRate=@TaxRate,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_TAX_TaxeID = @ACC_TAX_TaxeID