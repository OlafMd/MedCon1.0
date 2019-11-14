INSERT INTO 
	acc_bnk_bankaccount_balancechanges
	(
		ACC_BNK_BankAccount_BalanceChangeID,
		BankAccount_RefID,
		BalanceChange,
		DateOfBooking,
		BookingText,
		BookingComment,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ACC_BNK_BankAccount_BalanceChangeID,
		@BankAccount_RefID,
		@BalanceChange,
		@DateOfBooking,
		@BookingText,
		@BookingComment,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)