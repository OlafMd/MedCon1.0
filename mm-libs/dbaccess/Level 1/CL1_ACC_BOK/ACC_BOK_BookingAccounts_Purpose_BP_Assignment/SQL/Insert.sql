INSERT INTO 
	acc_bok_bookingaccounts_purpose_bp_assignments
	(
		ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID,
		BusinessParticipant_RefID,
		BookingAccount_RefID,
		Is_L1_BalanceSheet_Account,
		Is_L1_IncomeStatement_Account,
		Is_L2_AssetAccount,
		Is_L2_LiabilitiesAccount,
		Is_L2_RevenuesOrIncomeAccount,
		Is_L2_ExpensesOrLossesAccount,
		If_L3_AssetAccount_BankAccount_RefID,
		If_L3_AssetAccount_CashBox_RefID,
		Is_L3_BankAccount,
		Is_L3_CustomerAccount,
		Is_L3_SupplierAccount,
		Is_L3_VATAccount,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ACC_BOK_BookingAccounts_Purpose_BP_AssignmentID,
		@BusinessParticipant_RefID,
		@BookingAccount_RefID,
		@Is_L1_BalanceSheet_Account,
		@Is_L1_IncomeStatement_Account,
		@Is_L2_AssetAccount,
		@Is_L2_LiabilitiesAccount,
		@Is_L2_RevenuesOrIncomeAccount,
		@Is_L2_ExpensesOrLossesAccount,
		@If_L3_AssetAccount_BankAccount_RefID,
		@If_L3_AssetAccount_CashBox_RefID,
		@Is_L3_BankAccount,
		@Is_L3_CustomerAccount,
		@Is_L3_SupplierAccount,
		@Is_L3_VATAccount,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)