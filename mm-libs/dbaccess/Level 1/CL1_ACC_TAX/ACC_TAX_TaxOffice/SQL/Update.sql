UPDATE 
	acc_tax_taxoffices
SET 
	CMN_BPT_BusinessParticipant_RefID=@CMN_BPT_BusinessParticipant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_TAX_TaxOfficeID = @ACC_TAX_TaxOfficeID