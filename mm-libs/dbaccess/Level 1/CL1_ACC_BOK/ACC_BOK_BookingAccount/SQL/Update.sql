UPDATE 
	acc_bok_bookingaccounts
SET 
	BookingAccountNumber=@BookingAccountNumber,
	BookingAccountName=@BookingAccountName,
	FiscalYear_RefID=@FiscalYear_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_BOK_BookingAccountID = @ACC_BOK_BookingAccountID