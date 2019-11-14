INSERT INTO 
	acc_bnk_bankaccounts
	(
		ACC_BNK_BankAccountID,
		Bank_RefID,
		Currency_RefID,
		IBAN,
		AccountNumber,
		BankAccountType_RefID,
		OwnerText,
		AccountOpenedAtDate,
		AccountClosedAtDate,
		IsValid,
		R_AccountBalance,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ACC_BNK_BankAccountID,
		@Bank_RefID,
		@Currency_RefID,
		@IBAN,
		@AccountNumber,
		@BankAccountType_RefID,
		@OwnerText,
		@AccountOpenedAtDate,
		@AccountClosedAtDate,
		@IsValid,
		@R_AccountBalance,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)