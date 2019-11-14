UPDATE 
	acc_crn_grantedcreditnotes
SET 
	CreditNoteITPL=@CreditNoteITPL,
	CreditNote_Currency_RefID=@CreditNote_Currency_RefID,
	CreditNote_Value=@CreditNote_Value,
	CreditNote_Number=@CreditNote_Number,
	DateOnCreditNote=@DateOnCreditNote,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_CRN_GrantedCreditNoteID = @ACC_CRN_GrantedCreditNoteID