UPDATE 
	acc_bok_bookingaccount_2_tax
SET 
	ACC_BOK_BookingAccount_RefID=@ACC_BOK_BookingAccount_RefID,
	ACC_TAX_Tax_RefID=@ACC_TAX_Tax_RefID,
	IsDefaultAccountForRevenueBookings=@IsDefaultAccountForRevenueBookings,
	IsDefaultAccountForTaxBookings=@IsDefaultAccountForTaxBookings,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID