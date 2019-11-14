INSERT INTO 
	acc_cbx_cashbox_balancechanges
	(
		ACC_CBX_CashBox_BalanceChangeID,
		CashBox_RefID,
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
		@ACC_CBX_CashBox_BalanceChangeID,
		@CashBox_RefID,
		@BalanceChange,
		@DateOfBooking,
		@BookingText,
		@BookingComment,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)