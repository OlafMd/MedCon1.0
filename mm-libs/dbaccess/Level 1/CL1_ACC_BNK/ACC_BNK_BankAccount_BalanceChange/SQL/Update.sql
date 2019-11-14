UPDATE 
	acc_bnk_bankaccount_balancechanges
SET 
	BankAccount_RefID=@BankAccount_RefID,
	BalanceChange=@BalanceChange,
	DateOfBooking=@DateOfBooking,
	BookingText=@BookingText,
	BookingComment=@BookingComment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_BNK_BankAccount_BalanceChangeID = @ACC_BNK_BankAccount_BalanceChangeID