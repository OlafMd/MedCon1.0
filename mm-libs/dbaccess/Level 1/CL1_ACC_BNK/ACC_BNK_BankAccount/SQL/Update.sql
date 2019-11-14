UPDATE 
	acc_bnk_bankaccounts
SET 
	Bank_RefID=@Bank_RefID,
	Currency_RefID=@Currency_RefID,
	IBAN=@IBAN,
	AccountNumber=@AccountNumber,
	BankAccountType_RefID=@BankAccountType_RefID,
	OwnerText=@OwnerText,
	AccountOpenedAtDate=@AccountOpenedAtDate,
	AccountClosedAtDate=@AccountClosedAtDate,
	IsValid=@IsValid,
	R_AccountBalance=@R_AccountBalance,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_BNK_BankAccountID = @ACC_BNK_BankAccountID