INSERT INTO 
	acc_tax_taxoffices
	(
		ACC_TAX_TaxOfficeID,
		CMN_BPT_BusinessParticipant_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ACC_TAX_TaxOfficeID,
		@CMN_BPT_BusinessParticipant_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)