
	Select
	  acc_bnk_bankaccounts.ACC_BNK_BankAccountID,
	  acc_bnk_bankaccounts.Bank_RefID,
	  acc_bnk_bankaccounts.OwnerText,
	  acc_bnk_bankaccounts.IsValid,
	  acc_bnk_bankaccounts.IBAN,
	  acc_bnk_bankaccounts.AccountNumber,
	  acc_bnk_bankaccounts.Currency_RefID,
	  acc_bnk_bankaccounts.BankAccountType_RefID,
	  acc_bnk_bankaccounts.AccountOpenedAtDate,
	  acc_bnk_bankaccounts.Tenant_RefID
	From
	  acc_bnk_bankaccounts
	Where
	  acc_bnk_bankaccounts.IsDeleted = 0 And
	  acc_bnk_bankaccounts.Tenant_RefID = @TenantID
  