INSERT INTO 
	acc_crn_grantedcreditnotes
	(
		ACC_CRN_GrantedCreditNoteID,
		CreditNoteITPL,
		CreditNote_Currency_RefID,
		CreditNote_Value,
		CreditNote_Number,
		DateOnCreditNote,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ACC_CRN_GrantedCreditNoteID,
		@CreditNoteITPL,
		@CreditNote_Currency_RefID,
		@CreditNote_Value,
		@CreditNote_Number,
		@DateOnCreditNote,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)