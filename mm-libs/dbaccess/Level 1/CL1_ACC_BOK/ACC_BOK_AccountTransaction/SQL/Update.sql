UPDATE 
	acc_bok_accounttransactions
SET 
	ExternalBankKey=@ExternalBankKey,
	BookingAccount_RefID=@BookingAccount_RefID,
	TransactionValue=@TransactionValue,
	DateOfBooking=@DateOfBooking,
	SenderText=@SenderText,
	SenderComment=@SenderComment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_BOK_AccountTransactionID = @ACC_BOK_AccountTransactionID