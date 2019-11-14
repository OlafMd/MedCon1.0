UPDATE 
	acc_bok_accounting_bookinglines
SET 
	ExternalBankKey=@ExternalBankKey,
	PartOfAccountingTransaction_RefID=@PartOfAccountingTransaction_RefID,
	BookingAccount_RefID=@BookingAccount_RefID,
	TransactionValue=@TransactionValue,
	DateOfBooking=@DateOfBooking,
	DateOfTransaction=@DateOfTransaction,
	SenderText=@SenderText,
	SenderComment=@SenderComment,
	Currency_RefID=@Currency_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_BOK_Accounting_BookingLineID = @ACC_BOK_Accounting_BookingLineID