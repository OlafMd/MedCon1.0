UPDATE 
	acc_cbx_cashbox_balancechanges
SET 
	CashBox_RefID=@CashBox_RefID,
	BalanceChange=@BalanceChange,
	DateOfBooking=@DateOfBooking,
	BookingText=@BookingText,
	BookingComment=@BookingComment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_CBX_CashBox_BalanceChangeID = @ACC_CBX_CashBox_BalanceChangeID